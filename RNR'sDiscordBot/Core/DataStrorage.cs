using Newtonsoft.Json;
using RNR_sDiscordBot.Core.UserAccs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNR_sDiscordBot.Core
{
    class DataStrorage
    {
        public static void SaveUserAccounts(IEnumerable<UserAcc> accounts, string filePath)
        {
            string json = JsonConvert.SerializeObject(accounts);
            File.WriteAllText(filePath, json);
        }

        public static IEnumerable<UserAcc> LoadUserAccounts(string filePath)
        {
            if (!File.Exists(filePath)) return null;
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<UserAcc>>(json);
        }

        public static bool SaveExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
