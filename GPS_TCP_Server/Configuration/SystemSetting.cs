namespace GPS_TCP_Server.Configuration
{
    public class SystemSetting
    {
        /// <summary>
        /// 服務器端口
        /// </summary>
        public string Server_Port { get; set; }
        /// <summary>
        /// 資料庫位址
        /// </summary>
        public string ServerIp { get; set; }
        /// <summary>
        /// 資料庫名稱
        /// </summary>
        public string Database { get; set; }
        /// <summary>
        /// 資料庫使用者帳號
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 資料庫使用者密碼
        /// </summary>
        public string UserPwd { get; set; }
    }
}
