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
            Console.WriteLine(mention);
            if (int.TryParse(value, out int tipvalue))
            {

                try
                {
                    var users = GetUserIdByMention(mention);

                    foreach (var user in users)
                    {
                        Console.WriteLine(Utilities.GetTime()+user.Nickname+$" +{tipvalue}");
                        var account = UserAccs.GetGuildAcc(user.Id);
                        account.Points += tipvalue;
                        await Context.Channel.SendMessageAsync(Utilities.GetFormattedAlert("tipinfo", user.Nickname, tipvalue.ToString()));
                        UserAccs.SaveAccounts();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public IEnumerable<SocketGuildUser> GetUserIdByMention(string mention)
        {
            if(!mention.Contains("!")) mention = mention.Insert(2, "!");
            var users = Context.Guild.Users;
            var tipusers = from r in users
                           where r.Mention == mention
                           select r;
            return tipusers;
        }
    }
}
