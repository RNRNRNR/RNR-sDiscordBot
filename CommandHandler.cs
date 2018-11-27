using System;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord.Commands;
using System.Reflection;

namespace RNR_sDiscordBot
{
    class CommandHandler
    {
        DiscordSocketClient client;
        CommandService service;

        public async Task InitializeAsync(DiscordSocketClient client)
        {
            this.client = client;
            service = new CommandService();
            await service.AddModulesAsync(Assembly.GetEntryAssembly());
            client.MessageReceived += HandleCommandAsync; //get msg from chat
        }

        private async Task HandleCommandAsync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
            if (msg == null) return;
            var context = new SocketCommandContext(client, msg);
            int argPos = 0;
            if (msg.HasStringPrefix(Config.bot.cmdPrefix, ref argPos)
                || msg.HasMentionPrefix(client.CurrentUser, ref argPos))
            {
                var result = await service.ExecuteAsync(context, argPos);
                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)// error results
                {
                    Console.WriteLine($"[{DateTime.Now}] "+result.ErrorReason);
                }
            }
        }
    }
}
