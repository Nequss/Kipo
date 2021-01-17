﻿using Discord;
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
using System.Threading;
using KipoBot.Services;

namespace KipoBot.Modules
{
    [Name("info")]
    [Summary("Contains all needed commands get information about servers, users and a kipo.")]
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        private readonly CommandService _service;
        private readonly ConfigurationService _config;

        public InfoModule(CommandService service, ConfigurationService config)
        {
            _config = config;
            _service = service;
        }

        public async Task<Embed> GetHelp(string options)
        {
            EmbedBuilder embedBuilder = new EmbedBuilder();

            embedBuilder.Color = Color.Purple;
            embedBuilder.WithAuthor(author =>
            {
                author.WithName("Kipo is always ready to help!");
                author.WithIconUrl(Context.Client.CurrentUser.GetAvatarUrl());
            });

            //check for specified module
            foreach (var module in _service.Modules)
            {
                if(options == module.Name)
                {
                    foreach (var command in module.Commands)
                        if (command.Name != "help")
                            embedBuilder.AddField(_config.prefix + command.Name, command.Summary == null ? "No Summary" : command.Summary, true);

                    return embedBuilder.Build();
                }
            }

            //if module not found
            foreach (var module in _service.Modules)
                embedBuilder.AddField(char.ToUpper(module.Name[0]) + module.Name.Substring(1) + " Module | " + _config.prefix + "help " + module.Name, module.Summary, false);

            return embedBuilder.Build();
        }

        [Command("help", RunMode = RunMode.Async)]
        public async Task Help(string arg = null) => await ReplyAsync(embed: await GetHelp(arg == null ? null : arg));


        [Command("latency", RunMode = RunMode.Async)]
        [Summary("Shows kipo's response time")]
        public async Task Latency() => await ReplyAsync("My response time is " + Context.Client.Latency + " ms.");

        [Command("kipoinfo", RunMode = RunMode.Async)]
        [Summary("Shows kipo's statistics")]
        public async Task Stats()
        {
            MetricsModule systemInfo = new MetricsModule();

            int users = 0;
            foreach (SocketGuild guild in Context.Client.Guilds)
                users += guild.Users.Count;

            EmbedBuilder embedBuilder = new EmbedBuilder();
            embedBuilder.Color = Color.Purple;

            embedBuilder.WithAuthor(author =>
            {
                author.WithName("Kipo - Cutest bot in the universe!");
                author.WithIconUrl(Context.Client.CurrentUser.GetAvatarUrl());
            });

            embedBuilder.AddField("Guilds", Context.Client.Guilds.Count, true);
            embedBuilder.AddField("Users", users, true);
            embedBuilder.AddField("Version", "1.0", true);
            embedBuilder.AddField("Prefix", _config.prefix, true);
            embedBuilder.AddField("Created", Context.Client.CurrentUser.CreatedAt.UtcDateTime, true);
            embedBuilder.AddField("ID", Context.Client.CurrentUser.Id, true);
            embedBuilder.AddField("RAM", systemInfo.getMemoryUsedGB() + "GB / " + systemInfo.getMemoryMaxGB() + "GB", true);
            embedBuilder.AddField("CPU", systemInfo.getCpuNow()+"%", true);
            embedBuilder.AddField("Host OS", systemInfo.getOsPlatform(), true);
            embedBuilder.AddField("Library", "Discord.Net 2.2.0", true);
            embedBuilder.AddField("Creator", "Nequs#6848", true);
            embedBuilder.AddField("Support server", "link", true);


            await Context.Channel.SendMessageAsync(embed: embedBuilder.Build());
        }

        [Command("userinfo", RunMode = RunMode.Async)]
        [Summary("Shows user's information \n +userinfo [user]")]
        public async Task Info(SocketGuildUser user = null)
        {
            user = user ?? Context.User as SocketGuildUser;

            string roles = "| ";
            foreach (IRole role in user.Roles)
                if (role.Name != "@everyone")
                    roles += role.Mention + " | ";

            string permissions = "| ";
            foreach (GuildPermission guildPermission in user.GuildPermissions.ToList())
                permissions += guildPermission.ToString() + " | ";

            EmbedBuilder embedBuilder = new EmbedBuilder();
            embedBuilder.Color = Color.Purple;

            embedBuilder.WithAuthor(author =>
            {
                author.WithName(user.Username + "#" + user.Discriminator);
                author.WithIconUrl(user.GetAvatarUrl());
            });

            embedBuilder.AddField("Joined", user.JoinedAt.Value.UtcDateTime, true);
            embedBuilder.AddField("Registered", user.CreatedAt.UtcDateTime, true);

            embedBuilder.AddField("Status", user.Status, false);
            embedBuilder.AddField("Roles", roles, false);
            embedBuilder.AddField("Permissions", permissions, false);
            embedBuilder.AddField("Avatar", user.GetAvatarUrl(), false);

            await Context.Channel.SendMessageAsync(embed: embedBuilder.Build());
        }

        //TODO 
        [Command("serverinfo", RunMode = RunMode.Async)]
        [Summary("Shows information about current guild the command is executed in")]
        public async Task ServerInfo()
        {
            EmbedBuilder embedBuilder = new EmbedBuilder();
            embedBuilder.Color = Color.Purple;

            embedBuilder.WithAuthor(author =>
            {
                author.WithName(Context.Guild.Name);
                author.WithIconUrl(Context.Guild.IconUrl);
            });

            embedBuilder.AddField("", Context.Guild, true);

            await Context.Channel.SendMessageAsync(embed: embedBuilder.Build());
        }

        //TODO 
        [Command("avatar", RunMode = RunMode.Async)]
        [Summary("Sends link to user's avatar")]
        public async Task Avatar()
        {

        }

        //TODO +emotes Gets a list of server emojis.	
        [Command("emotes", RunMode = RunMode.Async)]
        public async Task Emotes()
        {

        }

        //TODO - leave it for now
        [Command("support", RunMode = RunMode.Async)]
        public async Task Support()
        {

        }
    }
}