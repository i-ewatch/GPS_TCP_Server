using GPS_TCP_Server.Methods;
using System;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace GPS_TCP_Server.Components
{
    public partial class SendComponent : Field4Component
    {
        public SendComponent(TCP_Client_Method tCP_Client_Method, TCP_Listen_Method tCP_Listen_Method)
        {
            InitializeComponent();
            TCP_Client_Method = tCP_Client_Method;
            TCP_Listen_Method = tCP_Listen_Method;
        }

        public SendComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        protected override void AfterMyWorkStateChanged(object sender, EventArgs e)
        {
            if (myWorkState)
            {
                ReadThread = new Thread(Analysis);
                ReadThread.Start();
            }
            else
            {
                if (ReadThread != null)
                {
                    ReadThread.Abort();
                }
            }
        }
        private void Analysis()
        {
            while (myWorkState)
            {
                try
                {
                    TimeSpan timeSpan = DateTime.Now.Subtract(ReadTime);
                    if (timeSpan.TotalSeconds >= 30)
                    {
                        foreach (var item in TCP_Listen_Method.SendMessage)
                        {
                            if (item.SendFlag)
                            {
                                string[] separatingStrings = { "BATT" };
                                string[] Message = item.Message.Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries);
                                byte[] data = Encoding.ASCII.GetBytes(Message[0]);
                                if (TCP_Client_Method.client.IsConnected)
                                {
                                    TCP_Client_Method.client.Send(data, 0, data.Length);
                                    item.SendFlag = false;//發送完畢
                                }
                                else
                                {
                                    TCP_Client_Method.Connect_To_Server();
                                }
                            }
                        }
                        ReadTime = DateTime.Now;
                    }
                    else
                    {
                        Thread.Sleep(80);
                    }
                }
                catch (ThreadAbortException) { }
                catch (Exception) { }
            }
        }
    }
}
