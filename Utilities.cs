using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace RNR_sDiscordBot
{

    class Utilities
    {
        private static Dictionary<string, string> alerts;
        static Utilities()//get the inf from json files
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

        public static string GetFormattedAlert(string key, params object[] parameter)// for formating the inf from json files like a "Who {0}",var
        {
            if (alerts.ContainsKey(key))
            {
                return String.Format(alerts[key], parameter);
            }
            return "";
        }

        public static string GetFormattedAlert(string key, object parameter)
        {
            return GetFormattedAlert(key,new object[] { parameter });
        }
    }
}
