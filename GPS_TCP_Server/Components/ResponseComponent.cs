using GPS_TCP_Server.Methods;
using GPS_TCP_Server.Modules;
using Serilog;
using System;
using System.ComponentModel;
using System.Threading;

namespace GPS_TCP_Server.Components
{
    public partial class ResponseComponent : Field4Component
    {
        private string[] Data { get; set; }
        public ResponseComponent(SqlMethod sqlMethod, TCP_Listen_Method tCP_Listen_Method)
        {
            InitializeComponent();
            TCP_Listen_Method = tCP_Listen_Method;
            SqlMethod = sqlMethod;
        }

        public ResponseComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        protected override void AfterMyWorkStateChanged(object sender, EventArgs e)
        {
            if (myWorkState)
            {
                SqlMethod.CreateDataBase();
                ReadThread = new Thread(Analysis);
                ReadThread.Start();
            }
            else
            {
                if (ReadThread != null)
                {
                    ReadThread.Abort();
                }
            }
        }
        private void Analysis()
        {
            while (myWorkState)
            {
                TimeSpan timeSpan = DateTime.Now.Subtract(ReadTime);
                if (timeSpan.TotalSeconds >= 1)
                {
                    int Index = 0;
                    while (TCP_Listen_Method.Response.Count > 0)
                    {
                        try
                        {
                            if (Index <= 100)
                            {
                                Data = TCP_Listen_Method.Response.Dequeue();
                                if (Data != null)
                                {

                                    switch (Data[22])
                                    {
                                        case "0401":
                                            {
                                                if (Data.Length >= 59)
                                                {
                                                    BATT0401Data data = new BATT0401Data();
                                                    {
                                                        data.ttime = Data[1];
                                                        data.imei = Data[0].Substring(1, Data[0].Length - 1);
                                                        data.Longitude = Data[2];
                                                        data.Latitude = Data[3];
                                                        data.Speed = Convert.ToDecimal(Data[4]);
                                                        data.BattName = Data[21];
                                                        data.BATTVoltage = Convert.ToDecimal(Convert.ToDouble(Data[23]) * 0.01);
                                                        data.ChargeCurrent = Convert.ToDecimal(Convert.ToDouble(Data[24]) * 0.01);
                                                        data.DischargeCurrent = Convert.ToDecimal(Convert.ToDouble(Data[25]) * 0.01);
                                                        data.BatteryCapSOC = Convert.ToDecimal(Data[26]);
                                                        data.mah_H = Convert.ToDecimal(Data[27]);
                                                        data.mah_L = Convert.ToDecimal(Data[28]);
                                                        data.Battery_Charge_Current1 = Convert.ToDecimal(Convert.ToDouble(Data[29]) * 0.01);
                                                        data.Battery_Charge_Current2 = Convert.ToDecimal(Convert.ToDouble(Data[30]) * 0.01);
                                                        data.Battery_Charge_Current3 = Convert.ToDecimal(Convert.ToDouble(Data[31]) * 0.01);
                                                        data.Battery_Charge_Current4 = Convert.ToDecimal(Convert.ToDouble(Data[32]) * 0.01);
                                                        data.Battery_Charge_Current5 = Convert.ToDecimal(Convert.ToDouble(Data[33]) * 0.01);
                                                        data.Battery_Charge_Current6 = Convert.ToDecimal(Convert.ToDouble(Data[34]) * 0.01);
                                                        data.Battery_Charge_Current7 = Convert.ToDecimal(Convert.ToDouble(Data[35]) * 0.01);
                                                        data.Battery_Charge_Current8 = Convert.ToDecimal(Convert.ToDouble(Data[36]) * 0.01);
                                                        data.Battery_Charge_Current9 = Convert.ToDecimal(Convert.ToDouble(Data[37]) * 0.01);
                                                        data.Battery_Charge_Current10 = Convert.ToDecimal(Convert.ToDouble(Data[38]) * 0.01);
                                                        data.Battery_Discharge_Current1 = Convert.ToDecimal(Convert.ToDouble(Data[39]) * 0.01);
                                                        data.Battery_Discharge_Current2 = Convert.ToDecimal(Convert.ToDouble(Data[40]) * 0.01);
                                                        data.Battery_Discharge_Current3 = Convert.ToDecimal(Convert.ToDouble(Data[41]) * 0.01);
                                                        data.Battery_Discharge_Current4 = Convert.ToDecimal(Convert.ToDouble(Data[42]) * 0.01);
                                                        data.Battery_Discharge_Current5 = Convert.ToDecimal(Convert.ToDouble(Data[43]) * 0.01);
                                                        data.Battery_Discharge_Current6 = Convert.ToDecimal(Convert.ToDouble(Data[44]) * 0.01);
                                                        data.Battery_Discharge_Current7 = Convert.ToDecimal(Convert.ToDouble(Data[45]) * 0.01);
                                                        data.Battery_Discharge_Current8 = Convert.ToDecimal(Convert.ToDouble(Data[46]) * 0.01);
                                                        data.Battery_Discharge_Current9 = Convert.ToDecimal(Convert.ToDouble(Data[47]) * 0.01);
                                                        data.Battery_Discharge_Current10 = Convert.ToDecimal(Convert.ToDouble(Data[48]) * 0.01);
                                                        data.Battery_TotalVoltage1 = Convert.ToDecimal(Convert.ToDouble(Data[49]) * 0.01);
                                                        data.Battery_TotalVoltage2 = Convert.ToDecimal(Convert.ToDouble(Data[50]) * 0.01);
                                                        data.Battery_TotalVoltage3 = Convert.ToDecimal(Convert.ToDouble(Data[51]) * 0.01);
                                                        data.Battery_TotalVoltage4 = Convert.ToDecimal(Convert.ToDouble(Data[52]) * 0.01);
                                                        data.Battery_TotalVoltage5 = Convert.ToDecimal(Convert.ToDouble(Data[53]) * 0.01);
                                                        data.Battery_TotalVoltage6 = Convert.ToDecimal(Convert.ToDouble(Data[54]) * 0.01);
                                                        data.Battery_TotalVoltage7 = Convert.ToDecimal(Convert.ToDouble(Data[55]) * 0.01);
                                                        data.Battery_TotalVoltage8 = Convert.ToDecimal(Convert.ToDouble(Data[56]) * 0.01);
                                                        data.Battery_TotalVoltage9 = Convert.ToDecimal(Convert.ToDouble(Data[57]) * 0.01);
                                                        data.Battery_TotalVoltage10 = Convert.ToDecimal(Convert.ToDouble(Data[58]) * 0.01);
                                                    }
                                                    SqlMethod.InserterBATT0401(data);
                                                    SqlMethod.UpdateBATT0401web(data);
                                                }
                                                else
                                                {
                                                    Log.Error($"0401封包長度錯誤(需59格) 封包 {Data.Length}");
                                                }
                                            }
                                            break;
                                        case "0402":
                                            {
                                                if (Data.Length >= 63)
                                                {
                                                    BATT0402Data data = new BATT0402Data();
                                                    {
                                                        data.ttime = Data[1];
                                                        data.imei = Data[0].Substring(1, Data[0].Length - 1);
                                                        data.Longitude = Data[2];
                                                        data.Latitude = Data[3];
                                                        data.Speed = Convert.ToDecimal(Data[4]);
                                                        data.BattName = Data[21];
                                                        data.Battery_Max_Cell_Voltage1 = Convert.ToDecimal(Convert.ToDouble(Data[23]) * 0.001);
                                                        data.Battery_Min_Cell_Voltage1 = Convert.ToDecimal(Convert.ToDouble(Data[24]) * 0.001);
                                                        data.Battery_Max_Cell_Voltage2 = Convert.ToDecimal(Convert.ToDouble(Data[25]) * 0.001);
                                                        data.Battery_Min_Cell_Voltage2 = Convert.ToDecimal(Convert.ToDouble(Data[26]) * 0.001);
                                                        data.Battery_Max_Cell_Voltage3 = Convert.ToDecimal(Convert.ToDouble(Data[27]) * 0.001);
                                                        data.Battery_Min_Cell_Voltage3 = Convert.ToDecimal(Convert.ToDouble(Data[28]) * 0.001);
                                                        data.Battery_Max_Cell_Voltage4 = Convert.ToDecimal(Convert.ToDouble(Data[29]) * 0.001);
                                                        data.Battery_Min_Cell_Voltage4 = Convert.ToDecimal(Convert.ToDouble(Data[30]) * 0.001);
                                                        data.Battery_Max_Cell_Voltage5 = Convert.ToDecimal(Convert.ToDouble(Data[31]) * 0.001);
                                                        data.Battery_Min_Cell_Voltage5 = Convert.ToDecimal(Convert.ToDouble(Data[32]) * 0.001);
                                                        data.Battery_Max_Cell_Voltage6 = Convert.ToDecimal(Convert.ToDouble(Data[33]) * 0.001);
                                                        data.Battery_Min_Cell_Voltage6 = Convert.ToDecimal(Convert.ToDouble(Data[34]) * 0.001);
                                                        data.Battery_Max_Cell_Voltage7 = Convert.ToDecimal(Convert.ToDouble(Data[35]) * 0.001);
                                                        data.Battery_Min_Cell_Voltage7 = Convert.ToDecimal(Convert.ToDouble(Data[36]) * 0.001);
                                                        data.Battery_Max_Cell_Voltage8 = Convert.ToDecimal(Convert.ToDouble(Data[37]) * 0.001);
                                                        data.Battery_Min_Cell_Voltage8 = Convert.ToDecimal(Convert.ToDouble(Data[38]) * 0.001);
                                                        data.Battery_Max_Cell_Voltage9 = Convert.ToDecimal(Convert.ToDouble(Data[39]) * 0.001);
                                                        data.Battery_Min_Cell_Voltage9 = Convert.ToDecimal(Convert.ToDouble(Data[40]) * 0.001);
                                                        data.Battery_Max_Cell_Voltage10 = Convert.ToDecimal(Convert.ToDouble(Data[41]) * 0.001);
                                                        data.Battery_Min_Cell_Voltage10 = Convert.ToDecimal(Convert.ToDouble(Data[42]) * 0.001);
                                                        data.Battery_Max_Temp1 = Convert.ToDecimal(Convert.ToDouble(Data[43]) * 0.01);
                                                        data.Battery_Min_Temp1 = Convert.ToDecimal(Convert.ToDouble(Data[44]) * 0.01);
                                                        data.Battery_Max_Temp2 = Convert.ToDecimal(Convert.ToDouble(Data[45]) * 0.01);
                                                        data.Battery_Min_Temp2 = Convert.ToDecimal(Convert.ToDouble(Data[46]) * 0.01);
                                                        data.Battery_Max_Temp3 = Convert.ToDecimal(Convert.ToDouble(Data[47]) * 0.01);
                                                        data.Battery_Min_Temp3 = Convert.ToDecimal(Convert.ToDouble(Data[48]) * 0.01);
                                                        data.Battery_Max_Temp4 = Convert.ToDecimal(Convert.ToDouble(Data[49]) * 0.01);
                                                        data.Battery_Min_Temp4 = Convert.ToDecimal(Convert.ToDouble(Data[50]) * 0.01);
                                                        data.Battery_Max_Temp5 = Convert.ToDecimal(Convert.ToDouble(Data[51]) * 0.01);
                                                        data.Battery_Min_Temp5 = Convert.ToDecimal(Convert.ToDouble(Data[52]) * 0.01);
                                                        data.Battery_Max_Temp6 = Convert.ToDecimal(Convert.ToDouble(Data[53]) * 0.01);
                                                        data.Battery_Min_Temp6 = Convert.ToDecimal(Convert.ToDouble(Data[54]) * 0.01);
                                                        data.Battery_Max_Temp7 = Convert.ToDecimal(Convert.ToDouble(Data[55]) * 0.01);
                                                        data.Battery_Min_Temp7 = Convert.ToDecimal(Convert.ToDouble(Data[56]) * 0.01);
                                                        data.Battery_Max_Temp8 = Convert.ToDecimal(Convert.ToDouble(Data[57]) * 0.01);
                                                        data.Battery_Min_Temp8 = Convert.ToDecimal(Convert.ToDouble(Data[58]) * 0.01);
                                                        data.Battery_Max_Temp9 = Convert.ToDecimal(Convert.ToDouble(Data[59]) * 0.01);
                                                        data.Battery_Min_Temp9 = Convert.ToDecimal(Convert.ToDouble(Data[60]) * 0.01);
                                                        data.Battery_Max_Temp10 = Convert.ToDecimal(Convert.ToDouble(Data[61]) * 0.01);
                                                        data.Battery_Min_Temp10 = Convert.ToDecimal(Convert.ToDouble(Data[62]) * 0.01);
                                                    }
                                                    SqlMethod.InserterBATT0402(data);
                                                    SqlMethod.UpdateBATT0402web(data);
                                                }
                                                else
                                                {
                                                    Log.Error($"0402封包長度錯誤(需63格) 封包 {Data.Length}");
                                                }
                                            }
                                            break;
                                        case "0403":
                                            {
                                                if (Data.Length >= 68)
                                                {
                                                    BATT0403Data data = new BATT0403Data();
                                                    {
                                                        data.ttime = Data[1];
                                                        data.imei = Data[0].Substring(1, Data[0].Length - 1);
                                                        data.Longitude = Data[2];
                                                        data.Latitude = Data[3];
                                                        data.Speed = Convert.ToDecimal(Data[4]);
                                                        data.BattName = Data[21];
                                                        data.BMS1_mah_H = Convert.ToInt32(Data[23]);
                                                        data.BMS1_mah_L = Convert.ToInt32(Data[24]);
                                                        data.BMS2_mah_H = Convert.ToInt32(Data[25]);
                                                        data.BMS2_mah_L = Convert.ToInt32(Data[26]);
                                                        data.BMS3_mah_H = Convert.ToInt32(Data[27]);
                                                        data.BMS3_mah_L = Convert.ToInt32(Data[28]);
                                                        data.BMS4_mah_H = Convert.ToInt32(Data[29]);
                                                        data.BMS4_mah_L = Convert.ToInt32(Data[30]);
                                                        data.BMS5_mah_H = Convert.ToInt32(Data[31]);
                                                        data.BMS5_mah_L = Convert.ToInt32(Data[32]);
                                                        data.BMS6_mah_H = Convert.ToInt32(Data[33]);
                                                        data.BMS6_mah_L = Convert.ToInt32(Data[34]);
                                                        data.BMS7_mah_H = Convert.ToInt32(Data[35]);
                                                        data.BMS7_mah_L = Convert.ToInt32(Data[36]);
                                                        data.BMS8_mah_H = Convert.ToInt32(Data[37]);
                                                        data.BMS8_mah_L = Convert.ToInt32(Data[38]);
                                                        data.BMS9_mah_H = Convert.ToInt32(Data[39]);
                                                        data.BMS9_mah_L = Convert.ToInt32(Data[40]);
                                                        data.BMS10_mah_H = Convert.ToInt32(Data[41]);
                                                        data.BMS10_mah_L = Convert.ToInt32(Data[42]);
                                                        data.Battery_OV_Alarm = Convert.ToInt32(Data[43]);
                                                        data.Battery_UV_Alarm = Convert.ToInt32(Data[44]);
                                                        data.Battery_DIS_H_Alarm = Convert.ToInt32(Data[45]);
                                                        data.Battery_DIS_L_Alarm = Convert.ToInt32(Data[46]);
                                                        data.Battery_OV_Protection = Convert.ToInt32(Data[47]);
                                                        data.Battery_UV_Protection = Convert.ToInt32(Data[48]);
                                                        data.Battery_DIS_H_Protection = Convert.ToInt32(Data[49]);
                                                        data.Battery_DIS_L_Protection = Convert.ToInt32(Data[50]);
                                                        data.Battery_CHG_H_Alarm = Convert.ToInt32(Data[51]);
                                                        data.Battery_CHG_L_Alarm = Convert.ToInt32(Data[52]);
                                                        data.Battery_CHG_H_Protection = Convert.ToInt32(Data[53]);
                                                        data.Battery_CHG_L_Protection = Convert.ToInt32(Data[54]);
                                                        data.Temp_Fall_Off = Convert.ToInt32(Data[55]);
                                                        data.DI_Status = Convert.ToInt32(Data[56]);
                                                        data.DIS_A1_W = Convert.ToInt32(Data[57]);
                                                        data.DIS_A1_P = Convert.ToInt32(Data[58]);
                                                        data.CHG_A1_W = Convert.ToInt32(Data[59]);
                                                        data.CHG_A1_P = Convert.ToInt32(Data[60]);
                                                        data.DIS_A2_W = Convert.ToInt32(Data[61]);
                                                        data.DIS_A2_P = Convert.ToInt32(Data[62]);
                                                        data.CHG_A2_W = Convert.ToInt32(Data[63]);
                                                        data.CHG_A2_P = Convert.ToInt32(Data[64]);
                                                        data.BATT_OVW = Convert.ToInt32(Data[65]);
                                                        data.BATT_OVP = Convert.ToInt32(Data[66]);
                                                        data.BATT_UVW = Convert.ToInt32(Data[67]);
                                                    }
                                                    SqlMethod.InserterBATT0403(data);
                                                    SqlMethod.UpdateBATT0403web(data);
                                                }
                                                else
                                                {
                                                    Log.Error($"0403封包長度錯誤(需68格) 封包 {Data.Length}");
                                                }
                                            }
                                            break;
                                        case "0404":
                                            {
                                                if (Data.Length >= 39)
                                                {
                                                    BATT0404Data data = new BATT0404Data();
                                                    {
                                                        data.ttime = Data[1];
                                                        data.imei = Data[0].Substring(1, Data[0].Length - 1);
                                                        data.Longitude = Data[2];
                                                        data.Latitude = Data[3];
                                                        data.Speed = Convert.ToDecimal(Data[4]);
                                                        data.BattName = Data[21];
                                                        data.BATT_UVP = Convert.ToInt32(Data[23]);
                                                        data.BMS1_BMS2 = Convert.ToInt32(Data[24]);
                                                        data.BMS3_BMS4 = Convert.ToInt32(Data[25]);
                                                        data.BMS5_BMS6 = Convert.ToInt32(Data[26]);
                                                        data.BMS7_BMS8 = Convert.ToInt32(Data[27]);
                                                        data.BMS9_BMS10 = Convert.ToInt32(Data[28]);
                                                        data.BMS1_Status = Convert.ToInt32(Data[29]);
                                                        data.BMS2_Status = Convert.ToInt32(Data[30]);
                                                        data.BMS3_Status = Convert.ToInt32(Data[31]);
                                                        data.BMS4_Status = Convert.ToInt32(Data[32]);
                                                        data.BMS5_Status = Convert.ToInt32(Data[33]);
                                                        data.BMS6_Status = Convert.ToInt32(Data[34]);
                                                        data.BMS7_Status = Convert.ToInt32(Data[35]);
                                                        data.BMS8_Status = Convert.ToInt32(Data[36]);
                                                        data.BMS9_Status = Convert.ToInt32(Data[37]);
                                                        data.BMS10_Status = Convert.ToInt32(Data[38]);
                                                    }
                                                    SqlMethod.InserterBATT0404(data);
                                                    SqlMethod.UpdateBATT0404web(data);
                                                }
                                                else
                                                {
                                                    Log.Error($"0404封包長度錯誤(需39格) 封包 {Data.Length}");
                                                }
                                            }
                                            break;
                                    }
                                    Index++;
                                    Thread.Sleep(10);
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex, $"記錄錯誤  時間: {Data[1]}，封包類型: {Data[21]}-{Data[22]}");
                        }
                    }
                    ReadTime = DateTime.Now;
                }
                else
                {
                    Thread.Sleep(80);
                }
            }
        }
    }
}
