using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using KipoBot.Services;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using KipoBot.Modules;
using KipoBot.Utils;

namespace KipoBot
{
    class Program
    {
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            String[] reqPaths = {"data","fonts","banners"};

            foreach (var path in reqPaths)
            {
                if (!Helpers.AssertDirectory(path))
                    return;
            }

            if (!ConfigurationService.AssertConfigFile())
            {
                Console.WriteLine($"Template config file created in {Helpers.WORKING_DIRECTORY}/config.json\nEdit it and rerun Kipo.");
                return;
            }

            Console.WriteLine("Found config!");

            ImageMaker.loadBanners($"banners/");

            using (var services = ConfigureServices())
            {
                var client = services.GetRequiredService<DiscordSocketClient>();
                var config = services.GetRequiredService<ConfigurationService>();
                var database = services.GetRequiredService<DatabaseService>();

                client.Log += LogAsync;
                services.GetRequiredService<CommandService>().Log += LogAsync;

                await client.LoginAsync(TokenType.Bot, config.token);
                await client.StartAsync();

                await services.GetRequiredService<CommandHandlingService>().InitializeAsync();
                await client.SetGameAsync(config.prefix + "help");
                
                startJobManager();
                await Task.Delay(-1);
            }
        }

        private void startJobManager()
        {
            Thread jobManager = new Thread(WorkManager.Start);
            WorkManager.running = true;
            jobManager.Start();
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());

            return Task.CompletedTask;
        }

        private ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddSingleton(new DiscordSocketClient(new DiscordSocketConfig
                {
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
                .AddSingleton<DatabaseService>()
                .BuildServiceProvider();
        }
    }
}
