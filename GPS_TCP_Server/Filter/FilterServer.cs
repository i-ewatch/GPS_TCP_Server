using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace GPS_TCP_Server.Filter
{
    public class FilterServer : AppServer
    {
        /// <summary>
        /// 自製Server
        /// </summary>
        public FilterServer() : base(new DefaultReceiveFilterFactory<ReceiveFilter, StringRequestInfo>()) { }
        protected override AppSession CreateAppSession(ISocketSession socketSession)
        {
            return base.CreateAppSession(socketSession);
        }
    }
}
