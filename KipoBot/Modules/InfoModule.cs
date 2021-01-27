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
using Kipo.Modules;
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
            embedBuilder.AddField("Support server", "discord.gg/XAWgDHSw", true);


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

            embedBuilder.AddField("Created", Context.Guild.CreatedAt.UtcDateTime, true);
            embedBuilder.AddField("Channel categories", Context.Guild.CategoryChannels.Count, true);
            embedBuilder.AddField("Text channels", Context.Guild.TextChannels.Count, true);
            embedBuilder.AddField("Voice channels", Context.Guild.VoiceChannels.Count, true);
            embedBuilder.AddField("Emotes", Context.Guild.Emotes.Count, true);
            embedBuilder.AddField("ID", Context.Guild.Id, true);
            embedBuilder.AddField("Members", Context.Guild.MemberCount, true);
            embedBuilder.AddField("Owner", Context.Guild.Owner.Username + "#" + Context.Guild.Owner.DiscriminatorValue, true);
            embedBuilder.AddField("Owner's ID", Context.Guild.Owner.Id, true);
            embedBuilder.AddField("Roles", Context.Guild.Roles.Count, true);
            embedBuilder.AddField("Boost tier", Context.Guild.PremiumTier, true);
            embedBuilder.AddField("Boosts", Context.Guild.PremiumSubscriptionCount, true);
            embedBuilder.AddField("Icon", Context.Guild.IconUrl, true);

            await Context.Channel.SendMessageAsync(embed: embedBuilder.Build());
        }

        [Command("avatar", RunMode = RunMode.Async)]
        [Summary("Sends link to user's avatar")]
        public async Task Avatar(SocketGuildUser user = null)
        {
            user = user ?? Context.User as SocketGuildUser;
            await Context.Channel.SendMessageAsync(user.GetAvatarUrl(size: 1024));
        }
        
        /*
        [Command("welcome",RunMode = RunMode.Async)]
        public async Task WelcomeUser()
        {
            try
            {
                Context.Channel.SendFileAsync(ImageMaker.welcomeUser(Context.User.Username),"banner.png");
            }
            catch (Exception e)
            {
                Context.Channel.SendMessageAsync($"Sorry {Context.User.Mention} i couldn't create a banner for you.");
            }
        }

        [Command("reloadbanners",RunMode = RunMode.Async)]
        public async Task RefreshBanners()
        {
            ImageMaker.reloadBanners("banners/");
        }
        */
    }
}