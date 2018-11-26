using Discord.WebSocket;
using System.Collections.Generic;
using System.Linq;

namespace RNR_sDiscordBot.Core.UserAccs
{
    class UserAccs
    {
        private static List<UserAcc> accounts;

        private static string accsFile = "Resources/accounts.json";
        static UserAccs()
        {
            if (DataStrorage.SaveExists(accsFile))
            {
                accounts = DataStrorage.LoadUserAccounts(accsFile).ToList();
            }
            else
            {
                accounts = new List<UserAcc>();
                SaveAccounts();
            }
        }

        public static void SaveAccounts()
        {
            DataStrorage.SaveUserAccounts(accounts, accsFile);
        }

        public static UserAcc GetAccount(SocketUser user)
        {
            return GetOrCreateAccount(user.Id);
        }

        private static UserAcc GetOrCreateAccount(ulong id)
        {
            var result = from a in accounts
                         where a.userID == id
                         select a;
            var account = result.FirstOrDefault();
            if (account == null) account = CreateUserAccount(id);
            return account;
        }
        private static UserAcc CreateUserAccount(ulong id)
        {
            var newAccount = new UserAcc()
            {
                userID = id,
                Points = 10,
                XP = 0
            };
            accounts.Add(newAccount);
            SaveAccounts();
            return newAccount;
        }

    }
}
