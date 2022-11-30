using GPS_TCP_Server.Enums;
using GPS_TCP_Server.Filter;
using Serilog;
using SuperSocket.SocketBase;
using System.Collections.Generic;

namespace GPS_TCP_Server.Methods
{
    public class TCP_Listen_Method
    {
        /// <summary>
        /// 主視窗
        /// </summary>
        public Form1 Form1 { get; set; }
        /// <summary>
        /// 監聽客戶端連接
        /// </summary>
        private FilterServer FilterServer { get; set; }
        /// <summary>
        /// 客戶連線IP資訊
        /// </summary>
        Dictionary<string, AppSession> sessionList = new Dictionary<string, AppSession>();
        /// <summary>
        /// 接收資訊
        /// </summary>
        public Queue<string[]> Response = new Queue<string[]>();
        public Queue<string> ResponseStr = new Queue<string>();
        public TCP_Listen_Method(Form1 form1)
        {
            Form1 = form1;
        }
        #region 開啟監聽
        /// <summary>
        /// 開啟監聽
        /// </summary>
        /// <param name="Port"></param>
        public void StartListen(string Port)
        {
            FilterServer = new FilterServer();
            if (!FilterServer.Setup(int.Parse(Port)))
            {
                Form1.SetMessage("Failed to Setup", false);
                return;
            }
            if (!FilterServer.Start())
            {
                Form1.SetMessage("Failed to Start", false);
                return;
            }
            else
            {
                Form1.SetMessage("開啟監聽", false);
            }
            FilterServer.NewSessionConnected += (session) =>
            {
                //客戶的IP
                string ipAddress_Connect = session.RemoteEndPoint.ToString();
                Form1.ComboboxHandle(ipAddress_Connect, OperateType.Add);
                sessionList.Add(ipAddress_Connect, session);
                Form1.SetMessage(ipAddress_Connect + " 已連接!", false);
                Log.Information($"{ipAddress_Connect} 已連接!");
            };
            //接收數據
            FilterServer.NewRequestReceived += (session, requesInfo) =>
            {
                string[] filter = requesInfo.Body.Split('$');
                string ipAddress_Receive = session.RemoteEndPoint.ToString();
                if (filter.Length >= 2)
                {
                    foreach (var item in filter)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            if (item.Contains("#"))
                            {
                                string data = "$" + item;
                                string[] value = data.Split(',');
                                if (data.Length >= 22)
                                {

                                    if (value[22] == "0401" || value[22] == "0402" || value[22] == "0403" || value[22] == "0404" || value[22] == "0101")
                                    {
                                        //Response.Enqueue(value);
                                        ResponseStr.Enqueue(data);
                                        Form1.SetMessage("收到 " + ipAddress_Receive + $"於 {value[1]}" + " 數據 " + $"{value[21]}-{value[22]} ", true);
                                        Log.Information("收到 " + ipAddress_Receive + $"於 {value[1]}" + " 數據 " + $"{value[21]}-{value[22]} 封包 " + data);
                                    }
                                    else
                                    {
                                        Log.Error("收到 " + ipAddress_Receive + $"於 {requesInfo.Parameters[1]}" + " 封包開頭錯誤 " + item);
                                    }
                                }
                                else
                                {
                                    Log.Error("收到 " + ipAddress_Receive + $"於 {requesInfo.Parameters[1]}" + " 封包長度錯誤 " + item);
                                }
                            }
                            else
                            {
                                Log.Error("收到 " + ipAddress_Receive + $"於 {requesInfo.Parameters[1]}" + " 封包長度錯誤 " + item);
                            }
                        }
                    }
                }
                else
                {
                    string[] value = requesInfo.Body.Split(',');
                    if (requesInfo.Parameters.Length >= 22)
                    {
                        if (requesInfo.Parameters[22] == "0401" || requesInfo.Parameters[22] == "0402" || requesInfo.Parameters[22] == "0403" || requesInfo.Parameters[22] == "0404" || requesInfo.Parameters[22] == "0101")
                        {
                            //Response.Enqueue(requesInfo.Parameters);
                            ResponseStr.Enqueue(requesInfo.Body);
                            Form1.SetMessage("收到 " + ipAddress_Receive + $"於 {requesInfo.Parameters[1]}" + " 數據 " + $"{requesInfo.Parameters[21]}-{requesInfo.Parameters[22]} ", true);
                            Log.Information("收到 " + ipAddress_Receive + $"於 {requesInfo.Parameters[1]}" + " 數據 " + $"{requesInfo.Parameters[21]}-{requesInfo.Parameters[22]} 封包 " + requesInfo.Body);
                        }
                        else
                        {
                            Log.Error("收到 " + ipAddress_Receive + $"於 {requesInfo.Parameters[1]}" + " 封包開頭錯誤 " + requesInfo.Body);
                        }
                    }
                    else
                    {
                        Log.Error("收到 " + ipAddress_Receive + $"於 {requesInfo.Parameters[1]}" + " 封包長度錯誤 " + requesInfo.Body);
                    }
                }
            };
            //關閉連接
            FilterServer.SessionClosed += (session, value) =>
            {
                string ipAddress_Close = session.RemoteEndPoint.ToString();
                Form1.ComboboxHandle(ipAddress_Close, OperateType.Remove);
                sessionList.Remove(ipAddress_Close);
                Form1.SetMessage(ipAddress_Close + " 已關閉連接!", false);
                Log.Information($"{ipAddress_Close} 已關閉連接!");
            };
        }
        #endregion
        #region 暫停監聽
        /// <summary>
        /// 暫停監聽
        /// </summary>
        public void StopListen()
        {
            FilterServer.Stop();
            Form1.SetMessage("暫停監聽", false);
        }
        #endregion
    }
}
