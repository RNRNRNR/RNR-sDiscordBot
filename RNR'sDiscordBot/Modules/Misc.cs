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
        }
    }
}
