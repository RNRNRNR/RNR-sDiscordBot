using Discord.Commands;
using RNR_sDiscordBot.Core.UserAccs;
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
    }
}
