using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS_TCP_Server.Modules
{
    public class BATT0403Data : BATTModule
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
        #region BMS_mah_H
        /// <summary>
        /// BMS1_mah_H
        /// </summary>
        public decimal BMS1_mah_H { get; set; }
        /// <summary>
        /// BMS_mah_H
        /// </summary>
        public decimal BMS2_mah_H { get; set; }
        /// <summary>
        /// BMS_mah_H
        /// </summary>
        public decimal BMS3_mah_H { get; set; }
        /// <summary>
        /// BMS_mah_H
        /// </summary>
        public decimal BMS4_mah_H { get; set; }
        /// <summary>
        /// BMS_mah_H
        /// </summary>
        public decimal BMS5_mah_H { get; set; }
        /// <summary>
        /// BMS_mah_H
        /// </summary>
        public decimal BMS6_mah_H { get; set; }
        /// <summary>
        /// BMS_mah_H
        /// </summary>
        public decimal BMS7_mah_H { get; set; }
        /// <summary>
        /// BMS_mah_H
        /// </summary>
        public decimal BMS8_mah_H { get; set; }
        /// <summary>
        /// BMS_mah_H
        /// </summary>
        public decimal BMS9_mah_H { get; set; }
        /// <summary>
        /// BMS_mah_H
        /// </summary>
        public decimal BMS10_mah_H { get; set; }
        #endregion
        #region BMS_mah_L
        /// <summary>
        /// BMS1_mah_L
        /// </summary>
        public decimal BMS1_mah_L { get; set; }
        /// <summary>
        /// BMS_mah_L
        /// </summary>
        public decimal BMS2_mah_L { get; set; }
        /// <summary>
        /// BMS_mah_L
        /// </summary>
        public decimal BMS3_mah_L { get; set; }
        /// <summary>
        /// BMS_mah_L
        /// </summary>
        public decimal BMS4_mah_L { get; set; }
        /// <summary>
        /// BMS_mah_L
        /// </summary>
        public decimal BMS5_mah_L { get; set; }
        /// <summary>
        /// BMS_mah_L
        /// </summary>
        public decimal BMS6_mah_L { get; set; }
        /// <summary>
        /// BMS_mah_L
        /// </summary>
        public decimal BMS7_mah_L { get; set; }
        /// <summary>
        /// BMS_mah_L
        /// </summary>
        public decimal BMS8_mah_L { get; set; }
        /// <summary>
        /// BMS_mah_L
        /// </summary>
        public decimal BMS9_mah_L { get; set; }
        /// <summary>
        /// BMS_mah_L
        /// </summary>
        public decimal BMS10_mah_L { get; set; }
        #endregion
        #region 告警
        /// <summary>
        /// OV告警電池狀態
        /// </summary>
        public int Battery_OV_Alarm { get; set; }
        /// <summary>
        /// UV告警電池狀態
        /// </summary>
        public int Battery_UV_Alarm { get; set; }
        /// <summary>
        /// DIS_H溫度告警
        /// </summary>
        public int Battery_DIS_H_Alarm { get; set; }
        /// <summary>
        /// DIS_L溫度告警
        /// </summary>
        public int Battery_DIS_L_Alarm { get; set; }
        /// <summary>
        /// CHG_H溫度告警
        /// </summary>
        public int Battery_CHG_H_Alarm { get; set; }
        /// <summary>
        /// CHG_L溫度告警
        /// </summary>
        public int Battery_CHG_L_Alarm { get; set; }
        /// <summary>
        /// DIS告警電流狀態(A1)
        /// </summary>
        public int DIS_A1_W { get; set; }
        /// <summary>
        /// CHG告警電流狀態(A1)
        /// </summary>
        public int CHG_A1_W { get; set; }
        /// <summary>
        /// DIS告警電流狀態(A2)
        /// </summary>
        public int DIS_A2_W { get; set; }
        /// <summary>
        /// CHG告警電流狀態(A2)
        /// </summary>
        public int CHG_A2_W { get; set; }
        /// <summary>
        /// BATT_OVW
        /// </summary>
        public int BATT_OVW { get; set; }
        /// <summary>
        /// BATT_UVW
        /// </summary>
        public int BATT_UVW { get; set; }
        #endregion
        #region 保護
        /// <summary>
        /// OV保護電池狀態
        /// </summary>
        public int Battery_OV_Protection { get; set; }
        /// <summary>
        /// UV保護電池狀態
        /// </summary>
        public int Battery_UV_Protection { get; set; }
        /// <summary>
        /// DIS_H溫度保護
        /// </summary>
        public int Battery_DIS_H_Protection { get; set; }
        /// <summary>
        /// DIS_L溫度保護
        /// </summary>
        public int Battery_DIS_L_Protection { get; set; }
        /// <summary>
        /// CHG_H溫度保護
        /// </summary>
        public int Battery_CHG_H_Protection { get; set; }
        /// <summary>
        /// CHG_L溫度保護
        /// </summary>
        public int Battery_CHG_L_Protection { get; set; }
        /// <summary>
        /// DIS保護電流狀態(A1)
        /// </summary>
        public int DIS_A1_P { get; set; }
        /// <summary>
        /// CHG保護電流狀態(A1)
        /// </summary>
        public int CHG_A1_P { get; set; }
        /// <summary>
        /// DIS保護電流狀態(A2)
        /// </summary>
        public int DIS_A2_P { get; set; }
        /// <summary>
        /// CHG保護電流狀態(A2)
        /// </summary>
        public int CHG_A2_P { get; set; }
        /// <summary>
        /// BATT_OVP
        /// </summary>
        public int BATT_OVP { get; set; }
        #endregion
        #region 狀態
        /// <summary>
        /// 溫度線脫落
        /// </summary>
        public int Temp_Fall_Off { get; set; }
        /// <summary>
        /// DI狀態
        /// </summary>
        public int DI_Status { get; set; } 
        #endregion
    }
}
