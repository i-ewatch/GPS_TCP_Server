using Dapper;
using GPS_TCP_Server.Configuration;
using GPS_TCP_Server.Modules;
using Serilog;
using System;
using System.Data.SqlClient;
using System.Threading;

namespace GPS_TCP_Server.Methods
{
    public class SqlMethod
    {
        /// <summary>
        /// 冰機資料庫連接物件
        /// </summary>
        protected SqlConnectionStringBuilder scsb { get; set; } = null;
        protected SqlConnectionStringBuilder Mscsb { get; set; } = null;
        public SqlMethod(SystemSetting systemSetting)
        {
            scsb = new SqlConnectionStringBuilder
            {
                DataSource = systemSetting.ServerIp,
                InitialCatalog = systemSetting.Database,
                UserID = systemSetting.UserId,
                Password = systemSetting.UserPwd
            };
            Mscsb = new SqlConnectionStringBuilder
            {
                DataSource = systemSetting.ServerIp,
                InitialCatalog = "master",
                UserID = systemSetting.UserId,
                Password = systemSetting.UserPwd
            };
        }
        #region 建立資料庫與資料表
        /// <summary>
        /// 建立資料庫與資料表
        /// </summary>
        public void CreateDataBase()
        {
            try
            {
                using (var conn = new SqlConnection(Mscsb.ConnectionString))
                {
                    string databaseSql = $"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name='GPSDB')  CREATE DATABASE [GPSDB]";
                    #region BATTWeb
                    string battwebSql = $"USE [GPSDB]; IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='BATTWeb') CREATE TABLE [BATTWeb] (" +
                                   $" [ttime] NVARCHAR(14) NOT NULL" +
                                   $",[ttimen] DATETIME NOT NULL" +
                                   $",[imei] NVARCHAR(50) NOT NULL" +
                                   $",[Longitude] NVARCHAR(50) NOT NULL DEFAULT ''" +
                                   $",[Latitude] NVARCHAR(50) NOT NULL DEFAULT ''" +
                                   $",[Speed] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[BattName] NVARCHAR(16) NOT NULL" +
                                   $",[BATTVoltage] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[ChargeCurrent] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[DischargeCurrent] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[BatteryCapSOC] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[mah_H] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[mah_L] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Charge_Current1] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Charge_Current2] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Charge_Current3] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Charge_Current4] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Charge_Current5] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Charge_Current6] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Charge_Current7] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Charge_Current8] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Charge_Current9] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Charge_Current10] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Discharge_Current1] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Discharge_Current2] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Discharge_Current3] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Discharge_Current4] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Discharge_Current5] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Discharge_Current6] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Discharge_Current7] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Discharge_Current8] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Discharge_Current9] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Discharge_Current10] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_TotalVoltage1] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_TotalVoltage2] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_TotalVoltage3] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_TotalVoltage4] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_TotalVoltage5] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_TotalVoltage6] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_TotalVoltage7] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_TotalVoltage8] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_TotalVoltage9] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_TotalVoltage10] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Max_Cell_Voltage1] Decimal(18,3) NOT NULL DEFAULT 0" +
                                   $",[Battery_Min_Cell_Voltage1] Decimal(18,3) NOT NULL DEFAULT 0" +
                                   $",[Battery_Max_Cell_Voltage2] Decimal(18,3) NOT NULL DEFAULT 0" +
                                   $",[Battery_Min_Cell_Voltage2] Decimal(18,3) NOT NULL DEFAULT 0" +
                                   $",[Battery_Max_Cell_Voltage3] Decimal(18,3) NOT NULL DEFAULT 0" +
                                   $",[Battery_Min_Cell_Voltage3] Decimal(18,3) NOT NULL DEFAULT 0" +
                                   $",[Battery_Max_Cell_Voltage4] Decimal(18,3) NOT NULL DEFAULT 0" +
                                   $",[Battery_Min_Cell_Voltage4] Decimal(18,3) NOT NULL DEFAULT 0" +
                                   $",[Battery_Max_Cell_Voltage5] Decimal(18,3) NOT NULL DEFAULT 0" +
                                   $",[Battery_Min_Cell_Voltage5] Decimal(18,3) NOT NULL DEFAULT 0" +
                                   $",[Battery_Max_Cell_Voltage6] Decimal(18,3) NOT NULL DEFAULT 0" +
                                   $",[Battery_Min_Cell_Voltage6] Decimal(18,3) NOT NULL DEFAULT 0" +
                                   $",[Battery_Max_Cell_Voltage7] Decimal(18,3) NOT NULL DEFAULT 0" +
                                   $",[Battery_Min_Cell_Voltage7] Decimal(18,3) NOT NULL DEFAULT 0" +
                                   $",[Battery_Max_Cell_Voltage8] Decimal(18,3) NOT NULL DEFAULT 0" +
                                   $",[Battery_Min_Cell_Voltage8] Decimal(18,3) NOT NULL DEFAULT 0" +
                                   $",[Battery_Max_Cell_Voltage9] Decimal(18,3) NOT NULL DEFAULT 0" +
                                   $",[Battery_Min_Cell_Voltage9] Decimal(18,3) NOT NULL DEFAULT 0" +
                                   $",[Battery_Max_Cell_Voltage10] Decimal(18,3) NOT NULL DEFAULT 0" +
                                   $",[Battery_Min_Cell_Voltage10] Decimal(18,3) NOT NULL DEFAULT 0" +
                                   $",[Battery_Max_Temp1] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Min_Temp1] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Max_Temp2] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Min_Temp2] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Max_Temp3] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Min_Temp3] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Max_Temp4] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Min_Temp4] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Max_Temp5] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Min_Temp5] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Max_Temp6] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Min_Temp6] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Max_Temp7] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Min_Temp7] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Max_Temp8] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Min_Temp8] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Max_Temp9] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Min_Temp9] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Max_Temp10] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[Battery_Min_Temp10] Decimal(18,2) NOT NULL DEFAULT 0" +
                                   $",[BMS1_mah_H] Decimal(18,0) NOT NULL DEFAULT 0" +
                                   $",[BMS1_mah_L] Decimal(18,0) NOT NULL DEFAULT 0" +
                                   $",[BMS2_mah_H] Decimal(18,0) NOT NULL DEFAULT 0" +
                                   $",[BMS2_mah_L] Decimal(18,0) NOT NULL DEFAULT 0" +
                                   $",[BMS3_mah_H] Decimal(18,0) NOT NULL DEFAULT 0" +
                                   $",[BMS3_mah_L] Decimal(18,0) NOT NULL DEFAULT 0" +
                                   $",[BMS4_mah_H] Decimal(18,0) NOT NULL DEFAULT 0" +
                                   $",[BMS4_mah_L] Decimal(18,0) NOT NULL DEFAULT 0" +
                                   $",[BMS5_mah_H] Decimal(18,0) NOT NULL DEFAULT 0" +
                                   $",[BMS5_mah_L] Decimal(18,0) NOT NULL DEFAULT 0" +
                                   $",[BMS6_mah_H] Decimal(18,0) NOT NULL DEFAULT 0" +
                                   $",[BMS6_mah_L] Decimal(18,0) NOT NULL DEFAULT 0" +
                                   $",[BMS7_mah_H] Decimal(18,0) NOT NULL DEFAULT 0" +
                                   $",[BMS7_mah_L] Decimal(18,0) NOT NULL DEFAULT 0" +
                                   $",[BMS8_mah_H] Decimal(18,0) NOT NULL DEFAULT 0" +
                                   $",[BMS8_mah_L] Decimal(18,0) NOT NULL DEFAULT 0" +
                                   $",[BMS9_mah_H] Decimal(18,0) NOT NULL DEFAULT 0" +
                                   $",[BMS9_mah_L] Decimal(18,0) NOT NULL DEFAULT 0" +
                                   $",[BMS10_mah_H] Decimal(18,0) NOT NULL DEFAULT 0" +
                                   $",[BMS10_mah_L] Decimal(18,0) NOT NULL DEFAULT 0" +
                                   $",[Battery_OV_Alarm] int NOT NULL DEFAULT 0" +
                                   $",[Battery_UV_Alarm] int NOT NULL DEFAULT 0" +
                                   $",[Battery_DIS_H_Alarm] int NOT NULL DEFAULT 0" +
                                   $",[Battery_DIS_L_Alarm] int NOT NULL DEFAULT 0" +
                                   $",[Battery_OV_Protection] int NOT NULL DEFAULT 0" +
                                   $",[Battery_UV_Protection] int NOT NULL DEFAULT 0" +
                                   $",[Battery_DIS_H_Protection] int NOT NULL DEFAULT 0" +
                                   $",[Battery_DIS_L_Protection] int NOT NULL DEFAULT 0" +
                                   $",[Battery_CHG_H_Alarm] int NOT NULL DEFAULT 0" +
                                   $",[Battery_CHG_L_Alarm] int NOT NULL DEFAULT 0" +
                                   $",[Battery_CHG_H_Protection] int NOT NULL DEFAULT 0" +
                                   $",[Battery_CHG_L_Protection] int NOT NULL DEFAULT 0" +
                                   $",[Temp_Fall_Off] int NOT NULL DEFAULT 0" +
                                   $",[DI_Status] int NOT NULL DEFAULT 0" +
                                   $",[DIS_A1_W] int NOT NULL DEFAULT 0" +
                                   $",[DIS_A1_P] int NOT NULL DEFAULT 0" +
                                   $",[CHG_A1_W] int NOT NULL DEFAULT 0" +
                                   $",[CHG_A1_P] int NOT NULL DEFAULT 0" +
                                   $",[DIS_A2_W] int NOT NULL DEFAULT 0" +
                                   $",[DIS_A2_P] int NOT NULL DEFAULT 0" +
                                   $",[CHG_A2_W] int NOT NULL DEFAULT 0" +
                                   $",[CHG_A2_P] int NOT NULL DEFAULT 0" +
                                   $",[BATT_OVW] int NOT NULL DEFAULT 0" +
                                   $",[BATT_OVP] int NOT NULL DEFAULT 0" +
                                   $",[BATT_UVW] int NOT NULL DEFAULT 0" +
                                   $",[BATT_UVP] int NOT NULL DEFAULT 0" +
                                   $",[BMS1_BMS2] int NOT NULL DEFAULT 0" +
                                   $",[BMS3_BMS4] int NOT NULL DEFAULT 0" +
                                   $",[BMS5_BMS6] int NOT NULL DEFAULT 0" +
                                   $",[BMS7_BMS8] int NOT NULL DEFAULT 0" +
                                   $",[BMS9_BMS10] int NOT NULL DEFAULT 0" +
                                   $",[BMS1_Status] int NOT NULL DEFAULT 0" +
                                   $",[BMS2_Status] int NOT NULL DEFAULT 0" +
                                   $",[BMS3_Status] int NOT NULL DEFAULT 0" +
                                   $",[BMS4_Status] int NOT NULL DEFAULT 0" +
                                   $",[BMS5_Status] int NOT NULL DEFAULT 0" +
                                   $",[BMS6_Status] int NOT NULL DEFAULT 0" +
                                   $",[BMS7_Status] int NOT NULL DEFAULT 0" +
                                   $",[BMS8_Status] int NOT NULL DEFAULT 0" +
                                   $",[BMS9_Status] int NOT NULL DEFAULT 0" +
                                   $",[BMS10_Status] int NOT NULL DEFAULT 0" +
                                   $",CONSTRAINT [PK_BATTWeb] PRIMARY KEY ([ttime],[ttimen],[imei],[BattName]))";
                    #endregion
                    #region BATT0401
                    string batt0401Sql = $"USE [GPSDB]; IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='BATT0401') CREATE TABLE [BATT0401] (" +
                                     $" [ttime] NVARCHAR(14) NOT NULL" +
                                     $",[ttimen] DATETIME NOT NULL" +
                                     $",[imei] NVARCHAR(50) NOT NULL" +
                                     $",[Longitude] NVARCHAR(50) NOT NULL DEFAULT ''" +
                                     $",[Latitude] NVARCHAR(50) NOT NULL DEFAULT ''" +
                                     $",[Speed] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[BattName] NVARCHAR(16) NOT NULL" +
                                     $",[BATTVoltage] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[ChargeCurrent] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[DischargeCurrent] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[BatteryCapSOC] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[mah_H] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[mah_L] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Charge_Current1] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Charge_Current2] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Charge_Current3] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Charge_Current4] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Charge_Current5] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Charge_Current6] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Charge_Current7] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Charge_Current8] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Charge_Current9] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Charge_Current10] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Discharge_Current1] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Discharge_Current2] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Discharge_Current3] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Discharge_Current4] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Discharge_Current5] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Discharge_Current6] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Discharge_Current7] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Discharge_Current8] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Discharge_Current9] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Discharge_Current10] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_TotalVoltage1] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_TotalVoltage2] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_TotalVoltage3] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_TotalVoltage4] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_TotalVoltage5] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_TotalVoltage6] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_TotalVoltage7] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_TotalVoltage8] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_TotalVoltage9] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_TotalVoltage10] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",CONSTRAINT [PK_BATT0401] PRIMARY KEY ([ttime],[ttimen],[imei],[BattName]))";
                    #endregion
                    #region BATT0402
                    string batt0402Sql = $"USE [GPSDB]; IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='BATT0402') CREATE TABLE [BATT0402] (" +
                                     $" [ttime] NVARCHAR(14) NOT NULL" +
                                     $",[ttimen] DATETIME NOT NULL" +
                                     $",[imei] NVARCHAR(50) NOT NULL" +
                                     $",[Longitude] NVARCHAR(50) NOT NULL DEFAULT ''" +
                                     $",[Latitude] NVARCHAR(50) NOT NULL DEFAULT ''" +
                                     $",[Speed] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[BattName] NVARCHAR(16) NOT NULL" +
                                     $",[Battery_Max_Cell_Voltage1] Decimal(18,3) NOT NULL DEFAULT 0" +
                                     $",[Battery_Min_Cell_Voltage1] Decimal(18,3) NOT NULL DEFAULT 0" +
                                     $",[Battery_Max_Cell_Voltage2] Decimal(18,3) NOT NULL DEFAULT 0" +
                                     $",[Battery_Min_Cell_Voltage2] Decimal(18,3) NOT NULL DEFAULT 0" +
                                     $",[Battery_Max_Cell_Voltage3] Decimal(18,3) NOT NULL DEFAULT 0" +
                                     $",[Battery_Min_Cell_Voltage3] Decimal(18,3) NOT NULL DEFAULT 0" +
                                     $",[Battery_Max_Cell_Voltage4] Decimal(18,3) NOT NULL DEFAULT 0" +
                                     $",[Battery_Min_Cell_Voltage4] Decimal(18,3) NOT NULL DEFAULT 0" +
                                     $",[Battery_Max_Cell_Voltage5] Decimal(18,3) NOT NULL DEFAULT 0" +
                                     $",[Battery_Min_Cell_Voltage5] Decimal(18,3) NOT NULL DEFAULT 0" +
                                     $",[Battery_Max_Cell_Voltage6] Decimal(18,3) NOT NULL DEFAULT 0" +
                                     $",[Battery_Min_Cell_Voltage6] Decimal(18,3) NOT NULL DEFAULT 0" +
                                     $",[Battery_Max_Cell_Voltage7] Decimal(18,3) NOT NULL DEFAULT 0" +
                                     $",[Battery_Min_Cell_Voltage7] Decimal(18,3) NOT NULL DEFAULT 0" +
                                     $",[Battery_Max_Cell_Voltage8] Decimal(18,3) NOT NULL DEFAULT 0" +
                                     $",[Battery_Min_Cell_Voltage8] Decimal(18,3) NOT NULL DEFAULT 0" +
                                     $",[Battery_Max_Cell_Voltage9] Decimal(18,3) NOT NULL DEFAULT 0" +
                                     $",[Battery_Min_Cell_Voltage9] Decimal(18,3) NOT NULL DEFAULT 0" +
                                     $",[Battery_Max_Cell_Voltage10] Decimal(18,3) NOT NULL DEFAULT 0" +
                                     $",[Battery_Min_Cell_Voltage10] Decimal(18,3) NOT NULL DEFAULT 0" +
                                     $",[Battery_Max_Temp1] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Min_Temp1] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Max_Temp2] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Min_Temp2] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Max_Temp3] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Min_Temp3] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Max_Temp4] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Min_Temp4] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Max_Temp5] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Min_Temp5] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Max_Temp6] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Min_Temp6] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Max_Temp7] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Min_Temp7] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Max_Temp8] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Min_Temp8] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Max_Temp9] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Min_Temp9] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Max_Temp10] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[Battery_Min_Temp10] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",CONSTRAINT [PK_BATT0402] PRIMARY KEY ([ttime],[ttimen],[imei],[BattName]))";
                    #endregion
                    #region BATT0403
                    string batt0403Sql = $"USE [GPSDB]; IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='BATT0403') CREATE TABLE [BATT0403] (" +
                                     $" [ttime] NVARCHAR(14) NOT NULL" +
                                     $",[ttimen] DATETIME NOT NULL" +
                                     $",[imei] NVARCHAR(50) NOT NULL" +
                                     $",[Longitude] NVARCHAR(50) NOT NULL DEFAULT ''" +
                                     $",[Latitude] NVARCHAR(50) NOT NULL DEFAULT ''" +
                                     $",[Speed] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[BattName] NVARCHAR(16) NOT NULL" +
                                     $",[BMS1_mah_H] Decimal(18,0) NOT NULL DEFAULT 0" +
                                     $",[BMS1_mah_L] Decimal(18,0) NOT NULL DEFAULT 0" +
                                     $",[BMS2_mah_H] Decimal(18,0) NOT NULL DEFAULT 0" +
                                     $",[BMS2_mah_L] Decimal(18,0) NOT NULL DEFAULT 0" +
                                     $",[BMS3_mah_H] Decimal(18,0) NOT NULL DEFAULT 0" +
                                     $",[BMS3_mah_L] Decimal(18,0) NOT NULL DEFAULT 0" +
                                     $",[BMS4_mah_H] Decimal(18,0) NOT NULL DEFAULT 0" +
                                     $",[BMS4_mah_L] Decimal(18,0) NOT NULL DEFAULT 0" +
                                     $",[BMS5_mah_H] Decimal(18,0) NOT NULL DEFAULT 0" +
                                     $",[BMS5_mah_L] Decimal(18,0) NOT NULL DEFAULT 0" +
                                     $",[BMS6_mah_H] Decimal(18,0) NOT NULL DEFAULT 0" +
                                     $",[BMS6_mah_L] Decimal(18,0) NOT NULL DEFAULT 0" +
                                     $",[BMS7_mah_H] Decimal(18,0) NOT NULL DEFAULT 0" +
                                     $",[BMS7_mah_L] Decimal(18,0) NOT NULL DEFAULT 0" +
                                     $",[BMS8_mah_H] Decimal(18,0) NOT NULL DEFAULT 0" +
                                     $",[BMS8_mah_L] Decimal(18,0) NOT NULL DEFAULT 0" +
                                     $",[BMS9_mah_H] Decimal(18,0) NOT NULL DEFAULT 0" +
                                     $",[BMS9_mah_L] Decimal(18,0) NOT NULL DEFAULT 0" +
                                     $",[BMS10_mah_H] Decimal(18,0) NOT NULL DEFAULT 0" +
                                     $",[BMS10_mah_L] Decimal(18,0) NOT NULL DEFAULT 0" +
                                     $",[Battery_OV_Alarm] int NOT NULL DEFAULT 0" +
                                     $",[Battery_UV_Alarm] int NOT NULL DEFAULT 0" +
                                     $",[Battery_DIS_H_Alarm] int NOT NULL DEFAULT 0" +
                                     $",[Battery_DIS_L_Alarm] int NOT NULL DEFAULT 0" +
                                     $",[Battery_OV_Protection] int NOT NULL DEFAULT 0" +
                                     $",[Battery_UV_Protection] int NOT NULL DEFAULT 0" +
                                     $",[Battery_DIS_H_Protection] int NOT NULL DEFAULT 0" +
                                     $",[Battery_DIS_L_Protection] int NOT NULL DEFAULT 0" +
                                     $",[Battery_CHG_H_Alarm] int NOT NULL DEFAULT 0" +
                                     $",[Battery_CHG_L_Alarm] int NOT NULL DEFAULT 0" +
                                     $",[Battery_CHG_H_Protection] int NOT NULL DEFAULT 0" +
                                     $",[Battery_CHG_L_Protection] int NOT NULL DEFAULT 0" +
                                     $",[Temp_Fall_Off] int NOT NULL DEFAULT 0" +
                                     $",[DI_Status] int NOT NULL DEFAULT 0" +
                                     $",[DIS_A1_W] int NOT NULL DEFAULT 0" +
                                     $",[DIS_A1_P] int NOT NULL DEFAULT 0" +
                                     $",[CHG_A1_W] int NOT NULL DEFAULT 0" +
                                     $",[CHG_A1_P] int NOT NULL DEFAULT 0" +
                                     $",[DIS_A2_W] int NOT NULL DEFAULT 0" +
                                     $",[DIS_A2_P] int NOT NULL DEFAULT 0" +
                                     $",[CHG_A2_W] int NOT NULL DEFAULT 0" +
                                     $",[CHG_A2_P] int NOT NULL DEFAULT 0" +
                                     $",[BATT_OVW] int NOT NULL DEFAULT 0" +
                                     $",[BATT_OVP] int NOT NULL DEFAULT 0" +
                                     $",[BATT_UVW] int NOT NULL DEFAULT 0" +
                                     $",CONSTRAINT [PK_BATT0403] PRIMARY KEY ([ttime],[ttimen],[imei],[BattName]))";
                    #endregion
                    #region BATT0404
                    string batt0404Sql = $"USE [GPSDB]; IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='BATT0404') CREATE TABLE [BATT0404] (" +
                                     $" [ttime] NVARCHAR(14) NOT NULL" +
                                     $",[ttimen] DATETIME NOT NULL" +
                                     $",[imei] NVARCHAR(50) NOT NULL" +
                                     $",[Longitude] NVARCHAR(50) NOT NULL DEFAULT ''" +
                                     $",[Latitude] NVARCHAR(50) NOT NULL DEFAULT ''" +
                                     $",[Speed] Decimal(18,2) NOT NULL DEFAULT 0" +
                                     $",[BattName] NVARCHAR(16) NOT NULL" +
                                     $",[BATT_UVP] int NOT NULL DEFAULT 0" +
                                     $",[BMS1_BMS2] int NOT NULL DEFAULT 0" +
                                     $",[BMS3_BMS4] int NOT NULL DEFAULT 0" +
                                     $",[BMS5_BMS6] int NOT NULL DEFAULT 0" +
                                     $",[BMS7_BMS8] int NOT NULL DEFAULT 0" +
                                     $",[BMS9_BMS10] int NOT NULL DEFAULT 0" +
                                     $",[BMS1_Status] int NOT NULL DEFAULT 0" +
                                     $",[BMS2_Status] int NOT NULL DEFAULT 0" +
                                     $",[BMS3_Status] int NOT NULL DEFAULT 0" +
                                     $",[BMS4_Status] int NOT NULL DEFAULT 0" +
                                     $",[BMS5_Status] int NOT NULL DEFAULT 0" +
                                     $",[BMS6_Status] int NOT NULL DEFAULT 0" +
                                     $",[BMS7_Status] int NOT NULL DEFAULT 0" +
                                     $",[BMS8_Status] int NOT NULL DEFAULT 0" +
                                     $",[BMS9_Status] int NOT NULL DEFAULT 0" +
                                     $",[BMS10_Status] int NOT NULL DEFAULT 0" +
                                     $",CONSTRAINT [PK_BATT0404] PRIMARY KEY ([ttime],[ttimen],[imei],[BattName]))";
                    #endregion
                    conn.Execute(databaseSql);//資料庫
                    Thread.Sleep(10);
                    conn.Execute(battwebSql);//即時資料表
                    Thread.Sleep(10);
                    conn.Execute(batt0401Sql);//電池0401資料表
                    Thread.Sleep(10);
                    conn.Execute(batt0402Sql);//電池0402資料表
                    Thread.Sleep(10);
                    conn.Execute(batt0403Sql);//電池0403資料表
                    Thread.Sleep(10);
                    conn.Execute(batt0404Sql);//電池0404資料表
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "資料庫建立失敗");
            }
        }
        #endregion
        #region 更新電池資料
        /// <summary>
        /// 新增電池資料
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public bool InserterBATT(BATTModule module)
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = $" INSERT INTO [BATT{module.TableName}] (ttime,ttimen,imei,Longitude,Latitude,Speed,BattName";
                    string sqlend = " VALUES (@ttime,@ttimen,@imei,@Longitude,@Latitude,@Speed,@BattName";
                    switch (module.TableName)
                    {
                        case "0401":
                            {
                                sql += ",BATTVoltage" +
                                       ",ChargeCurrent" +
                                       ",DischargeCurrent" +
                                       ",BatteryCapSOC" +
                                       ",mah_H" +
                                       ",mah_L" +
                                       ",Battery_Charge_Current1" +
                                       ",Battery_Charge_Current2" +
                                       ",Battery_Charge_Current3" +
                                       ",Battery_Charge_Current4" +
                                       ",Battery_Charge_Current5" +
                                       ",Battery_Charge_Current6" +
                                       ",Battery_Charge_Current7" +
                                       ",Battery_Charge_Current8" +
                                       ",Battery_Charge_Current9" +
                                       ",Battery_Charge_Current10" +
                                       ",Battery_Discharge_Current1" +
                                       ",Battery_Discharge_Current2" +
                                       ",Battery_Discharge_Current3" +
                                       ",Battery_Discharge_Current4" +
                                       ",Battery_Discharge_Current5" +
                                       ",Battery_Discharge_Current6" +
                                       ",Battery_Discharge_Current7" +
                                       ",Battery_Discharge_Current8" +
                                       ",Battery_Discharge_Current9" +
                                       ",Battery_Discharge_Current10" +
                                       ",Battery_TotalVoltage1" +
                                       ",Battery_TotalVoltage2" +
                                       ",Battery_TotalVoltage3" +
                                       ",Battery_TotalVoltage4" +
                                       ",Battery_TotalVoltage5" +
                                       ",Battery_TotalVoltage6" +
                                       ",Battery_TotalVoltage7" +
                                       ",Battery_TotalVoltage8" +
                                       ",Battery_TotalVoltage9" +
                                       ",Battery_TotalVoltage10)";
                                sqlend += ",@BATTVoltage" +
                                          ",@ChargeCurrent" +
                                          ",@DischargeCurrent" +
                                          ",@BatteryCapSOC" +
                                          ",@mah_H" +
                                          ",@mah_L" +
                                          ",@Battery_Charge_Current1" +
                                          ",@Battery_Charge_Current2" +
                                          ",@Battery_Charge_Current3" +
                                          ",@Battery_Charge_Current4" +
                                          ",@Battery_Charge_Current5" +
                                          ",@Battery_Charge_Current6" +
                                          ",@Battery_Charge_Current7" +
                                          ",@Battery_Charge_Current8" +
                                          ",@Battery_Charge_Current9" +
                                          ",@Battery_Charge_Current10" +
                                          ",@Battery_Discharge_Current1" +
                                          ",@Battery_Discharge_Current2" +
                                          ",@Battery_Discharge_Current3" +
                                          ",@Battery_Discharge_Current4" +
                                          ",@Battery_Discharge_Current5" +
                                          ",@Battery_Discharge_Current6" +
                                          ",@Battery_Discharge_Current7" +
                                          ",@Battery_Discharge_Current8" +
                                          ",@Battery_Discharge_Current9" +
                                          ",@Battery_Discharge_Current10" +
                                          ",@Battery_TotalVoltage1" +
                                          ",@Battery_TotalVoltage2" +
                                          ",@Battery_TotalVoltage3" +
                                          ",@Battery_TotalVoltage4" +
                                          ",@Battery_TotalVoltage5" +
                                          ",@Battery_TotalVoltage6" +
                                          ",@Battery_TotalVoltage7" +
                                          ",@Battery_TotalVoltage8" +
                                          ",@Battery_TotalVoltage9" +
                                          ",@Battery_TotalVoltage10)";
                                sql += sqlend;
                                BATT0401Data data = (BATT0401Data)module;
                                conn.Execute(sql, data);
                            }
                            break;
                        case "0402":
                            {
                                sql += ",Battery_Max_Cell_Voltage1" +
                                       ",Battery_Min_Cell_Voltage1" +
                                       ",Battery_Max_Cell_Voltage2" +
                                       ",Battery_Min_Cell_Voltage2" +
                                       ",Battery_Max_Cell_Voltage3" +
                                       ",Battery_Min_Cell_Voltage3" +
                                       ",Battery_Max_Cell_Voltage4" +
                                       ",Battery_Min_Cell_Voltage4" +
                                       ",Battery_Max_Cell_Voltage5" +
                                       ",Battery_Min_Cell_Voltage5" +
                                       ",Battery_Max_Cell_Voltage6" +
                                       ",Battery_Min_Cell_Voltage6" +
                                       ",Battery_Max_Cell_Voltage7" +
                                       ",Battery_Min_Cell_Voltage7" +
                                       ",Battery_Max_Cell_Voltage8" +
                                       ",Battery_Min_Cell_Voltage8" +
                                       ",Battery_Max_Cell_Voltage9" +
                                       ",Battery_Min_Cell_Voltage9" +
                                       ",Battery_Max_Cell_Voltage10" +
                                       ",Battery_Min_Cell_Voltage10" +
                                       ",Battery_Max_Temp1" +
                                       ",Battery_Min_Temp1" +
                                       ",Battery_Max_Temp2" +
                                       ",Battery_Min_Temp2" +
                                       ",Battery_Max_Temp3" +
                                       ",Battery_Min_Temp3" +
                                       ",Battery_Max_Temp4" +
                                       ",Battery_Min_Temp4" +
                                       ",Battery_Max_Temp5" +
                                       ",Battery_Min_Temp5" +
                                       ",Battery_Max_Temp6" +
                                       ",Battery_Min_Temp6" +
                                       ",Battery_Max_Temp7" +
                                       ",Battery_Min_Temp7" +
                                       ",Battery_Max_Temp8" +
                                       ",Battery_Min_Temp8" +
                                       ",Battery_Max_Temp9" +
                                       ",Battery_Min_Temp9" +
                                       ",Battery_Max_Temp10" +
                                       ",Battery_Min_Temp10)";
                                sqlend += ",@Battery_Max_Cell_Voltage1" +
                                          ",@Battery_Min_Cell_Voltage1" +
                                          ",@Battery_Max_Cell_Voltage2" +
                                          ",@Battery_Min_Cell_Voltage2" +
                                          ",@Battery_Max_Cell_Voltage3" +
                                          ",@Battery_Min_Cell_Voltage3" +
                                          ",@Battery_Max_Cell_Voltage4" +
                                          ",@Battery_Min_Cell_Voltage4" +
                                          ",@Battery_Max_Cell_Voltage5" +
                                          ",@Battery_Min_Cell_Voltage5" +
                                          ",@Battery_Max_Cell_Voltage6" +
                                          ",@Battery_Min_Cell_Voltage6" +
                                          ",@Battery_Max_Cell_Voltage7" +
                                          ",@Battery_Min_Cell_Voltage7" +
                                          ",@Battery_Max_Cell_Voltage8" +
                                          ",@Battery_Min_Cell_Voltage8" +
                                          ",@Battery_Max_Cell_Voltage9" +
                                          ",@Battery_Min_Cell_Voltage9" +
                                          ",@Battery_Max_Cell_Voltage10" +
                                          ",@Battery_Min_Cell_Voltage10" +
                                          ",@Battery_Max_Temp1" +
                                          ",@Battery_Min_Temp1" +
                                          ",@Battery_Max_Temp2" +
                                          ",@Battery_Min_Temp2" +
                                          ",@Battery_Max_Temp3" +
                                          ",@Battery_Min_Temp3" +
                                          ",@Battery_Max_Temp4" +
                                          ",@Battery_Min_Temp4" +
                                          ",@Battery_Max_Temp5" +
                                          ",@Battery_Min_Temp5" +
                                          ",@Battery_Max_Temp6" +
                                          ",@Battery_Min_Temp6" +
                                          ",@Battery_Max_Temp7" +
                                          ",@Battery_Min_Temp7" +
                                          ",@Battery_Max_Temp8" +
                                          ",@Battery_Min_Temp8" +
                                          ",@Battery_Max_Temp9" +
                                          ",@Battery_Min_Temp9" +
                                          ",@Battery_Max_Temp10" +
                                          ",@Battery_Min_Temp10)";
                                sql += sqlend;
                                BATT0402Data data = (BATT0402Data)module;
                                conn.Execute(sql, data);
                            }
                            break;
                        case "0403":
                            {
                                sql += ",BMS1_mah_H" +
                                       ",BMS1_mah_L" +
                                       ",BMS2_mah_H" +
                                       ",BMS2_mah_L" +
                                       ",BMS3_mah_H" +
                                       ",BMS3_mah_L" +
                                       ",BMS4_mah_H" +
                                       ",BMS4_mah_L" +
                                       ",BMS5_mah_H" +
                                       ",BMS5_mah_L" +
                                       ",BMS6_mah_H" +
                                       ",BMS6_mah_L" +
                                       ",BMS7_mah_H" +
                                       ",BMS7_mah_L" +
                                       ",BMS8_mah_H" +
                                       ",BMS8_mah_L" +
                                       ",BMS9_mah_H" +
                                       ",BMS9_mah_L" +
                                       ",BMS10_mah_H" +
                                       ",BMS10_mah_L" +
                                       ",Battery_OV_Alarm " +
                                       ",Battery_UV_Alarm " +
                                       ",Battery_DIS_H_Alarm " +
                                       ",Battery_DIS_L_Alarm " +
                                       ",Battery_OV_Protection " +
                                       ",Battery_UV_Protection " +
                                       ",Battery_DIS_H_Protection " +
                                       ",Battery_DIS_L_Protection " +
                                       ",Battery_CHG_H_Alarm " +
                                       ",Battery_CHG_L_Alarm " +
                                       ",Battery_CHG_H_Protection " +
                                       ",Battery_CHG_L_Protection " +
                                       ",Temp_Fall_Off " +
                                       ",DI_Status " +
                                       ",DIS_A1_W " +
                                       ",DIS_A1_P " +
                                       ",CHG_A1_W " +
                                       ",CHG_A1_P " +
                                       ",DIS_A2_W " +
                                       ",DIS_A2_P " +
                                       ",CHG_A2_W " +
                                       ",CHG_A2_P " +
                                       ",BATT_OVW " +
                                       ",BATT_OVP " +
                                       ",BATT_UVW) ";
                                sqlend += ",@BMS1_mah_H" +
                                          ",@BMS1_mah_L" +
                                          ",@BMS2_mah_H" +
                                          ",@BMS2_mah_L" +
                                          ",@BMS3_mah_H" +
                                          ",@BMS3_mah_L" +
                                          ",@BMS4_mah_H" +
                                          ",@BMS4_mah_L" +
                                          ",@BMS5_mah_H" +
                                          ",@BMS5_mah_L" +
                                          ",@BMS6_mah_H" +
                                          ",@BMS6_mah_L" +
                                          ",@BMS7_mah_H" +
                                          ",@BMS7_mah_L" +
                                          ",@BMS8_mah_H" +
                                          ",@BMS8_mah_L" +
                                          ",@BMS9_mah_H" +
                                          ",@BMS9_mah_L" +
                                          ",@BMS10_mah_H" +
                                          ",@BMS10_mah_L" +
                                          ",@Battery_OV_Alarm " +
                                          ",@Battery_UV_Alarm " +
                                          ",@Battery_DIS_H_Alarm " +
                                          ",@Battery_DIS_L_Alarm " +
                                          ",@Battery_OV_Protection " +
                                          ",@Battery_UV_Protection " +
                                          ",@Battery_DIS_H_Protection " +
                                          ",@Battery_DIS_L_Protection " +
                                          ",@Battery_CHG_H_Alarm " +
                                          ",@Battery_CHG_L_Alarm " +
                                          ",@Battery_CHG_H_Protection " +
                                          ",@Battery_CHG_L_Protection " +
                                          ",@Temp_Fall_Off " +
                                          ",@DI_Status " +
                                          ",@DIS_A1_W " +
                                          ",@DIS_A1_P " +
                                          ",@CHG_A1_W " +
                                          ",@CHG_A1_P " +
                                          ",@DIS_A2_W " +
                                          ",@DIS_A2_P " +
                                          ",@CHG_A2_W " +
                                          ",@CHG_A2_P " +
                                          ",@BATT_OVW " +
                                          ",@BATT_OVP " +
                                          ",@BATT_UVW) ";
                                sql += sqlend;
                                BATT0403Data data = (BATT0403Data)module;
                                conn.Execute(sql, data);
                            }
                            break;
                        case "0404":
                            {
                                sql += ",BATT_UVW" +
                                       ",BMS1_BMS2" +
                                       ",BMS3_BMS4" +
                                       ",BMS5_BMS6" +
                                       ",BMS7_BMS8" +
                                       ",BMS9_BMS10" +
                                       ",BMS1_Status" +
                                       ",BMS2_Status" +
                                       ",BMS3_Status" +
                                       ",BMS4_Status" +
                                       ",BMS5_Status" +
                                       ",BMS6_Status" +
                                       ",BMS7_Status" +
                                       ",BMS8_Status" +
                                       ",BMS9_Status" +
                                       ",BMS10_Status)";
                                sqlend += ",@BATT_UVW" +
                                          ",@BMS1_BMS2" +
                                          ",@BMS3_BMS4" +
                                          ",@BMS5_BMS6" +
                                          ",@BMS7_BMS8" +
                                          ",@BMS9_BMS10" +
                                          ",@BMS1_Status" +
                                          ",@BMS2_Status" +
                                          ",@BMS3_Status" +
                                          ",@BMS4_Status" +
                                          ",@BMS5_Status" +
                                          ",@BMS6_Status" +
                                          ",@BMS7_Status" +
                                          ",@BMS8_Status" +
                                          ",@BMS9_Status" +
                                          ",@BMS10_Status)";
                                sql += sqlend;
                                BATT0404Data data = (BATT0404Data)module;
                                conn.Execute(sql, data);
                            }
                            break;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"新增BATT{module.TableName}LOG失敗");
                return false;
            }
        }
        /// <summary>
        /// 新增電池0401資料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool InserterBATT0401(BATT0401Data data)
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = $"INSERT INTO [BATT0401] (ttime,ttimen,imei,Longitude,Latitude,Speed,BattName";
                    string sqlend = " VALUES (@ttime,@ttimen,@imei,@Longitude,@Latitude,@Speed,@BattName";
                    sql += ",BATTVoltage" +
                           ",ChargeCurrent" +
                           ",DischargeCurrent" +
                           ",BatteryCapSOC" +
                           ",mah_H" +
                           ",mah_L" +
                           ",Battery_Charge_Current1" +
                           ",Battery_Charge_Current2" +
                           ",Battery_Charge_Current3" +
                           ",Battery_Charge_Current4" +
                           ",Battery_Charge_Current5" +
                           ",Battery_Charge_Current6" +
                           ",Battery_Charge_Current7" +
                           ",Battery_Charge_Current8" +
                           ",Battery_Charge_Current9" +
                           ",Battery_Charge_Current10" +
                           ",Battery_Discharge_Current1" +
                           ",Battery_Discharge_Current2" +
                           ",Battery_Discharge_Current3" +
                           ",Battery_Discharge_Current4" +
                           ",Battery_Discharge_Current5" +
                           ",Battery_Discharge_Current6" +
                           ",Battery_Discharge_Current7" +
                           ",Battery_Discharge_Current8" +
                           ",Battery_Discharge_Current9" +
                           ",Battery_Discharge_Current10" +
                           ",Battery_TotalVoltage1" +
                           ",Battery_TotalVoltage2" +
                           ",Battery_TotalVoltage3" +
                           ",Battery_TotalVoltage4" +
                           ",Battery_TotalVoltage5" +
                           ",Battery_TotalVoltage6" +
                           ",Battery_TotalVoltage7" +
                           ",Battery_TotalVoltage8" +
                           ",Battery_TotalVoltage9" +
                           ",Battery_TotalVoltage10)";
                    sqlend += ",@BATTVoltage" +
                              ",@ChargeCurrent" +
                              ",@DischargeCurrent" +
                              ",@BatteryCapSOC" +
                              ",@mah_H" +
                              ",@mah_L" +
                              ",@Battery_Charge_Current1" +
                              ",@Battery_Charge_Current2" +
                              ",@Battery_Charge_Current3" +
                              ",@Battery_Charge_Current4" +
                              ",@Battery_Charge_Current5" +
                              ",@Battery_Charge_Current6" +
                              ",@Battery_Charge_Current7" +
                              ",@Battery_Charge_Current8" +
                              ",@Battery_Charge_Current9" +
                              ",@Battery_Charge_Current10" +
                              ",@Battery_Discharge_Current1" +
                              ",@Battery_Discharge_Current2" +
                              ",@Battery_Discharge_Current3" +
                              ",@Battery_Discharge_Current4" +
                              ",@Battery_Discharge_Current5" +
                              ",@Battery_Discharge_Current6" +
                              ",@Battery_Discharge_Current7" +
                              ",@Battery_Discharge_Current8" +
                              ",@Battery_Discharge_Current9" +
                              ",@Battery_Discharge_Current10" +
                              ",@Battery_TotalVoltage1" +
                              ",@Battery_TotalVoltage2" +
                              ",@Battery_TotalVoltage3" +
                              ",@Battery_TotalVoltage4" +
                              ",@Battery_TotalVoltage5" +
                              ",@Battery_TotalVoltage6" +
                              ",@Battery_TotalVoltage7" +
                              ",@Battery_TotalVoltage8" +
                              ",@Battery_TotalVoltage9" +
                              ",@Battery_TotalVoltage10)";
                    sql += sqlend;
                    conn.Execute(sql, data);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"新增BATT0401_LOG失敗  時間: {data.ttimen} 封包類型: {data.BattName}-0401");
                return false;
            }
        }
        /// <summary>
        /// 更新電池0401資料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void UpdateBATT0401web(BATT0401Data data)
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "";
                    var exsitforweb = conn.ExecuteScalar<bool>($"SELECT TOP 1 1 FROM BATTWeb WHERE imei = @imei AND BattName = @BattName", data);
                    if (exsitforweb)
                    {
                        sql = $"UPDATE [BATTWeb] SET ttime=@ttime" +
                              $",ttimen=@ttimen" +
                              $",Longitude=@Longitude" +
                              $",Latitude=@Latitude" +
                              $",Speed=@Speed" +
                              ",BATTVoltage=@BATTVoltage" +
                              ",ChargeCurrent=@ChargeCurrent" +
                              ",DischargeCurrent=@DischargeCurrent" +
                              ",BatteryCapSOC=@BatteryCapSOC" +
                              ",mah_H=@mah_H" +
                              ",mah_L=@mah_L" +
                              ",Battery_Charge_Current1=@Battery_Charge_Current1" +
                              ",Battery_Charge_Current2=@Battery_Charge_Current2" +
                              ",Battery_Charge_Current3=@Battery_Charge_Current3" +
                              ",Battery_Charge_Current4=@Battery_Charge_Current4" +
                              ",Battery_Charge_Current5=@Battery_Charge_Current5" +
                              ",Battery_Charge_Current6=@Battery_Charge_Current6" +
                              ",Battery_Charge_Current7=@Battery_Charge_Current7" +
                              ",Battery_Charge_Current8=@Battery_Charge_Current8" +
                              ",Battery_Charge_Current9=@Battery_Charge_Current9" +
                              ",Battery_Charge_Current10=@Battery_Charge_Current10" +
                              ",Battery_Discharge_Current1=@Battery_Discharge_Current1" +
                              ",Battery_Discharge_Current2=@Battery_Discharge_Current2" +
                              ",Battery_Discharge_Current3=@Battery_Discharge_Current3" +
                              ",Battery_Discharge_Current4=@Battery_Discharge_Current4" +
                              ",Battery_Discharge_Current5=@Battery_Discharge_Current5" +
                              ",Battery_Discharge_Current6=@Battery_Discharge_Current6" +
                              ",Battery_Discharge_Current7=@Battery_Discharge_Current7" +
                              ",Battery_Discharge_Current8=@Battery_Discharge_Current8" +
                              ",Battery_Discharge_Current9=@Battery_Discharge_Current9" +
                              ",Battery_Discharge_Current10=@Battery_Discharge_Current10" +
                              ",Battery_TotalVoltage1=@Battery_TotalVoltage1" +
                              ",Battery_TotalVoltage2=@Battery_TotalVoltage2" +
                              ",Battery_TotalVoltage3=@Battery_TotalVoltage3" +
                              ",Battery_TotalVoltage4=@Battery_TotalVoltage4" +
                              ",Battery_TotalVoltage5=@Battery_TotalVoltage5" +
                              ",Battery_TotalVoltage6=@Battery_TotalVoltage6" +
                              ",Battery_TotalVoltage7=@Battery_TotalVoltage7" +
                              ",Battery_TotalVoltage8=@Battery_TotalVoltage8" +
                              ",Battery_TotalVoltage9=@Battery_TotalVoltage9" +
                              ",Battery_TotalVoltage10=@Battery_TotalVoltage10 " +
                              " WHERE imei=@imei AND BattName=@BattName";
                    }
                    else
                    {
                        sql = $"INSERT INTO [BATTWeb] (ttime,ttimen,imei,Longitude,Latitude,Speed,BattName";
                        string sqlend = " VALUES (@ttime,@ttimen,@imei,@Longitude,@Latitude,@Speed,@BattName";
                        sql += ",BATTVoltage" +
                               ",ChargeCurrent" +
                               ",DischargeCurrent" +
                               ",BatteryCapSOC" +
                               ",mah_H" +
                               ",mah_L" +
                               ",Battery_Charge_Current1" +
                               ",Battery_Charge_Current2" +
                               ",Battery_Charge_Current3" +
                               ",Battery_Charge_Current4" +
                               ",Battery_Charge_Current5" +
                               ",Battery_Charge_Current6" +
                               ",Battery_Charge_Current7" +
                               ",Battery_Charge_Current8" +
                               ",Battery_Charge_Current9" +
                               ",Battery_Charge_Current10" +
                               ",Battery_Discharge_Current1" +
                               ",Battery_Discharge_Current2" +
                               ",Battery_Discharge_Current3" +
                               ",Battery_Discharge_Current4" +
                               ",Battery_Discharge_Current5" +
                               ",Battery_Discharge_Current6" +
                               ",Battery_Discharge_Current7" +
                               ",Battery_Discharge_Current8" +
                               ",Battery_Discharge_Current9" +
                               ",Battery_Discharge_Current10" +
                               ",Battery_TotalVoltage1" +
                               ",Battery_TotalVoltage2" +
                               ",Battery_TotalVoltage3" +
                               ",Battery_TotalVoltage4" +
                               ",Battery_TotalVoltage5" +
                               ",Battery_TotalVoltage6" +
                               ",Battery_TotalVoltage7" +
                               ",Battery_TotalVoltage8" +
                               ",Battery_TotalVoltage9" +
                               ",Battery_TotalVoltage10)";
                        sqlend += ",@BATTVoltage" +
                                  ",@ChargeCurrent" +
                                  ",@DischargeCurrent" +
                                  ",@BatteryCapSOC" +
                                  ",@mah_H" +
                                  ",@mah_L" +
                                  ",@Battery_Charge_Current1" +
                                  ",@Battery_Charge_Current2" +
                                  ",@Battery_Charge_Current3" +
                                  ",@Battery_Charge_Current4" +
                                  ",@Battery_Charge_Current5" +
                                  ",@Battery_Charge_Current6" +
                                  ",@Battery_Charge_Current7" +
                                  ",@Battery_Charge_Current8" +
                                  ",@Battery_Charge_Current9" +
                                  ",@Battery_Charge_Current10" +
                                  ",@Battery_Discharge_Current1" +
                                  ",@Battery_Discharge_Current2" +
                                  ",@Battery_Discharge_Current3" +
                                  ",@Battery_Discharge_Current4" +
                                  ",@Battery_Discharge_Current5" +
                                  ",@Battery_Discharge_Current6" +
                                  ",@Battery_Discharge_Current7" +
                                  ",@Battery_Discharge_Current8" +
                                  ",@Battery_Discharge_Current9" +
                                  ",@Battery_Discharge_Current10" +
                                  ",@Battery_TotalVoltage1" +
                                  ",@Battery_TotalVoltage2" +
                                  ",@Battery_TotalVoltage3" +
                                  ",@Battery_TotalVoltage4" +
                                  ",@Battery_TotalVoltage5" +
                                  ",@Battery_TotalVoltage6" +
                                  ",@Battery_TotalVoltage7" +
                                  ",@Battery_TotalVoltage8" +
                                  ",@Battery_TotalVoltage9" +
                                  ",@Battery_TotalVoltage10)";
                        sql += sqlend;
                    }
                    conn.Execute(sql, data);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"更新BATT0401_WEB失敗 時間: {data.ttimen} 封包類型: {data.BattName}-0401");
            }
        }
        /// <summary>
        /// 新增電池0402資料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool InserterBATT0402(BATT0402Data data)
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = $"INSERT INTO [BATT0402] (ttime,ttimen,imei,Longitude,Latitude,Speed,BattName";
                    string sqlend = " VALUES (@ttime,@ttimen,@imei,@Longitude,@Latitude,@Speed,@BattName";
                    sql += ",Battery_Max_Cell_Voltage1" +
                           ",Battery_Min_Cell_Voltage1" +
                           ",Battery_Max_Cell_Voltage2" +
                           ",Battery_Min_Cell_Voltage2" +
                           ",Battery_Max_Cell_Voltage3" +
                           ",Battery_Min_Cell_Voltage3" +
                           ",Battery_Max_Cell_Voltage4" +
                           ",Battery_Min_Cell_Voltage4" +
                           ",Battery_Max_Cell_Voltage5" +
                           ",Battery_Min_Cell_Voltage5" +
                           ",Battery_Max_Cell_Voltage6" +
                           ",Battery_Min_Cell_Voltage6" +
                           ",Battery_Max_Cell_Voltage7" +
                           ",Battery_Min_Cell_Voltage7" +
                           ",Battery_Max_Cell_Voltage8" +
                           ",Battery_Min_Cell_Voltage8" +
                           ",Battery_Max_Cell_Voltage9" +
                           ",Battery_Min_Cell_Voltage9" +
                           ",Battery_Max_Cell_Voltage10" +
                           ",Battery_Min_Cell_Voltage10" +
                           ",Battery_Max_Temp1" +
                           ",Battery_Min_Temp1" +
                           ",Battery_Max_Temp2" +
                           ",Battery_Min_Temp2" +
                           ",Battery_Max_Temp3" +
                           ",Battery_Min_Temp3" +
                           ",Battery_Max_Temp4" +
                           ",Battery_Min_Temp4" +
                           ",Battery_Max_Temp5" +
                           ",Battery_Min_Temp5" +
                           ",Battery_Max_Temp6" +
                           ",Battery_Min_Temp6" +
                           ",Battery_Max_Temp7" +
                           ",Battery_Min_Temp7" +
                           ",Battery_Max_Temp8" +
                           ",Battery_Min_Temp8" +
                           ",Battery_Max_Temp9" +
                           ",Battery_Min_Temp9" +
                           ",Battery_Max_Temp10" +
                           ",Battery_Min_Temp10)";
                    sqlend += ",@Battery_Max_Cell_Voltage1" +
                              ",@Battery_Min_Cell_Voltage1" +
                              ",@Battery_Max_Cell_Voltage2" +
                              ",@Battery_Min_Cell_Voltage2" +
                              ",@Battery_Max_Cell_Voltage3" +
                              ",@Battery_Min_Cell_Voltage3" +
                              ",@Battery_Max_Cell_Voltage4" +
                              ",@Battery_Min_Cell_Voltage4" +
                              ",@Battery_Max_Cell_Voltage5" +
                              ",@Battery_Min_Cell_Voltage5" +
                              ",@Battery_Max_Cell_Voltage6" +
                              ",@Battery_Min_Cell_Voltage6" +
                              ",@Battery_Max_Cell_Voltage7" +
                              ",@Battery_Min_Cell_Voltage7" +
                              ",@Battery_Max_Cell_Voltage8" +
                              ",@Battery_Min_Cell_Voltage8" +
                              ",@Battery_Max_Cell_Voltage9" +
                              ",@Battery_Min_Cell_Voltage9" +
                              ",@Battery_Max_Cell_Voltage10" +
                              ",@Battery_Min_Cell_Voltage10" +
                              ",@Battery_Max_Temp1" +
                              ",@Battery_Min_Temp1" +
                              ",@Battery_Max_Temp2" +
                              ",@Battery_Min_Temp2" +
                              ",@Battery_Max_Temp3" +
                              ",@Battery_Min_Temp3" +
                              ",@Battery_Max_Temp4" +
                              ",@Battery_Min_Temp4" +
                              ",@Battery_Max_Temp5" +
                              ",@Battery_Min_Temp5" +
                              ",@Battery_Max_Temp6" +
                              ",@Battery_Min_Temp6" +
                              ",@Battery_Max_Temp7" +
                              ",@Battery_Min_Temp7" +
                              ",@Battery_Max_Temp8" +
                              ",@Battery_Min_Temp8" +
                              ",@Battery_Max_Temp9" +
                              ",@Battery_Min_Temp9" +
                              ",@Battery_Max_Temp10" +
                              ",@Battery_Min_Temp10)";
                    sql += sqlend;
                    conn.Execute(sql, data);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"新增BATT0402_LOG失敗  時間: {data.ttimen} 封包類型: {data.BattName}-0402");
                return false;
            }
        }
        /// <summary>
        /// 更新電池0402資料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void UpdateBATT0402web(BATT0402Data data)
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "";
                    var exsitforweb = conn.ExecuteScalar<bool>($"SELECT TOP 1 1 FROM BATTWeb WHERE imei = @imei AND BattName = @BattName", data);
                    if (exsitforweb)
                    {
                        sql = $"UPDATE [BATTWeb] SET ttime=@ttime" +
                              $",ttimen=@ttimen" +
                              $",Longitude=@Longitude" +
                              $",Latitude=@Latitude" +
                              $",Speed=@Speed" +
                              ",Battery_Max_Cell_Voltage1=@Battery_Max_Cell_Voltage1" +
                              ",Battery_Min_Cell_Voltage1=@Battery_Min_Cell_Voltage1" +
                              ",Battery_Max_Cell_Voltage2=@Battery_Max_Cell_Voltage2" +
                              ",Battery_Min_Cell_Voltage2=@Battery_Min_Cell_Voltage2" +
                              ",Battery_Max_Cell_Voltage3=@Battery_Max_Cell_Voltage3" +
                              ",Battery_Min_Cell_Voltage3=@Battery_Min_Cell_Voltage3" +
                              ",Battery_Max_Cell_Voltage4=@Battery_Max_Cell_Voltage4" +
                              ",Battery_Min_Cell_Voltage4=@Battery_Min_Cell_Voltage4" +
                              ",Battery_Max_Cell_Voltage5=@Battery_Max_Cell_Voltage5" +
                              ",Battery_Min_Cell_Voltage5=@Battery_Min_Cell_Voltage5" +
                              ",Battery_Max_Cell_Voltage6=@Battery_Max_Cell_Voltage6" +
                              ",Battery_Min_Cell_Voltage6=@Battery_Min_Cell_Voltage6" +
                              ",Battery_Max_Cell_Voltage7=@Battery_Max_Cell_Voltage7" +
                              ",Battery_Min_Cell_Voltage7=@Battery_Min_Cell_Voltage7" +
                              ",Battery_Max_Cell_Voltage8=@Battery_Max_Cell_Voltage8" +
                              ",Battery_Min_Cell_Voltage8=@Battery_Min_Cell_Voltage8" +
                              ",Battery_Max_Cell_Voltage9=@Battery_Max_Cell_Voltage9" +
                              ",Battery_Min_Cell_Voltage9=@Battery_Min_Cell_Voltage9" +
                              ",Battery_Max_Cell_Voltage10=@Battery_Max_Cell_Voltage10" +
                              ",Battery_Min_Cell_Voltage10=@Battery_Min_Cell_Voltage10" +
                              ",Battery_Max_Temp1=@Battery_Max_Temp1" +
                              ",Battery_Min_Temp1=@Battery_Min_Temp1" +
                              ",Battery_Max_Temp2=@Battery_Max_Temp2" +
                              ",Battery_Min_Temp2=@Battery_Min_Temp2" +
                              ",Battery_Max_Temp3=@Battery_Max_Temp3" +
                              ",Battery_Min_Temp3=@Battery_Min_Temp3" +
                              ",Battery_Max_Temp4=@Battery_Max_Temp4" +
                              ",Battery_Min_Temp4=@Battery_Min_Temp4" +
                              ",Battery_Max_Temp5=@Battery_Max_Temp5" +
                              ",Battery_Min_Temp5=@Battery_Min_Temp5" +
                              ",Battery_Max_Temp6=@Battery_Max_Temp6" +
                              ",Battery_Min_Temp6=@Battery_Min_Temp6" +
                              ",Battery_Max_Temp7=@Battery_Max_Temp7" +
                              ",Battery_Min_Temp7=@Battery_Min_Temp7" +
                              ",Battery_Max_Temp8=@Battery_Max_Temp8" +
                              ",Battery_Min_Temp8=@Battery_Min_Temp8" +
                              ",Battery_Max_Temp9=@Battery_Max_Temp9" +
                              ",Battery_Min_Temp9=@Battery_Min_Temp9" +
                              ",Battery_Max_Temp10=@Battery_Max_Temp10" +
                              ",Battery_Min_Temp10=@Battery_Min_Temp10" +
                              " WHERE imei=@imei AND BattName=@BattName";
                    }
                    else
                    {
                        sql = $"INSERT INTO [BATTWeb] (ttime,ttimen,imei,Longitude,Latitude,Speed,BattName";
                        string sqlend = " VALUES (@ttime,@ttimen,@imei,@Longitude,@Latitude,@Speed,@BattName";
                        sql += ",Battery_Max_Cell_Voltage1" +
                               ",Battery_Min_Cell_Voltage1" +
                               ",Battery_Max_Cell_Voltage2" +
                               ",Battery_Min_Cell_Voltage2" +
                               ",Battery_Max_Cell_Voltage3" +
                               ",Battery_Min_Cell_Voltage3" +
                               ",Battery_Max_Cell_Voltage4" +
                               ",Battery_Min_Cell_Voltage4" +
                               ",Battery_Max_Cell_Voltage5" +
                               ",Battery_Min_Cell_Voltage5" +
                               ",Battery_Max_Cell_Voltage6" +
                               ",Battery_Min_Cell_Voltage6" +
                               ",Battery_Max_Cell_Voltage7" +
                               ",Battery_Min_Cell_Voltage7" +
                               ",Battery_Max_Cell_Voltage8" +
                               ",Battery_Min_Cell_Voltage8" +
                               ",Battery_Max_Cell_Voltage9" +
                               ",Battery_Min_Cell_Voltage9" +
                               ",Battery_Max_Cell_Voltage10" +
                               ",Battery_Min_Cell_Voltage10" +
                               ",Battery_Max_Temp1" +
                               ",Battery_Min_Temp1" +
                               ",Battery_Max_Temp2" +
                               ",Battery_Min_Temp2" +
                               ",Battery_Max_Temp3" +
                               ",Battery_Min_Temp3" +
                               ",Battery_Max_Temp4" +
                               ",Battery_Min_Temp4" +
                               ",Battery_Max_Temp5" +
                               ",Battery_Min_Temp5" +
                               ",Battery_Max_Temp6" +
                               ",Battery_Min_Temp6" +
                               ",Battery_Max_Temp7" +
                               ",Battery_Min_Temp7" +
                               ",Battery_Max_Temp8" +
                               ",Battery_Min_Temp8" +
                               ",Battery_Max_Temp9" +
                               ",Battery_Min_Temp9" +
                               ",Battery_Max_Temp10" +
                               ",Battery_Min_Temp10)";
                        sqlend += ",@Battery_Max_Cell_Voltage1" +
                                  ",@Battery_Min_Cell_Voltage1" +
                                  ",@Battery_Max_Cell_Voltage2" +
                                  ",@Battery_Min_Cell_Voltage2" +
                                  ",@Battery_Max_Cell_Voltage3" +
                                  ",@Battery_Min_Cell_Voltage3" +
                                  ",@Battery_Max_Cell_Voltage4" +
                                  ",@Battery_Min_Cell_Voltage4" +
                                  ",@Battery_Max_Cell_Voltage5" +
                                  ",@Battery_Min_Cell_Voltage5" +
                                  ",@Battery_Max_Cell_Voltage6" +
                                  ",@Battery_Min_Cell_Voltage6" +
                                  ",@Battery_Max_Cell_Voltage7" +
                                  ",@Battery_Min_Cell_Voltage7" +
                                  ",@Battery_Max_Cell_Voltage8" +
                                  ",@Battery_Min_Cell_Voltage8" +
                                  ",@Battery_Max_Cell_Voltage9" +
                                  ",@Battery_Min_Cell_Voltage9" +
                                  ",@Battery_Max_Cell_Voltage10" +
                                  ",@Battery_Min_Cell_Voltage10" +
                                  ",@Battery_Max_Temp1" +
                                  ",@Battery_Min_Temp1" +
                                  ",@Battery_Max_Temp2" +
                                  ",@Battery_Min_Temp2" +
                                  ",@Battery_Max_Temp3" +
                                  ",@Battery_Min_Temp3" +
                                  ",@Battery_Max_Temp4" +
                                  ",@Battery_Min_Temp4" +
                                  ",@Battery_Max_Temp5" +
                                  ",@Battery_Min_Temp5" +
                                  ",@Battery_Max_Temp6" +
                                  ",@Battery_Min_Temp6" +
                                  ",@Battery_Max_Temp7" +
                                  ",@Battery_Min_Temp7" +
                                  ",@Battery_Max_Temp8" +
                                  ",@Battery_Min_Temp8" +
                                  ",@Battery_Max_Temp9" +
                                  ",@Battery_Min_Temp9" +
                                  ",@Battery_Max_Temp10" +
                                  ",@Battery_Min_Temp10)";
                        sql += sqlend;
                    }
                    conn.Execute(sql, data);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"更新BATT0402_WEB失敗  時間: {data.ttimen} 封包類型: {data.BattName}-0402");
            }
        }
        /// <summary>
        /// 新增電池0403資料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool InserterBATT0403(BATT0403Data data)
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = $"INSERT INTO [BATT0403] (ttime,ttimen,imei,Longitude,Latitude,Speed,BattName";
                    string sqlend = " VALUES (@ttime,@ttimen,@imei,@Longitude,@Latitude,@Speed,@BattName";
                    sql += ",BMS1_mah_H" +
                           ",BMS1_mah_L" +
                           ",BMS2_mah_H" +
                           ",BMS2_mah_L" +
                           ",BMS3_mah_H" +
                           ",BMS3_mah_L" +
                           ",BMS4_mah_H" +
                           ",BMS4_mah_L" +
                           ",BMS5_mah_H" +
                           ",BMS5_mah_L" +
                           ",BMS6_mah_H" +
                           ",BMS6_mah_L" +
                           ",BMS7_mah_H" +
                           ",BMS7_mah_L" +
                           ",BMS8_mah_H" +
                           ",BMS8_mah_L" +
                           ",BMS9_mah_H" +
                           ",BMS9_mah_L" +
                           ",BMS10_mah_H" +
                           ",BMS10_mah_L" +
                           ",Battery_OV_Alarm " +
                           ",Battery_UV_Alarm " +
                           ",Battery_DIS_H_Alarm " +
                           ",Battery_DIS_L_Alarm " +
                           ",Battery_OV_Protection " +
                           ",Battery_UV_Protection " +
                           ",Battery_DIS_H_Protection " +
                           ",Battery_DIS_L_Protection " +
                           ",Battery_CHG_H_Alarm " +
                           ",Battery_CHG_L_Alarm " +
                           ",Battery_CHG_H_Protection " +
                           ",Battery_CHG_L_Protection " +
                           ",Temp_Fall_Off " +
                           ",DI_Status " +
                           ",DIS_A1_W " +
                           ",DIS_A1_P " +
                           ",CHG_A1_W " +
                           ",CHG_A1_P " +
                           ",DIS_A2_W " +
                           ",DIS_A2_P " +
                           ",CHG_A2_W " +
                           ",CHG_A2_P " +
                           ",BATT_OVW " +
                           ",BATT_OVP " +
                           ",BATT_UVW) ";
                    sqlend += ",@BMS1_mah_H" +
                              ",@BMS1_mah_L" +
                              ",@BMS2_mah_H" +
                              ",@BMS2_mah_L" +
                              ",@BMS3_mah_H" +
                              ",@BMS3_mah_L" +
                              ",@BMS4_mah_H" +
                              ",@BMS4_mah_L" +
                              ",@BMS5_mah_H" +
                              ",@BMS5_mah_L" +
                              ",@BMS6_mah_H" +
                              ",@BMS6_mah_L" +
                              ",@BMS7_mah_H" +
                              ",@BMS7_mah_L" +
                              ",@BMS8_mah_H" +
                              ",@BMS8_mah_L" +
                              ",@BMS9_mah_H" +
                              ",@BMS9_mah_L" +
                              ",@BMS10_mah_H" +
                              ",@BMS10_mah_L" +
                              ",@Battery_OV_Alarm " +
                              ",@Battery_UV_Alarm " +
                              ",@Battery_DIS_H_Alarm " +
                              ",@Battery_DIS_L_Alarm " +
                              ",@Battery_OV_Protection " +
                              ",@Battery_UV_Protection " +
                              ",@Battery_DIS_H_Protection " +
                              ",@Battery_DIS_L_Protection " +
                              ",@Battery_CHG_H_Alarm " +
                              ",@Battery_CHG_L_Alarm " +
                              ",@Battery_CHG_H_Protection " +
                              ",@Battery_CHG_L_Protection " +
                              ",@Temp_Fall_Off " +
                              ",@DI_Status " +
                              ",@DIS_A1_W " +
                              ",@DIS_A1_P " +
                              ",@CHG_A1_W " +
                              ",@CHG_A1_P " +
                              ",@DIS_A2_W " +
                              ",@DIS_A2_P " +
                              ",@CHG_A2_W " +
                              ",@CHG_A2_P " +
                              ",@BATT_OVW " +
                              ",@BATT_OVP " +
                              ",@BATT_UVW) ";
                    sql += sqlend;
                    conn.Execute(sql, data);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"新增BATT0403_LOG失敗  時間: {data.ttimen} 封包類型: {data.BattName}-0403");
                return false;
            }
        }
        /// <summary>
        /// 更新電池0403資料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void UpdateBATT0403web(BATT0403Data data)
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "";
                    var exsitforweb = conn.ExecuteScalar<bool>($"SELECT TOP 1 1 FROM BATTWeb WHERE imei = @imei AND BattName = @BattName", data);
                    if (exsitforweb)
                    {
                        sql = $"UPDATE [BATTWeb] SET ttime=@ttime" +
                              $",ttimen=@ttimen" +
                              $",Longitude=@Longitude" +
                              $",Latitude=@Latitude" +
                              $",Speed=@Speed" +
                              ",BMS1_mah_H=@BMS1_mah_H" +
                              ",BMS1_mah_L=@BMS1_mah_L" +
                              ",BMS2_mah_H=@BMS2_mah_H" +
                              ",BMS2_mah_L=@BMS2_mah_L" +
                              ",BMS3_mah_H=@BMS3_mah_H" +
                              ",BMS3_mah_L=@BMS3_mah_L" +
                              ",BMS4_mah_H=@BMS4_mah_H" +
                              ",BMS4_mah_L=@BMS4_mah_L" +
                              ",BMS5_mah_H=@BMS5_mah_H" +
                              ",BMS5_mah_L=@BMS5_mah_L" +
                              ",BMS6_mah_H=@BMS6_mah_H" +
                              ",BMS6_mah_L=@BMS6_mah_L" +
                              ",BMS7_mah_H=@BMS7_mah_H" +
                              ",BMS7_mah_L=@BMS7_mah_L" +
                              ",BMS8_mah_H=@BMS8_mah_H" +
                              ",BMS8_mah_L=@BMS8_mah_L" +
                              ",BMS9_mah_H=@BMS9_mah_H" +
                              ",BMS9_mah_L=@BMS9_mah_L" +
                              ",BMS10_mah_H=@BMS10_mah_H" +
                              ",BMS10_mah_L=@BMS10_mah_L" +
                              ",Battery_OV_Alarm=@Battery_OV_Alarm " +
                              ",Battery_UV_Alarm=@Battery_UV_Alarm " +
                              ",Battery_DIS_H_Alarm=@Battery_DIS_H_Alarm " +
                              ",Battery_DIS_L_Alarm=@Battery_DIS_L_Alarm " +
                              ",Battery_OV_Protection=@Battery_OV_Protection " +
                              ",Battery_UV_Protection=@Battery_UV_Protection " +
                              ",Battery_DIS_H_Protection=@Battery_DIS_H_Protection " +
                              ",Battery_DIS_L_Protection=@Battery_DIS_L_Protection " +
                              ",Battery_CHG_H_Alarm=@Battery_CHG_H_Alarm " +
                              ",Battery_CHG_L_Alarm=@Battery_CHG_L_Alarm " +
                              ",Battery_CHG_H_Protection=@Battery_CHG_H_Protection " +
                              ",Battery_CHG_L_Protection=@Battery_CHG_L_Protection " +
                              ",Temp_Fall_Off =@Temp_Fall_Off" +
                              ",DI_Status=@DI_Status " +
                              ",DIS_A1_W=@DIS_A1_W " +
                              ",DIS_A1_P=@DIS_A1_P " +
                              ",CHG_A1_W=@CHG_A1_W " +
                              ",CHG_A1_P=@CHG_A1_P " +
                              ",DIS_A2_W=@DIS_A2_W " +
                              ",DIS_A2_P=@DIS_A2_P " +
                              ",CHG_A2_W=@CHG_A2_W " +
                              ",CHG_A2_P=@CHG_A2_P " +
                              ",BATT_OVW=@BATT_OVW " +
                              ",BATT_OVP=@BATT_OVP " +
                              ",BATT_UVW=@BATT_UVW " +
                              " WHERE imei=@imei AND BattName=@BattName";
                    }
                    else
                    {
                        sql = $"INSERT INTO [BATTWeb] (ttime,ttimen,imei,Longitude,Latitude,Speed,BattName";
                        string sqlend = " VALUES (@ttime,@ttimen,@imei,@Longitude,@Latitude,@Speed,@BattName";
                        sql += ",BMS1_mah_H" +
                               ",BMS1_mah_L" +
                               ",BMS2_mah_H" +
                               ",BMS2_mah_L" +
                               ",BMS3_mah_H" +
                               ",BMS3_mah_L" +
                               ",BMS4_mah_H" +
                               ",BMS4_mah_L" +
                               ",BMS5_mah_H" +
                               ",BMS5_mah_L" +
                               ",BMS6_mah_H" +
                               ",BMS6_mah_L" +
                               ",BMS7_mah_H" +
                               ",BMS7_mah_L" +
                               ",BMS8_mah_H" +
                               ",BMS8_mah_L" +
                               ",BMS9_mah_H" +
                               ",BMS9_mah_L" +
                               ",BMS10_mah_H" +
                               ",BMS10_mah_L" +
                               ",Battery_OV_Alarm " +
                               ",Battery_UV_Alarm " +
                               ",Battery_DIS_H_Alarm " +
                               ",Battery_DIS_L_Alarm " +
                               ",Battery_OV_Protection " +
                               ",Battery_UV_Protection " +
                               ",Battery_DIS_H_Protection " +
                               ",Battery_DIS_L_Protection " +
                               ",Battery_CHG_H_Alarm " +
                               ",Battery_CHG_L_Alarm " +
                               ",Battery_CHG_H_Protection " +
                               ",Battery_CHG_L_Protection " +
                               ",Temp_Fall_Off " +
                               ",DI_Status " +
                               ",DIS_A1_W " +
                               ",DIS_A1_P " +
                               ",CHG_A1_W " +
                               ",CHG_A1_P " +
                               ",DIS_A2_W " +
                               ",DIS_A2_P " +
                               ",CHG_A2_W " +
                               ",CHG_A2_P " +
                               ",BATT_OVW " +
                               ",BATT_OVP " +
                               ",BATT_UVW) ";
                        sqlend += ",@BMS1_mah_H" +
                                  ",@BMS1_mah_L" +
                                  ",@BMS2_mah_H" +
                                  ",@BMS2_mah_L" +
                                  ",@BMS3_mah_H" +
                                  ",@BMS3_mah_L" +
                                  ",@BMS4_mah_H" +
                                  ",@BMS4_mah_L" +
                                  ",@BMS5_mah_H" +
                                  ",@BMS5_mah_L" +
                                  ",@BMS6_mah_H" +
                                  ",@BMS6_mah_L" +
                                  ",@BMS7_mah_H" +
                                  ",@BMS7_mah_L" +
                                  ",@BMS8_mah_H" +
                                  ",@BMS8_mah_L" +
                                  ",@BMS9_mah_H" +
                                  ",@BMS9_mah_L" +
                                  ",@BMS10_mah_H" +
                                  ",@BMS10_mah_L" +
                                  ",@Battery_OV_Alarm " +
                                  ",@Battery_UV_Alarm " +
                                  ",@Battery_DIS_H_Alarm " +
                                  ",@Battery_DIS_L_Alarm " +
                                  ",@Battery_OV_Protection " +
                                  ",@Battery_UV_Protection " +
                                  ",@Battery_DIS_H_Protection " +
                                  ",@Battery_DIS_L_Protection " +
                                  ",@Battery_CHG_H_Alarm " +
                                  ",@Battery_CHG_L_Alarm " +
                                  ",@Battery_CHG_H_Protection " +
                                  ",@Battery_CHG_L_Protection " +
                                  ",@Temp_Fall_Off " +
                                  ",@DI_Status " +
                                  ",@DIS_A1_W " +
                                  ",@DIS_A1_P " +
                                  ",@CHG_A1_W " +
                                  ",@CHG_A1_P " +
                                  ",@DIS_A2_W " +
                                  ",@DIS_A2_P " +
                                  ",@CHG_A2_W " +
                                  ",@CHG_A2_P " +
                                  ",@BATT_OVW " +
                                  ",@BATT_OVP " +
                                  ",@BATT_UVW) ";
                        sql += sqlend;
                    }
                    conn.Execute(sql, data);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"更新BATT0403_WEB失敗  時間: {data.ttimen} 封包類型: {data.BattName}-0403");
            }
        }
        /// <summary>
        /// 新增電池0404資料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool InserterBATT0404(BATT0404Data data)
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = $"INSERT INTO [BATT0404] (ttime,ttimen,imei,Longitude,Latitude,Speed,BattName";
                    string sqlend = " VALUES (@ttime,@ttimen,@imei,@Longitude,@Latitude,@Speed,@BattName";
                    sql += ",BATT_UVP" +
                           ",BMS1_BMS2" +
                           ",BMS3_BMS4" +
                           ",BMS5_BMS6" +
                           ",BMS7_BMS8" +
                           ",BMS9_BMS10" +
                           ",BMS1_Status" +
                           ",BMS2_Status" +
                           ",BMS3_Status" +
                           ",BMS4_Status" +
                           ",BMS5_Status" +
                           ",BMS6_Status" +
                           ",BMS7_Status" +
                           ",BMS8_Status" +
                           ",BMS9_Status" +
                           ",BMS10_Status)";
                    sqlend += ",@BATT_UVP" +
                              ",@BMS1_BMS2" +
                              ",@BMS3_BMS4" +
                              ",@BMS5_BMS6" +
                              ",@BMS7_BMS8" +
                              ",@BMS9_BMS10" +
                              ",@BMS1_Status" +
                              ",@BMS2_Status" +
                              ",@BMS3_Status" +
                              ",@BMS4_Status" +
                              ",@BMS5_Status" +
                              ",@BMS6_Status" +
                              ",@BMS7_Status" +
                              ",@BMS8_Status" +
                              ",@BMS9_Status" +
                              ",@BMS10_Status)";
                    sql += sqlend;
                    conn.Execute(sql, data);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"新增BATT0404_LOG失敗  時間: {data.ttimen} 封包類型: {data.BattName}-0404");
                return false;
            }
        }
        /// <summary>
        /// 更新電池0404資料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void UpdateBATT0404web(BATT0404Data data)
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "";
                    var exsitforweb = conn.ExecuteScalar<bool>($"SELECT TOP 1 1 FROM BATTWeb WHERE imei = @imei AND BattName = @BattName", data);
                    if (exsitforweb)
                    {
                        sql = $"UPDATE [BATTWeb] SET ttime=@ttime" +
                              $",ttimen=@ttimen" +
                              $",Longitude=@Longitude" +
                              $",Latitude=@Latitude" +
                              $",Speed=@Speed" +
                              ",BATT_UVP=@BATT_UVP" +
                              ",BMS1_BMS2=@BMS1_BMS2" +
                              ",BMS3_BMS4=@BMS3_BMS4" +
                              ",BMS5_BMS6=@BMS5_BMS6" +
                              ",BMS7_BMS8=@BMS7_BMS8" +
                              ",BMS9_BMS10=@BMS9_BMS10" +
                              ",BMS1_Status=@BMS1_Status" +
                              ",BMS2_Status=@BMS2_Status" +
                              ",BMS3_Status=@BMS3_Status" +
                              ",BMS4_Status=@BMS4_Status" +
                              ",BMS5_Status=@BMS5_Status" +
                              ",BMS6_Status=@BMS6_Status" +
                              ",BMS7_Status=@BMS7_Status" +
                              ",BMS8_Status=@BMS8_Status" +
                              ",BMS9_Status=@BMS9_Status" +
                              ",BMS10_Status=@BMS10_Status" +
                              " WHERE imei=@imei AND BattName=@BattName";
                    }
                    else
                    {
                        sql = $"INSERT INTO [BATTWeb] (ttime,ttimen,imei,Longitude,Latitude,Speed,BattName";
                        string sqlend = " VALUES (@ttime,@ttimen,@imei,@Longitude,@Latitude,@Speed,@BattName";
                        sql += ",BATT_UVP" +
                               ",BMS1_BMS2" +
                               ",BMS3_BMS4" +
                               ",BMS5_BMS6" +
                               ",BMS7_BMS8" +
                               ",BMS9_BMS10" +
                               ",BMS1_Status" +
                               ",BMS2_Status" +
                               ",BMS3_Status" +
                               ",BMS4_Status" +
                               ",BMS5_Status" +
                               ",BMS6_Status" +
                               ",BMS7_Status" +
                               ",BMS8_Status" +
                               ",BMS9_Status" +
                               ",BMS10_Status)";
                        sqlend += ",@BATT_UVP" +
                                  ",@BMS1_BMS2" +
                                  ",@BMS3_BMS4" +
                                  ",@BMS5_BMS6" +
                                  ",@BMS7_BMS8" +
                                  ",@BMS9_BMS10" +
                                  ",@BMS1_Status" +
                                  ",@BMS2_Status" +
                                  ",@BMS3_Status" +
                                  ",@BMS4_Status" +
                                  ",@BMS5_Status" +
                                  ",@BMS6_Status" +
                                  ",@BMS7_Status" +
                                  ",@BMS8_Status" +
                                  ",@BMS9_Status" +
                                  ",@BMS10_Status)";
                        sql += sqlend;
                    }
                    conn.Execute(sql, data);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"更新BATT0404_WEB失敗  時間: {data.ttimen} 封包類型: {data.BattName}-0404");
            }
        }
        #endregion
    }
}
