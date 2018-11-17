using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNR_sDiscordBot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        [Command("kot")]
        public async Task ewaQ()
        {
            await Context.Channel.SendMessageAsync("DIEWORDK");
            await Context.Message.DeleteAsync();
        }
        [Command("viva")]
        [RequireUserPermission(ChannelPermission.ManageChannel)]
        public async Task Vived()
        {
            var user = Context.User.Username;
            var formatedmsg = Utilities.GetFormattedAlert("xomrade", user);
            await Context.Channel.SendMessageAsync(formatedmsg);
        }
    }
}
