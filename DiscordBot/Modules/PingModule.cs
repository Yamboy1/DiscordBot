using System.Threading.Tasks;
using Discord.Commands;

namespace DiscordBot.Modules
{
    public class PingModule : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        [Summary("Ping Pong!")]
        public async Task PingAsync()
        {
            await Context.Channel.SendMessageAsync("Pong! 🏓");
        }
    }
}