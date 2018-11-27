using Discord;
using Discord.Commands;
using Discord.WebSocket;
using RNR_sDiscordBot.Core.UserAccs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RNR_sDiscordBot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        [Command("myStats")]
        public async Task ewaQ()
        {
            var account = UserAccs.GetAccount(Context.User);
            await Context.Channel.SendMessageAsync($"U have {account.userID}-id and some{account.XP} XP, with {account.Points} points");
        }
        [Command("viva")]
        [RequireUserPermission(ChannelPermission.ManageChannel)]
        public async Task Vived()
        {
            var user = Context.User.Username;
            var formatedmsg = Utilities.GetFormattedAlert("xomrade", user);
            await Context.Channel.SendMessageAsync(formatedmsg);
        }
        [Command("crusade")]
        public async Task Crusade()
        {
            //ulong id = 402882481625366540;
            var channels = Context.Guild.TextChannels;
            foreach(var channel in channels)
            {
                await Context.Channel.SendMessageAsync(channel.Name);
            }


        }
    }
}
