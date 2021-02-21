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
using CLI_Sharp;
using KipoBot.Modules;
using KipoBot.Utils;
using Discord.Addons.Interactive;
using Newtonsoft.Json.Linq;

namespace KipoBot
{
    class Program
    {
        private static CommandProcessor p = new CommandProcessor();
        public static Logger Logger = new Logger();
        public static ConsoleDisplay c = new ConsoleDisplay(Logger,p);
        
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            c.title = "KipoBot";
            //c.start();
            
            String[] reqPaths = {"data","fonts","banners"};

            foreach (var path in reqPaths)
            {
                if (!Helpers.AssertDirectory(path))
                    return;
            }

            if (!ConfigurationService.AssertConfigFile())
            {
                Logger.info($"Template config file created in {Helpers.WORKING_DIRECTORY}/config.json\nEdit it and rerun Kipo.");
                return;
            }

            Logger.info("Found config!");

            ImageMaker.loadBanners($"banners/");

            using (var services = ConfigureServices())
            {
                var client = services.GetRequiredService<DiscordSocketClient>();
                var config = services.GetRequiredService<ConfigurationService>();
                var database = services.GetRequiredService<DatabaseService>();
                var interactive = services.GetRequiredService<InteractiveService>();

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
            Logger.info(log.Message);

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
                .AddSingleton<InteractiveService>()
                .BuildServiceProvider();
        }
    }
}
