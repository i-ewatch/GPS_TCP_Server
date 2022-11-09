using System;

namespace GPS_TCP_Server.Modules
{
    public class BATT0404Data: BATTModule
    {
        #region GPS基本資訊
        /// <summary>
        /// 時間字串
        /// </summary>
        public string ttime { get; set; }
        /// <summary>
        /// 時間格式
        /// </summary>
        public DateTime ttimen
        {
            get
            {
                string year = ttime.Substring(0, 4);
                string month = ttime.Substring(4, 2);
                string day = ttime.Substring(6, 2);
                string hour = ttime.Substring(8, 2);
                string minute = ttime.Substring(10, 2);
                string second = ttime.Substring(12, 2);
                int UTC = Convert.ToInt32(Convert.ToDouble(Longitude)) / 15;
                if (Convert.ToInt32(hour) + UTC >= 24)
                {
                    return Convert.ToDateTime($"{year}/{month}/{day} {Convert.ToInt32(hour) + UTC - 24}:{minute}:{second}");
                }
                else
                {
                    return Convert.ToDateTime($"{year}/{month}/{day} {Convert.ToInt32(hour) + UTC}:{minute}:{second}");
                }
            }
        }
        /// <summary>
        /// GPS imei 編號
        /// </summary>
        public string imei { get; set; }
        /// <summary>
        /// 經度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        /// 緯度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        /// 速度
        /// </summary>
        public decimal Speed { get; set; }
        #endregion
        /// <summary>
        /// 電池模組名稱
        /// </summary>
        public string BattName { get; set; }
        /// <summary>
        /// BATT_UVW
        /// </summary>
        public int BATT_UVP { get; set; }
        /// <summary>
        /// BMS1_BMS2
        /// </summary>
        public int BMS1_BMS2 { get; set; }
        /// <summary>
        /// BMS3_BMS4
        /// </summary>
        public int BMS3_BMS4 { get; set; }
        /// <summary>
        /// BMS5_BMS6
        /// </summary>
        public int BMS5_BMS6 { get; set; }
        /// <summary>
        /// BMS7_BMS8
        /// </summary>
        public int BMS7_BMS8 { get; set; }
        /// <summary>
        /// BMS9_BMS10
        /// </summary>
        public int BMS9_BMS10 { get; set; }
        /// <summary>
        /// BMS_1綜合狀態
        /// </summary>
        public int BMS1_Status { get; set; } 
        /// <summary>
        /// BMS_2綜合狀態
        /// </summary>
        public int BMS2_Status { get; set; } 
        /// <summary>
        /// BMS_3綜合狀態
        /// </summary>
        public int BMS3_Status { get; set; } 
        /// <summary>
        /// BMS_4綜合狀態
        /// </summary>
        public int BMS4_Status { get; set; } 
        /// <summary>
        /// BMS_5綜合狀態
        /// </summary>
        public int BMS5_Status { get; set; } 
        /// <summary>
        /// BMS_6綜合狀態
        /// </summary>
        public int BMS6_Status { get; set; } 
        /// <summary>
        /// BMS_7綜合狀態
        /// </summary>
        public int BMS7_Status { get; set; } 
        /// <summary>
        /// BMS_8綜合狀態
        /// </summary>
        public int BMS8_Status { get; set; } 
        /// <summary>
        /// BMS_9綜合狀態
        /// </summary>
        public int BMS9_Status { get; set; } 
        /// <summary>
        /// BMS_10綜合狀態
        /// </summary>
        public int BMS10_Status { get; set; } 

    }
}
