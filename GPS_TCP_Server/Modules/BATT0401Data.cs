using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS_TCP_Server.Modules
{
    public class BATT0401Data : BATTModule
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
        /// 電池總電壓(0.01)
        /// </summary>
        public decimal BATTVoltage { get; set; }
        /// <summary>
        /// 充電電流(0.01)
        /// </summary>
        public decimal ChargeCurrent { get; set; }
        /// <summary>
        /// 放電電流(0.01)
        /// </summary>
        public decimal DischargeCurrent { get; set; }
        /// <summary>
        /// 電池總容量SOC(%)
        /// </summary>
        public decimal BatteryCapSOC { get; set; }
        /// <summary>
        /// mah_H
        /// </summary>
        public decimal mah_H { get; set; }
        /// <summary>
        /// mah_L
        /// </summary>
        public decimal mah_L { get; set; }
        #region 電池充電電流
        /// <summary>
        /// 電池充電電流1(0.01)
        /// </summary>
        public decimal Battery_Charge_Current1 { get; set; }
        /// <summary>
        /// 電池充電電流2(0.01)
        /// </summary>
        public decimal Battery_Charge_Current2 { get; set; }
        /// <summary>
        /// 電池充電電流3(0.01)
        /// </summary>
        public decimal Battery_Charge_Current3 { get; set; }
        /// <summary>
        /// 電池充電電流4(0.01)
        /// </summary>
        public decimal Battery_Charge_Current4 { get; set; }
        /// <summary>
        /// 電池充電電流5(0.01)
        /// </summary>
        public decimal Battery_Charge_Current5 { get; set; }
        /// <summary>
        /// 電池充電電流6(0.01)
        /// </summary>
        public decimal Battery_Charge_Current6 { get; set; }
        /// <summary>
        /// 電池充電電流7(0.01)
        /// </summary>
        public decimal Battery_Charge_Current7 { get; set; }
        /// <summary>
        /// 電池充電電流8(0.01)
        /// </summary>
        public decimal Battery_Charge_Current8 { get; set; }
        /// <summary>
        /// 電池充電電流9(0.01)
        /// </summary>
        public decimal Battery_Charge_Current9 { get; set; }
        /// <summary>
        /// 電池充電電流10(0.01)
        /// </summary>
        public decimal Battery_Charge_Current10 { get; set; }
        #endregion
        #region 電池放電電流
        /// <summary>
        /// 電池放電電流1(0.01)
        /// </summary>
        public decimal Battery_Discharge_Current1 { get; set; }
        /// <summary>
        /// 電池放電電流2(0.01)
        /// </summary>
        public decimal Battery_Discharge_Current2 { get; set; }
        /// <summary>
        /// 電池放電電流3(0.01)
        /// </summary>
        public decimal Battery_Discharge_Current3 { get; set; }
        /// <summary>
        /// 電池放電電流4(0.01)
        /// </summary>
        public decimal Battery_Discharge_Current4 { get; set; }
        /// <summary>
        /// 電池放電電流5(0.01)
        /// </summary>
        public decimal Battery_Discharge_Current5 { get; set; }
        /// <summary>
        /// 電池放電電流6(0.01)
        /// </summary>
        public decimal Battery_Discharge_Current6 { get; set; }
        /// <summary>
        /// 電池放電電流7(0.01)
        /// </summary>
        public decimal Battery_Discharge_Current7 { get; set; }
        /// <summary>
        /// 電池放電電流8(0.01)
        /// </summary>
        public decimal Battery_Discharge_Current8 { get; set; }
        /// <summary>
        /// 電池放電電流9(0.01)
        /// </summary>
        public decimal Battery_Discharge_Current9 { get; set; }
        /// <summary>
        /// 電池放電電流10(0.01)
        /// </summary>
        public decimal Battery_Discharge_Current10 { get; set; }
        #endregion
        #region 電池總電壓
        /// <summary>
        /// 電池總電壓1(0.01)
        /// </summary>
        public decimal Battery_TotalVoltage1 { get; set; }
        /// <summary>
        /// 電池總電壓2(0.01)
        /// </summary>
        public decimal Battery_TotalVoltage2 { get; set; }
        /// <summary>
        /// 電池總電壓3(0.01)
        /// </summary>
        public decimal Battery_TotalVoltage3 { get; set; }
        /// <summary>
        /// 電池總電壓4(0.01)
        /// </summary>
        public decimal Battery_TotalVoltage4 { get; set; }
        /// <summary>
        /// 電池總電壓5(0.01)
        /// </summary>
        public decimal Battery_TotalVoltage5 { get; set; }
        /// <summary>
        /// 電池總電壓6(0.01)
        /// </summary>
        public decimal Battery_TotalVoltage6 { get; set; }
        /// <summary>
        /// 電池總電壓7(0.01)
        /// </summary>
        public decimal Battery_TotalVoltage7 { get; set; }
        /// <summary>
        /// 電池總電壓8(0.01)
        /// </summary>
        public decimal Battery_TotalVoltage8 { get; set; }
        /// <summary>
        /// 電池總電壓9(0.01)
        /// </summary>
        public decimal Battery_TotalVoltage9 { get; set; }
        /// <summary>
        /// 電池總電壓10(0.01)
        /// </summary>
        public decimal Battery_TotalVoltage10 { get; set; }
        #endregion
    }
}
