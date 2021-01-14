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
using KipoBot.Services;
using System.Diagnostics;
using System.Threading;
using System.Management;


namespace KipoBot.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        private readonly CommandService _service;

        public InfoModule(CommandService service) => _service = service;

        [Command("help")]
        [Summary("Shows this command")]
        public async Task Help()
        {
            EmbedBuilder embedBuilder = new EmbedBuilder();

            embedBuilder.Color = Color.Purple;
            embedBuilder.WithAuthor(author =>
            {
                author.WithName("Kipo is always ready to help!");
                author.WithIconUrl(Context.Client.CurrentUser.GetAvatarUrl());
            });

            foreach (var module in _service.Modules)
                foreach (var cmd in module.Commands)
                    if (cmd.Name != "help")
                        embedBuilder.AddField("+" + cmd.Name, cmd.Summary, inline: true);


            await ReplyAsync(embed: embedBuilder.Build());
        }

        [Command("latency")]
        [Summary("Shows kipo's response time")]
        public async Task Latency() => await ReplyAsync("My response time is " + Context.Client.Latency + " ms.");

        [Command("stats")]
        [Summary("Shows kipo's statistics")]
        public async Task Stats()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();

            string total = String.Empty;
            string used = String.Empty;

            foreach (ManagementObject result in results)
            {
                total = String.Format("{0:0.00}", Int32.Parse(result["TotalVisibleMemorySize"].ToString()) / (1024.0 * 1024.0));
                used = String.Format("{0:0.00}", Int32.Parse(result["TotalVisibleMemorySize"].ToString()) / (1024.0 * 1024.0) - Int32.Parse(result["FreePhysicalMemory"].ToString()) / (1024.0 * 1024.0));
            }

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
            embedBuilder.AddField("Created", Context.Client.CurrentUser.CreatedAt.UtcDateTime, true);
            embedBuilder.AddField("ID", Context.Client.CurrentUser.Id, true);
            embedBuilder.AddField("RAM", used + "GB / " + total + "GB", true);
            embedBuilder.AddField("Library", "Discord.Net 2.2.0", true);
            embedBuilder.AddField("Creator", "Nequs#6848", true);
            embedBuilder.AddField("Support server", "link", true);


            await Context.Channel.SendMessageAsync(embed: embedBuilder.Build());
        }

        [Command("userinfo")]
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

        [Command("contact")]
        [Summary("Shows information about kipo's owner")]
        public async Task Contact()
        {
        }
    }
}