using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNR_sDiscordBot
{

    class Utilities
    {
        private static Dictionary<string, string> alerts;
        static Utilities()
        {
            string jsonfile = File.ReadAllText("SystemLang/alerts.json");
            var data = JsonConvert.DeserializeObject<dynamic>(jsonfile);
            alerts = data.ToObject<Dictionary<string, string>>();
        }
        public static string GetAlert(string key)
        {
            if (alerts.ContainsKey(key)) return alerts[key];
            return "";
        }
    }
}
