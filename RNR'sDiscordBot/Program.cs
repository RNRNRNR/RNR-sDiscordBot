using System;
using System.Threading.Tasks;
using Discord.WebSocket;
using Newtonsoft.Json;
using Discord;

namespace RNR_sDiscordBot
{
    class Program
    {
        DiscordSocketClient client;
        CommandHandler handler;

        static void Main(string[] args) => new Program().StartAsync().GetAwaiter().GetResult();

        private async Task StartAsync()
        {
            if (Config.bot.token == null || Config.bot.token == "") return;
            client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });
            client.Log += Log;
            
            await client.LoginAsync(TokenType.Bot, Config.bot.token);
            await client.StartAsync();
            handler = new CommandHandler();
            await handler.InitializeAsync(client);
            await Task.Delay(-1);

        }

        private async Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.Message);
        }
    }
}
