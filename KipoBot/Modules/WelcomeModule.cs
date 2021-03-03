using Discord.Commands;
using Discord.WebSocket;
using KipoBot.Services;
using KipoBot.Utils;
using System.IO;
using System.Threading.Tasks;

namespace KipoBot.Modules
{
    [Group("welcome")]
    [Name("welcome")]
    [Summary("Contains all needed commands to configure a welcome message.")]
    public class WelcomeModule : ModuleBase<SocketCommandContext>
    {
        private readonly DatabaseService database;

        public WelcomeModule(DatabaseService _database)
        {
            database = _database;
        }

        [Command("disable", RunMode = RunMode.Async)]
        [Summary("Disabled welcome module.")]
        public async Task Disable()
        {
            if (database.servers != null && database.servers.Count != 0)
            {
                foreach (var server in database.servers)
                {
                    if (server.id == Context.Guild.Id)
                    {
                        database.servers.Remove(server);
                        await Context.Channel.SendMessageAsync("Welcome module has been disabled!");
                        return;
                    }
                }
            }
            else
            {
                await Context.Channel.SendMessageAsync("Enable the welcome module first!");
            }
        }

        [Command("enable", RunMode = RunMode.Async)]
        [Summary("Enables welcome module.\n+welcome enable [#channel]")]
        public async Task Enable(SocketTextChannel channel = null)
        {
            if (channel == null)
            {
                await Context.Channel.SendMessageAsync("Channel not found!\n+enable <#channel>");
            }
            else
            {
                if (database.servers != null && database.servers.Count != 0)
                {
                    foreach (var server in database.servers)
                    {
                        if (server.id == Context.Guild.Id)
                        {
                            await Context.Channel.SendMessageAsync("Welcome module is already enabled!");
                        }
                    }
                }
                else
                {
                    await database.AddServer(Context.Guild.Id, channel.Id);
                    await Context.Channel.SendMessageAsync("Welcome module has been enabled! Check other commands to configure the caption on the image and the text message.");
                }
            }
        }
        [Command("preview", RunMode = RunMode.Async)]
        [Summary("Sends welcome message to the channel the command is executed in.")]
        public async Task Preview()
        {
            foreach (var server in database.servers)
            {
                if (server.id == Context.Guild.Id)
                {
                    if (server.channel_id != null)
                    {
                        Stream file = ImageMaker.welcomeUser(Context.User.Username, server.caption, Context.Guild.Name);
                        await Context.Channel.SendMessageAsync("Message will be send in channel <#" + server.channel_id + "> when new user joins.");
                        await Context.Channel.SendFileAsync(file, "welcome.png", $"{server.message.Replace("%MENTION%", $"{Context.User.Mention}").Replace("%USERNAME%", $"{Context.User.Username}").Replace("%SERVERNAME%", $"{Context.Guild.Name}")}");
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Enable the welcome module first!");
                    }
                }
            }
        }

        [Command("channel", RunMode = RunMode.Async)]
        [Summary("Sets text channel to send the welcome message to.\n+welcome channel <#channel>")]
        public async Task SetChannel(SocketTextChannel channel)
        {
            if (channel == null)
            {
                await Context.Channel.SendMessageAsync("Channel not found!\n+welcome channel <#channel>");
            }
            else
            {
                foreach (var server in database.servers)
                {
                    if (server.id == Context.Guild.Id)
                    {
                        if (server.channel_id != null)
                        {
                            server.channel_id = channel.Id;
                        }
                        else
                        {
                            await Context.Channel.SendMessageAsync("Enable the welcome module first!");
                        }
                    }
                }
            }
        }

        [Command("message", RunMode = RunMode.Async)]
        [Summary("Sets the text message in image describtion.\n+welcome message [text]")]
        public async Task SetWelcomeBannerDesc([Remainder] string text)
        {
            foreach (var server in database.servers)
            {
                if (server.id == Context.Guild.Id)
                {
                    if (server.channel_id != null)
                    {
                        server.message = text;
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Enable the welcome module first!");
                    }
                }
            }
        }

        [Command("caption", RunMode = RunMode.Async)]
        [Summary("Sets the text on the image.\n+welcome caption [text]")]
        public async Task SetWelcomeBannerText([Remainder] string text)
        {
            foreach (var server in database.servers)
            {
                if (server.id == Context.Guild.Id)
                {
                    if (server.channel_id != null)
                    {
                        server.caption = text;
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Enable the welcome module first!");
                    }
                }
            }
        }
    }
}