using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraEditors;
using GPS_TCP_Server.Components;
using GPS_TCP_Server.Configuration;
using GPS_TCP_Server.Enums;
using GPS_TCP_Server.Methods;
using Serilog;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GPS_TCP_Server
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 系統資訊
        /// </summary>
        private SystemSetting SystemSetting { get; set; }
        /// <summary>
        /// 服務器方法
        /// </summary>
        private TCP_Listen_Method TCP_Listen_Method { get; set; }
        /// <summary>
        /// 客戶端方法(轉發資訊)
        /// </summary>
        private TCP_Client_Method TCP_Client_Method { get; set; }
        /// <summary>
        /// 資料庫方法
        /// </summary>
        private SqlMethod SqlMethod { get; set; }
        /// <summary>
        /// 接收資訊物件
        /// </summary>
        private ResponseComponent ResponseComponent { get; set; }
        /// <summary>
        /// 發送資訊物件
        /// </summary>
        private SendComponent SendComponent { get; set; }
        /// <summary>
        /// 換日線
        /// </summary>
        private int Day;
        /// <summary>
        /// 今日封包數量
        /// </summary>
        private int NowDay = 0;
        /// <summary>
        /// 昨日封包數量
        /// </summary>
        private int YesterDay = 0;
        public Form1()
        {
            InitializeComponent();
            #region Serilog initial
            Log.Logger = new LoggerConfiguration()
                        .WriteTo.Console()
                        .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == Serilog.Events.LogEventLevel.Error).WriteTo.File($"{AppDomain.CurrentDomain.BaseDirectory}\\log\\Error-.txt",
                                      rollingInterval: RollingInterval.Day,
                                      outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"))
                        .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == Serilog.Events.LogEventLevel.Information).WriteTo.File($"{AppDomain.CurrentDomain.BaseDirectory}\\log\\Information-.txt",
                                      rollingInterval: RollingInterval.Day,
                                      outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"))
                        .CreateLogger();        //宣告Serilog初始化
            #endregion
            MaximizeBox = false;
            CloseBox = false;
            SystemSetting = InitailMethod.System_Load();

            txt_Server_IP.Text = "Any";
            txt_Port.Text = SystemSetting.Server_Port;
            txt_ClientDns.Text = "www.zheli.com.tw";
            txt_ClientPort.Text = "20018";

            btn_StartListen.Enabled = false;
            btn_StopListen.Enabled = true;
            btn_connect.Enabled = false;
            btn_disconnect.Enabled = true;
            txt_Port.Enabled = false;
            txt_ClientPort.Enabled = false;

            TCP_Listen_Method = new TCP_Listen_Method(this);
            TCP_Client_Method = new TCP_Client_Method(txt_ClientDns.Text, Convert.ToInt32(txt_ClientPort.Text));
            SqlMethod = new SqlMethod(SystemSetting);

            #region 開啟監聽
            btn_StartListen.Click += (s, e) =>
            {
                if (!btn_StopListen.Enabled)
                {
                    TCP_Listen_Method.StartListen(txt_Port.Text);
                    btn_StartListen.Enabled = false;
                    btn_StopListen.Enabled = true;
                    txt_Port.Enabled = false;
                    ResponseComponent.MyWorkState = true;
                }
            };
            #endregion
            #region 暫停監聽
            btn_StopListen.Click += (s, e) =>
            {
                if (!btn_StartListen.Enabled)
                {
                    TCP_Listen_Method.StopListen();
                    btn_StartListen.Enabled = true;
                    btn_StopListen.Enabled = false;
                    txt_Port.Enabled = true;
                    ResponseComponent.MyWorkState = false;
                }
            };
            #endregion

            #region 開始連線
            btn_connect.Click += (s, e) =>
            {
                TCP_Client_Method.Connect_To_Server();
                btn_connect.Enabled = false;
                btn_disconnect.Enabled = true;
                txt_ClientPort.Enabled = false;
                SendComponent.MyWorkState = true;
            };
            #endregion
            #region 關閉連線
            btn_disconnect.Click += (s, e) =>
            {
                TCP_Client_Method.DisConnect_To_Server();
                btn_connect.Enabled = true;
                btn_disconnect.Enabled = false;
                txt_ClientPort.Enabled = true;
                SendComponent.MyWorkState = false;
            };
            #endregion
            #region 最小化
            notifyIcon.MouseDoubleClick += (s, e) =>
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            };
            #endregion
            Day = DateTime.Now.Day;
            timer.Enabled = true;
        }
        #region RichTextBox 文字顯示
        /// <summary>
        /// RichTextBox 文字顯示
        /// </summary>
        /// <param name="str"></param>
        public void SetMessage(string str, bool Record)
        {
            lbl_DataView.Invoke(new Action(() => { lbl_DataView.Text = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} " + str; }));
            if (Record)
            {
                NowDay++;
            }
        }
        #endregion
        #region combobox操作
        /// <summary>
        /// combobox操作
        /// </summary>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="operateType">添加移除類型</param>
        public void ComboboxHandle(string ipAddress, OperateType operateType)
        {
            switch (operateType)
            {
                case OperateType.Add:
                    {
                        cbet_ClientCustomer.Invoke(new Action(() => { cbet_ClientCustomer.Properties.Items.Add(ipAddress); }));
                    }
                    break;
                case OperateType.Remove:
                    {
                        cbet_ClientCustomer.Invoke(new Action(() => { cbet_ClientCustomer.Properties.Items.Remove(ipAddress); }));
                    }
                    break;
            }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            TCP_Listen_Method.StartListen(txt_Port.Text);
            ResponseComponent = new ResponseComponent(SqlMethod, TCP_Listen_Method);
            ResponseComponent.MyWorkState = true;
            TCP_Client_Method.Connect_To_Server();
            SendComponent = new SendComponent(TCP_Client_Method,TCP_Listen_Method);
            SendComponent.MyWorkState = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Day != Day)
            {
                YesterDay = NowDay;
                NowDay = 0;
                lbl_YesterDay.Invoke(new Action(() => { lbl_YesterDay.Text = $"{YesterDay}"; }));
                Day = DateTime.Now.Day;
            }
            if (TCP_Client_Method.client.IsConnected)
            {
                stateIndicatorComponent1.StateIndex = 3;
            }
            else
            {
                stateIndicatorComponent1.StateIndex = 1;
            }
            lbl_NowDay.Invoke(new Action(() => { lbl_NowDay.Text = $"{NowDay}"; }));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserControl control = new UserControl() { Padding = new Padding(0, 30, 0, 20), Size = new Size(400, 200) };
            TextEdit textEdit = new TextEdit() { Dock = DockStyle.Top, Size = new Size(400, 40) };
            textEdit.Properties.Appearance.FontSizeDelta = 12;
            textEdit.Properties.Appearance.Options.UseFont = true;
            textEdit.Properties.Appearance.Options.UseTextOptions = true;
            textEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            textEdit.Parent = control;
            textEdit.Properties.UseSystemPasswordChar = true;
            LabelControl labelControl = new LabelControl() { Dock = DockStyle.Top, Size = new Size(400, 50) };
            labelControl.Appearance.FontSizeDelta = 18;
            labelControl.AutoSizeMode = LabelAutoSizeMode.None;
            labelControl.Text = "請輸入關閉軟體密碼";
            labelControl.Appearance.Options.UseFont = true;
            labelControl.Appearance.Options.UseTextOptions = true;
            labelControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            labelControl.Parent = control;
            SimpleButton okButton = new SimpleButton() { Dock = DockStyle.Bottom, Text = "確定", Size = new Size(400, 40) };
            okButton.Appearance.BackColor = Color.FromArgb(80, 80, 80);
            okButton.Appearance.FontSizeDelta = 12;
            okButton.DialogResult = DialogResult.OK;
            okButton.Parent = control;
            if (FlyoutDialog.Show(FindForm(), control) == DialogResult.OK && string.Compare(textEdit.Text, "qu!t", true) == 0)
            {
                if (ResponseComponent != null) ResponseComponent.MyWorkState = false;
                if (TCP_Listen_Method != null)
                {
                    TCP_Listen_Method.StopListen();
                }
                if (TCP_Client_Method != null)
                {
                    TCP_Client_Method.DisConnect_To_Server();
                }
                timer.Enabled = false;
                Application.ExitThread();
                this.Dispose();
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon.Visible = true;
            }
            else
            {
                this.notifyIcon.Visible = false;
            }
        }
    }
}
