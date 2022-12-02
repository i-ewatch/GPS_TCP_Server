namespace GPS_TCP_Server.Modules
{
    public class SendData
    {
        /// <summary>
        /// 發送旗標
        /// true = 未發送
        /// false = 已發送
        /// </summary>
        public bool SendFlag { get; set; }
        /// <summary>
        /// GPS編碼
        /// </summary>
        public string imei { get; set; }
        /// <summary>
        /// 發送資訊
        /// </summary>
        public string Message { get; set; }
    }
}
