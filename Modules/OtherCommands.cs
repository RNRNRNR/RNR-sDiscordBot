using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RNR_sDiscordBot.Modules
{
    public class OtherCommands : ModuleBase<SocketCommandContext>
    {
        #region GetChats
        [Command("getchats")]
        public async Task GetChats() // get the all txt channels 
        {
            var txtchannels = Context.Guild.TextChannels;
            Dictionary<int, string> text = ChannelGetter(txtchannels);

        }
        private Dictionary<int, string> ChannelGetter(IReadOnlyCollection<SocketTextChannel> channels)
        {
            Dictionary<int, string> data = new Dictionary<int, string>();
            int countOfElements = 1;
            foreach (var channel in channels)
            {
                data.Add(countOfElements, channel.Name);
                countOfElements++;
            }
            VariantSender(data);
            return data;
        }
        public async Task VariantSender(Dictionary<int, string> data)
        {
            string FormatedList = "";
            foreach (var element in data)
            {
                FormatedList += $"{element.Key}){element.Value}\n";
            }
            await Context.Channel.SendMessageAsync(FormatedList);
        }
        #endregion GetChats
        #region ClearChat
        [Command("clear")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task ClearChat()
        {
            int deletcount = 0;
            await Context.Message.DeleteAsync();
            var aMsgs = Context.Channel.GetMessagesAsync(100);
            var msgs = await aMsgs.Flatten();
            foreach (var msg in msgs)
            {
                if ((msg.Content.Contains("=") || msg.Content.Contains("~") || msg.Content.Contains(">")) && !msg.Author.IsBot)
                {
                    await msg.DeleteAsync();
                    await Task.Delay(500);
                }
                deletcount++;
            }
            Console.WriteLine(Utilities.GetTime() + $"Deleted{deletcount.ToString()} messages");
        }
        #endregion ClearChat
        //not realized
        #region helpCommand
        [Command("help")]
        public async Task helper()
        {

        }
        #endregion
        //not realized
    }
}
