using Discord.Commands;
using RNR_sDiscordBot.Core.UserAccs;
using System.Threading.Tasks;

namespace RNR_sDiscordBot.Modules
{
    class StatsCommands : ModuleBase<SocketCommandContext>
    {
        [Command("myStats")]
        public async Task ewaQ() // check the user stats or create the acc in database
        {
            var account = UserAccs.GetAccount(Context.User);
            string msg = Utilities.GetFormattedAlert("statinfo", Context.User.Username, account.XP, account.Points);
            await Context.Channel.SendMessageAsync(msg);
        }
    }
}
