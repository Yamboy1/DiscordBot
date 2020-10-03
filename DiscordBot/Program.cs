using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DiscordBot
{
    class Program
    {
        private DiscordSocketClient _client;

        static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        private async Task MainAsync()
        {
            await using ServiceProvider services = Initialize.BuildServiceProvider();
            
            _client = services.GetService<DiscordSocketClient>();
            _client.Log += Log;

            await _client.LoginAsync(TokenType.Bot, services.GetService<BotConfig>().Token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}