using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS_TCP_Server.Modules
{
    public class BATT0402Data : BATTModule
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
        #region 電池最大Cell電壓
        /// <summary>
        /// 電池最大Cell電壓1(0.001)
        /// </summary>
        public decimal Battery_Max_Cell_Voltage1 { get; set; }
        /// <summary>
        /// 電池最大Cell電壓2(0.001)
        /// </summary>
        public decimal Battery_Max_Cell_Voltage2 { get; set; }
        /// <summary>
        /// 電池最大Cell電壓3(0.001)
        /// </summary>
        public decimal Battery_Max_Cell_Voltage3 { get; set; }
        /// <summary>
        /// 電池最大Cell電壓4(0.001)
        /// </summary>
        public decimal Battery_Max_Cell_Voltage4 { get; set; }
        /// <summary>
        /// 電池最大Cell電壓5(0.001)
        /// </summary>
        public decimal Battery_Max_Cell_Voltage5 { get; set; }
        /// <summary>
        /// 電池最大Cell電壓6(0.001)
        /// </summary>
        public decimal Battery_Max_Cell_Voltage6 { get; set; }
        /// <summary>
        /// 電池最大Cell電壓7(0.001)
        /// </summary>
        public decimal Battery_Max_Cell_Voltage7 { get; set; }
        /// <summary>
        /// 電池最大Cell電壓8(0.001)
        /// </summary>
        public decimal Battery_Max_Cell_Voltage8 { get; set; }
        /// <summary>
        /// 電池最大Cell電壓9(0.001)
        /// </summary>
        public decimal Battery_Max_Cell_Voltage9 { get; set; }
        /// <summary>
        /// 電池最大Cell電壓10(0.001)
        /// </summary>
        public decimal Battery_Max_Cell_Voltage10 { get; set; }
        #endregion
        #region 電池最小Cell電壓
        /// <summary>
        /// 電池最小Cell電壓1(0.001)
        /// </summary>
        public decimal Battery_Min_Cell_Voltage1 { get; set; }
        /// <summary>
        /// 電池最小Cell電壓2(0.001)
        /// </summary>
        public decimal Battery_Min_Cell_Voltage2 { get; set; }
        /// <summary>
        /// 電池最小Cell電壓3(0.001)
        /// </summary>
        public decimal Battery_Min_Cell_Voltage3 { get; set; }
        /// <summary>
        /// 電池最小Cell電壓4(0.001)
        /// </summary>
        public decimal Battery_Min_Cell_Voltage4 { get; set; }
        /// <summary>
        /// 電池最小Cell電壓5(0.001)
        /// </summary>
        public decimal Battery_Min_Cell_Voltage5 { get; set; }
        /// <summary>
        /// 電池最小Cell電壓6(0.001)
        /// </summary>
        public decimal Battery_Min_Cell_Voltage6 { get; set; }
        /// <summary>
        /// 電池最小Cell電壓7(0.001)
        /// </summary>
        public decimal Battery_Min_Cell_Voltage7 { get; set; }
        /// <summary>
        /// 電池最小Cell電壓8(0.001)
        /// </summary>
        public decimal Battery_Min_Cell_Voltage8 { get; set; }
        /// <summary>
        /// 電池最小Cell電壓9(0.001)
        /// </summary>
        public decimal Battery_Min_Cell_Voltage9 { get; set; }
        /// <summary>
        /// 電池最小Cell電壓10(0.001)
        /// </summary>
        public decimal Battery_Min_Cell_Voltage10 { get; set; }
        #endregion
        #region 電池最高溫度
        /// <summary>
        /// 電池1最高溫度(0.01)
        /// </summary>
        public decimal Battery_Max_Temp1 { get; set; }
        /// <summary>
        /// 電池2最高溫度(0.01)
        /// </summary>
        public decimal Battery_Max_Temp2 { get; set; }
        /// <summary>
        /// 電池3最高溫度(0.01)
        /// </summary>
        public decimal Battery_Max_Temp3 { get; set; }
        /// <summary>
        /// 電池4最高溫度(0.01)
        /// </summary>
        public decimal Battery_Max_Temp4 { get; set; }
        /// <summary>
        /// 電池5最高溫度(0.01)
        /// </summary>
        public decimal Battery_Max_Temp5 { get; set; }
        /// <summary>
        /// 電池6最高溫度(0.01)
        /// </summary>
        public decimal Battery_Max_Temp6 { get; set; }
        /// <summary>
        /// 電池7最高溫度(0.01)
        /// </summary>
        public decimal Battery_Max_Temp7 { get; set; }
        /// <summary>
        /// 電池8最高溫度(0.01)
        /// </summary>
        public decimal Battery_Max_Temp8 { get; set; }
        /// <summary>
        /// 電池9最高溫度(0.01)
        /// </summary>
        public decimal Battery_Max_Temp9 { get; set; }
        /// <summary>
        /// 電池10最高溫度(0.01)
        /// </summary>
        public decimal Battery_Max_Temp10 { get; set; }
        #endregion
        #region 電池最低溫度
        /// <summary>
        /// 電池1最低溫度(0.01)
        /// </summary>
        public decimal Battery_Min_Temp1 { get; set; }
        /// <summary>
        /// 電池2最低溫度(0.01)
        /// </summary>
        public decimal Battery_Min_Temp2 { get; set; }
        /// <summary>
        /// 電池3最低溫度(0.01)
        /// </summary>
        public decimal Battery_Min_Temp3 { get; set; }
        /// <summary>
        /// 電池4最低溫度(0.01)
        /// </summary>
        public decimal Battery_Min_Temp4 { get; set; }
        /// <summary>4
        /// 電池5最低溫度(0.01)
        /// </summary>
        public decimal Battery_Min_Temp5 { get; set; }
        /// <summary>
        /// 電池6最低溫度(0.01)
        /// </summary>
        public decimal Battery_Min_Temp6{ get; set; }
        /// <summary>
        /// 電池7最低溫度(0.01)
        /// </summary>
        public decimal Battery_Min_Temp7 { get; set; }
        /// <summary>
        /// 電池8最低溫度(0.01)
        /// </summary>
        public decimal Battery_Min_Temp8 { get; set; }
        /// <summary>
        /// 電池9最低溫度(0.01)
        /// </summary>
        public decimal Battery_Min_Temp9 { get; set; }
        /// <summary>
        /// 電池10最低溫度(0.01)
        /// </summary>
        public decimal Battery_Min_Temp10 { get; set; }
        #endregion
    }
}
