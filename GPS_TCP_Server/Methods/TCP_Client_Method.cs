using SuperSocket.ClientEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GPS_TCP_Server.Methods
{
    public class TCP_Client_Method
    {
        public string IP { get; set; }
        private int Port { get; set; }
        public AsyncTcpSession client { get; set; }
        public TCP_Client_Method(string ip, int port)
        {
            IP = ip;
            Port = port;
            client = new AsyncTcpSession();
            client.NoDelay = true;
        }
        public void Connect_To_Server()
        {
            try
            {
                client.Connect(new DnsEndPoint(IP, Port, AddressFamily.InterNetworkV6));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void DisConnect_To_Server()
        {
            if (client != null)
            {
                client.Close();
            }
        }
    }
}
