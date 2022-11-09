using SuperSocket.Facility.Protocol;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Text;

namespace GPS_TCP_Server.Filter
{
    public class ReceiveFilter : BeginEndMarkReceiveFilter<StringRequestInfo>
    {
        /// <summary>
        /// 起始旗標字串
        /// </summary>
        private readonly static byte[] BeginMark = new byte[] { Convert.ToByte('$') };//{ (byte)'\u0001' };
        /// <summary>
        /// 結束旗標字串
        /// </summary>
        private readonly static byte[] EndMark = new byte[] { Convert.ToByte('#') };
        public ReceiveFilter() : base(BeginMark, EndMark) { }
        protected override StringRequestInfo ProcessMatchedRequest(byte[] readBuffer, int offset, int length)
        {
            string str = Encoding.ASCII.GetString(readBuffer);
            string[] arr = str.Split(',');
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return new StringRequestInfo(BitConverter.ToInt64(buffer, 0).ToString(), str, arr);
        }
    }
}
