using Discord;
using System.Collections.Generic;
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
using System.Linq;

namespace KipoBot.Modules
{
    [Summary("Utility Module contains all needed commands to manage a server.")]
    public class UtilityModule : ModuleBase<SocketCommandContext>
    {
        [Command("ban", RunMode = RunMode.Async)]
        [Summary("Bans specified user \n +ban [user] (reason)")]
        [RequireContext(ContextType.Guild)]
        [RequireUserPermission(GuildPermission.BanMembers, ErrorMessage = "You don't have required permission to ban people!")]
        [RequireBotPermission(GuildPermission.BanMembers, ErrorMessage = "I don't have required permission to ban people!")]
        public async Task BanUserAsync(IGuildUser user, [Remainder]string reason)
        {
            await user.Guild.AddBanAsync(user, reason: reason);
            await ReplyAsync(user.Username + "#" + user.DiscriminatorValue + " has been banned!");
        }

        [Command("kick", RunMode = RunMode.Async)]
        [Summary("Kicks specified user \n +kick [user] (reason)")]
        [RequireContext(ContextType.Guild)]
        [RequireUserPermission(GuildPermission.KickMembers, ErrorMessage = "You don't have required permission to kick people!")]
        [RequireBotPermission(GuildPermission.KickMembers, ErrorMessage = "I don't have required permission to kick people!")]
        public async Task KickUserAsync(IGuildUser user, [Remainder]string reason)
        {
            await user.KickAsync(reason: reason);
            await ReplyAsync(user.Username + "#" + user.DiscriminatorValue + " has been kicked!");
        }

        [Command("purge", RunMode = RunMode.Async)]
        [Summary("Deletes specified amount of messages \n +purge [amount]")]
        [RequireContext(ContextType.Guild)]
        [RequireUserPermission(GuildPermission.ManageMessages, ErrorMessage = "You don't have required permission to delete messages!")]
        [RequireBotPermission(ChannelPermission.ManageMessages, ErrorMessage = "I don't have required permission to delete messages!")]
        public async Task ClearAsync(int i)
        {
            var messages = await Context.Channel.GetMessagesAsync(i).FlattenAsync();
            var filteredMessages = messages.Where(x => (DateTimeOffset.UtcNow - x.Timestamp).TotalDays <= 14);

            await (Context.Channel as SocketTextChannel).DeleteMessagesAsync(filteredMessages);
        }

        [Command("say", RunMode = RunMode.Async)]
        [Summary("Says something as Kipo. \n +say [message] (channel)")]
        [RequireUserPermission(GuildPermission.ManageMessages, ErrorMessage = "Lack of required permission: Manage Messages")]
        public async Task Say(string text = null, ISocketMessageChannel guildChannel = null)
        {
            await Context.Message.DeleteAsync();

            if (text == null)
                await Context.Channel.SendMessageAsync("You forgot something to say! +say [Text] (TextChannel)");

            guildChannel = guildChannel ?? Context.Channel;
            await guildChannel.SendMessageAsync(text);
        }
    }
}
