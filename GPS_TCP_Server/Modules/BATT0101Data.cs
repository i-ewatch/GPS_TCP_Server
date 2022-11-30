using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS_TCP_Server.Modules
{
    public class BATT0101Data
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
                return Convert.ToDateTime($"{year}/{month}/{day} {hour}:{minute}:{second}").AddHours(UTC);
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
        public decimal BMS_OBU_BUS_VOLT { get; set; }
        public decimal BMS_OBU1_PACK_VOLT { get; set; }
        public decimal BMS_OBU2_PACK_VOLT { get; set; }
        public decimal BMS_OBU_BUS_CURR { get; set; }
        public decimal BMS_OBU1_CURR { get; set; }
        public decimal BMS_OBU2_CURR { get; set; }
        public decimal BMS_OBU1_SOC { get; set; }
        public decimal BMS_OBU2_SOC { get; set; }
        public decimal BMS_OBU1_SOH { get; set; }
        public decimal BMS_OBU2_SOH { get; set; }
        public decimal BMS_OBU1_MAX_CELL_VOLT { get; set; }
        public decimal BMS_OBU1_MIN_CELL_VOLT { get; set; }
        public decimal BMS_OBU2_MAX_CELL_VOLT { get; set; }
        public decimal BMS_OBU2_MIN_CELL_VOLT { get; set; }
        public decimal BMS_OBU1_MAX_CELL_TEMP { get; set; }
        public decimal BMS_OBU1_MIN_CELL_TEMP { get; set; }
        public decimal BMS_OBU2_MAX_CELL_TEMP { get; set; }
        public decimal BMS_OBU2_MIN_CELL_TEMP { get; set; }
        public int BMS_FaultNUM_G1 { get; set; }
        public int BMS_FaultNUM_G2 { get; set; }
        public int BMS_FaultNUM_G3 { get; set; }
        public int BMS_FaultNUM_G4 { get; set; }
        public int EPT_Status { get; set; }
        public int BP_OBU_Enable_Control { get; set; }
        public int BP_OBU_Output_Control { get; set; }
        public int BP_OBU_Operation_State_Output_Control_Status { get; set; }
        public int BP_OBU_HV_Control_Status { get; set; }
        public int BP_OBU1_Warning_G1_G2 { get; set; }
        public int BP_OBU1_Warning_G3_Fault_G1 { get; set; }
        public int BP_OBU1_Fault_G2_G3 { get; set; }
        public int BP_OBU1_Fault_G4 { get; set; }
        public int BP_OBU2_Warning_G1_G2 { get; set; }
        public int BP_OBU2_Warning_G3_Fault_G1 { get; set; }
        public int BP_OBU2_Fault_G2_G3 { get; set; }
        public int BP_OBU2_Fault_G4 { get; set; }
    }
}
