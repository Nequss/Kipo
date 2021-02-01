using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Kipo.Modules;
using KipoBot.Services;
using System.IO;
using System.Linq;
using KipoBot.Database;

namespace KipoBot
{
    class Program
    {
        Manager manager = new Manager();

        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            ImageMaker.loadBanners($"banners/");
            
            using (var services = ConfigureServices())
            {
                var client = services.GetRequiredService<DiscordSocketClient>();
                var config = services.GetRequiredService<ConfigurationService>();

                client.Log += LogAsync;
                services.GetRequiredService<CommandService>().Log += LogAsync;

                await client.LoginAsync(TokenType.Bot, config.token);
                await client.StartAsync();

                await services.GetRequiredService<CommandHandlingService>().InitializeAsync();
                await client.SetGameAsync(config.prefix + "help");

                client.UserJoined += UserJoined;

                await Task.Delay(-1);
            }
        }

        private Task UserJoined(SocketGuildUser user)
        {
            string results = manager.GetWelcome(user.Guild.Id.ToString()).Result;

            if (results == String.Empty)
            {
                return Task.CompletedTask;
            }
            else
            {
                string[] data = results.Split(";");
                SocketTextChannel channel = user.Guild.GetTextChannel(UInt64.Parse(data[0]));
                Stream file = ImageMaker.welcomeUser(user.Username);
                channel.SendFileAsync(file, "welcome.png", "Welcome to the " + user.Guild.Name + "! " + user.Mention);
                return Task.CompletedTask;
            }
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());

            return Task.CompletedTask;
        }

        private ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddSingleton(new DiscordSocketClient(new DiscordSocketConfig {
                    MessageCacheSize = 100,
                    ExclusiveBulkDelete = true,
                    LogLevel = LogSeverity.Debug
                }))
                .AddSingleton(new CommandService(new CommandServiceConfig
                {
                    LogLevel = LogSeverity.Debug
                }))
                .AddSingleton<CommandHandlingService>()
                .AddSingleton<HttpClient>()
                .AddSingleton<ConfigurationService>()
                .BuildServiceProvider();
        }
    }
}
