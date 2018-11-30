using Discord.Commands;
using Discord.WebSocket;
using RNR_sDiscordBot.Core.UserAccs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNR_sDiscordBot.Modules
{
    public class StatsCommands : ModuleBase<SocketCommandContext>
    {
        [Command("mystats")]
        public async Task ewaQ() // check the user stats or create the acc in database
        {
            var account = UserAccs.GetAccount(Context.User);
            string msg = Utilities.GetFormattedAlert("statinfo", Context.User.Username, (int)account.XP, account.Points);
            await Context.Channel.SendMessageAsync(msg);
            await Context.Message.DeleteAsync();
        }

        [Command("mylvl")]
        public async Task lvler()// get lvl of user
        {
            var account = UserAccs.GetAccount(Context.User);
            string msg = Utilities.GetFormattedAlert("lvlinfo", account.LVL);
            await Context.Channel.SendMessageAsync(msg);
        }

        [Command("tip")]
        public async Task tip(string mention, string value)
        {
            if (int.TryParse(value, out int tipvalue) && mention != "@everyone" && mention != "@here")
            {
                var user = GetUserIdByMention(mention);

                Console.WriteLine(Utilities.GetTime() + user.Nickname + $" +{tipvalue}");

                var account = UserAccs.GetGuildAcc(user.Id);
                var accounttipper = UserAccs.GetAccount(Context.User);

                if(accounttipper.Points<tipvalue)
                {
                    await Context.Channel.SendMessageAsync($"U need{tipvalue - accounttipper.Points}");
                    return;
                }
                Console.WriteLine("ok");
                accounttipper.Points -= tipvalue;
                account.Points += tipvalue;
                await Context.Channel.SendMessageAsync(Utilities.GetFormattedAlert("tipinfo", user.Nickname, tipvalue.ToString()));
                UserAccs.SaveAccounts();
            }
        }

        public SocketGuildUser GetUserIdByMention(string mention)
        {
            if (!mention.Contains("!")) mention = mention.Insert(2, "!");

            var users = Context.Guild.Users;
            var tipuser = from r in users
                          where r.Mention == mention
                          select r;
            return tipuser.First();
        }
    }
}