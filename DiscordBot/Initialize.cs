using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

using Discord.Commands;
using Discord.WebSocket;

using DiscordBot.Services;
using Microsoft.Extensions.Options;

namespace DiscordBot
{
    public class BotConfig
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string Prefix { get; set; }
    }

    public static class Initialize
    {

        public static IConfiguration BuildConfiguration() => new ConfigurationBuilder()
            .AddEnvironmentVariables("DiscordBot_")
            .Build();

        public static ServiceProvider BuildServiceProvider()
        {
            ServiceCollection services = new ServiceCollection();
            
            services.AddSingleton<DiscordSocketClient>();
            services.AddSingleton<CommandService>();
            services.AddSingleton<CommandHandlingService>();
            
            // Register IOptions object
            services.AddOptions<BotConfig>()
                .Bind(BuildConfiguration())
                .ValidateDataAnnotations();
            // Explicitly register the settings object
            services.AddSingleton(resolver => 
                resolver.GetRequiredService<IOptions<BotConfig>>().Value);
            
            return services.BuildServiceProvider();
        }
    }
}