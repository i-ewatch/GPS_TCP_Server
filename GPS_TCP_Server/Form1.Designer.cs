
namespace GPS_TCP_Server
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cbet_ClientCustomer = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btn_StopListen = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btn_StartListen = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Port = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Server_IP = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lbl_YesterDay = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_NowDay = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.lbl_DataView = new DevExpress.XtraEditors.LabelControl();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbet_ClientCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Port.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Server_IP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.cbet_ClientCustomer);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.btn_StopListen);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.btn_StartListen);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.txt_Port);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txt_Server_IP);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1149, 28);
            this.panelControl1.TabIndex = 0;
            // 
            // cbet_ClientCustomer
            // 
            this.cbet_ClientCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbet_ClientCustomer.Location = new System.Drawing.Point(812, 0);
            this.cbet_ClientCustomer.Name = "cbet_ClientCustomer";
            this.cbet_ClientCustomer.Properties.AllowFocused = false;
            this.cbet_ClientCustomer.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.cbet_ClientCustomer.Properties.Appearance.Options.UseFont = true;
            this.cbet_ClientCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbet_ClientCustomer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbet_ClientCustomer.Size = new System.Drawing.Size(337, 26);
            this.cbet_ClientCustomer.TabIndex = 13;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl4.Location = new System.Drawing.Point(711, 0);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(101, 28);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "客戶端列表";
            // 
            // btn_StopListen
            // 
            this.btn_StopListen.AllowFocus = false;
            this.btn_StopListen.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_StopListen.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.btn_StopListen.Appearance.Options.UseBackColor = true;
            this.btn_StopListen.Appearance.Options.UseFont = true;
            this.btn_StopListen.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_StopListen.Enabled = false;
            this.btn_StopListen.Location = new System.Drawing.Point(623, 0);
            this.btn_StopListen.Name = "btn_StopListen";
            this.btn_StopListen.Size = new System.Drawing.Size(88, 28);
            this.btn_StopListen.TabIndex = 11;
            this.btn_StopListen.Text = "暫停監聽";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseTextOptions = true;
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl5.Location = new System.Drawing.Point(618, 0);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(5, 28);
            this.labelControl5.TabIndex = 10;
            // 
            // btn_StartListen
            // 
            this.btn_StartListen.AllowFocus = false;
            this.btn_StartListen.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_StartListen.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.btn_StartListen.Appearance.Options.UseBackColor = true;
            this.btn_StartListen.Appearance.Options.UseFont = true;
            this.btn_StartListen.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_StartListen.Enabled = false;
            this.btn_StartListen.Location = new System.Drawing.Point(530, 0);
            this.btn_StartListen.Name = "btn_StartListen";
            this.btn_StartListen.Size = new System.Drawing.Size(88, 28);
            this.btn_StartListen.TabIndex = 7;
            this.btn_StartListen.Text = "開始監聽";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl3.Location = new System.Drawing.Point(500, 0);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(30, 28);
            this.labelControl3.TabIndex = 6;
            // 
            // txt_Port
            // 
            this.txt_Port.Dock = System.Windows.Forms.DockStyle.Left;
            this.txt_Port.Location = new System.Drawing.Point(392, 0);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Port.Properties.Appearance.Options.UseFont = true;
            this.txt_Port.Size = new System.Drawing.Size(108, 26);
            this.txt_Port.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl2.Location = new System.Drawing.Point(328, 0);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 28);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "端口";
            // 
            // txt_Server_IP
            // 
            this.txt_Server_IP.Dock = System.Windows.Forms.DockStyle.Left;
            this.txt_Server_IP.Enabled = false;
            this.txt_Server_IP.Location = new System.Drawing.Point(82, 0);
            this.txt_Server_IP.Name = "txt_Server_IP";
            this.txt_Server_IP.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Server_IP.Properties.Appearance.Options.UseFont = true;
            this.txt_Server_IP.Size = new System.Drawing.Size(246, 26);
            this.txt_Server_IP.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 28);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Server_IP";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lbl_YesterDay);
            this.panelControl2.Controls.Add(this.labelControl8);
            this.panelControl2.Controls.Add(this.lbl_NowDay);
            this.panelControl2.Controls.Add(this.labelControl6);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 28);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1149, 41);
            this.panelControl2.TabIndex = 1;
            // 
            // lbl_YesterDay
            // 
            this.lbl_YesterDay.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lbl_YesterDay.Appearance.Options.UseFont = true;
            this.lbl_YesterDay.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_YesterDay.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_YesterDay.Location = new System.Drawing.Point(314, 2);
            this.lbl_YesterDay.Name = "lbl_YesterDay";
            this.lbl_YesterDay.Size = new System.Drawing.Size(104, 37);
            this.lbl_YesterDay.TabIndex = 3;
            this.lbl_YesterDay.Text = "-";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl8.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl8.Location = new System.Drawing.Point(210, 2);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(104, 37);
            this.labelControl8.TabIndex = 2;
            this.labelControl8.Text = "昨日封包數量 :";
            // 
            // lbl_NowDay
            // 
            this.lbl_NowDay.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lbl_NowDay.Appearance.Options.UseFont = true;
            this.lbl_NowDay.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_NowDay.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_NowDay.Location = new System.Drawing.Point(106, 2);
            this.lbl_NowDay.Name = "lbl_NowDay";
            this.lbl_NowDay.Size = new System.Drawing.Size(104, 37);
            this.lbl_NowDay.TabIndex = 1;
            this.lbl_NowDay.Text = "-";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl6.Location = new System.Drawing.Point(2, 2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(104, 37);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "今日封包數量 :";
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.lbl_DataView);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 69);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1149, 143);
            this.panelControl3.TabIndex = 2;
            // 
            // lbl_DataView
            // 
            this.lbl_DataView.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lbl_DataView.Appearance.Options.UseFont = true;
            this.lbl_DataView.Appearance.Options.UseTextOptions = true;
            this.lbl_DataView.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lbl_DataView.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lbl_DataView.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lbl_DataView.Location = new System.Drawing.Point(0, 0);
            this.lbl_DataView.Name = "lbl_DataView";
            this.lbl_DataView.Size = new System.Drawing.Size(1149, 20);
            this.lbl_DataView.TabIndex = 0;
            this.lbl_DataView.Text = "labelControl6";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 212);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("Form1.IconOptions.Icon")));
            this.Name = "Form1";
            this.Text = "GPS_TCP_Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbet_ClientCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Port.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Server_IP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_Server_IP;
        private DevExpress.XtraEditors.TextEdit txt_Port;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cbet_ClientCustomer;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btn_StopListen;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btn_StartListen;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl lbl_DataView;
        private DevExpress.XtraEditors.LabelControl lbl_YesterDay;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl lbl_NowDay;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

