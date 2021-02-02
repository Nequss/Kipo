using Discord;
using Discord.Webhook;
using Discord.WebSocket;
using Discord.Commands;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using ImageMagick;
using KipoBot.Database;
using KipoBot.Services;
using KipoBot.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Kipo.Modules;

namespace KipoBot.Modules
{
    [Group("set welcome")]
    [Name("welcome")]
    [Summary("Contains all needed commands to configure a welcome message.")]
    public class WelcomeModule : ModuleBase<SocketCommandContext>
    {
        Manager manager = new Manager();

        [Command("enable", RunMode = RunMode.Async)]
        [Summary("summary")]
        public async Task Enable(SocketTextChannel channel) => await manager.InsertWelcome(Context.Guild.Id.ToString(), channel.Id.ToString());

        [Command("disable", RunMode = RunMode.Async)]
        [Summary("summary")]
        public async Task Disable() => await manager.DeleteWelcome(Context.Guild.Id.ToString());

        [Command("preview", RunMode = RunMode.Async)]
        [Summary("summary")]
        public async Task Preview()
        {
            string results = manager.GetWelcome(Context.Guild.Id.ToString()).Result;

            if (results == String.Empty)
            {
                await Context.Channel.SendMessageAsync("Welcome message is not set");
            }
            else
            {
                string[] data = results.Split(";");
                Stream file = ImageMaker.welcomeUser(Context.User.Username, data[1], Context.Guild.Name);
                await Context.Channel.SendFileAsync(file, "welcome.png", $"{data[2].Replace("%MENTION%", $"{Context.User.Mention}").Replace("%USERNAME%", $"{Context.User.Username}").Replace("%SERVERNAME%", $"{Context.Guild.Name}")}");
            }
        }

        [Command("channel", RunMode = RunMode.Async)]
        [Summary("summary")]
        public async Task SetChannel(SocketTextChannel channel) => await manager.UpdateChannel(Context.Guild.Id.ToString(), channel.Id.ToString());

        [Command("caption", RunMode = RunMode.Async)]
        [Summary("summary")]
        public async Task SetWelcomeBannerText([Remainder]string text) => await manager.setBannerText(Context, text);
        
        [Command("message", RunMode = RunMode.Async)]
        [Summary("summary")]
        public async Task SetWelcomeBannerDesc([Remainder]string text) => await manager.setBannerDesc(Context, text);

    }
}
