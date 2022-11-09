using GPS_TCP_Server.Configuration;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS_TCP_Server.Methods
{
    public class InitailMethod
    {
        /// <summary>
        /// 工作路徑
        /// </summary>
        private static readonly string WorkPath = AppDomain.CurrentDomain.BaseDirectory;
        #region 系統資訊
        /// <summary>
        /// 讀取系統資訊
        /// </summary>
        /// <returns></returns>
        public static SystemSetting System_Load()
        {
            SystemSetting settings = null;
            if (!Directory.Exists($"{WorkPath}\\stf"))
                Directory.CreateDirectory($"{WorkPath}\\stf");
            string setFile = $"{WorkPath}\\stf\\System.json";
            try
            {
                if (File.Exists(setFile))
                {
                    string json = File.ReadAllText(setFile, Encoding.UTF8);
                    settings = JsonConvert.DeserializeObject<SystemSetting>(json);
                }
                else
                {
                    settings = new SystemSetting
                    {
                        Server_Port = "4664",
                        ServerIp = "127.0.0.1",
                        Database = "GPSDB",
                        UserId = "sa",
                        UserPwd = "1234",
                    };
                    string output = JsonConvert.SerializeObject(settings, Formatting.Indented, new JsonSerializerSettings());
                    File.WriteAllText(setFile, output);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "讀取系統資訊失敗");
            }
            return settings;
        }
        /// <summary>
        /// 儲存系統資訊
        /// </summary>
        /// <param name="setting"></param>
        public static void System_Save(SystemSetting setting)
        {
            if (!Directory.Exists($"{WorkPath}\\stf"))
                Directory.CreateDirectory($"{WorkPath}\\stf");
            string setFile = $"{WorkPath}\\stf\\System.json";
            string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
            File.WriteAllText(setFile, output);
        }
        #endregion
    }
}
