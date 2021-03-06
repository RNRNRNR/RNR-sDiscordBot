﻿using Discord.WebSocket;
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
        
        public static UserAcc GetGuildAcc(ulong id)
        {
            return GetOrCreateAccount(id);
        }

        public static UserAcc GetAccount(SocketUser user)
        {
            return GetOrCreateAccount(user.Id);
        }

        private static UserAcc GetOrCreateAccount(ulong id) //Find acc from base, if no create it
        {
            var result = from a in accounts
                         where a.userID == id
                         select a;
            var account = result.FirstOrDefault();
            if (account == null) account = CreateUserAccount(id);
            return account;
        }

        public static void ExpSystematizator(ulong id) //lvling system
        {
            var acc = GetOrCreateAccount(id);

            if (acc.XP > acc.LVL * acc.LVL * 20)
            {
                acc.LVL++;
                acc.Points += 10 * acc.LVL / 10;
            }

            acc.XP += 1 * (3 / acc.LVL);

            SaveAccounts();
        }

        private static UserAcc CreateUserAccount(ulong id)
        {
            var newAccount = new UserAcc()
            {
                userID = id,
                Points = 10,
                XP = 0,
                LVL = 1
            };
            accounts.Add(newAccount);
            SaveAccounts();
            return newAccount;
        }

    }
}
