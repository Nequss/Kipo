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
    public class UtilityModule : ModuleBase<SocketCommandContext>
    {
        [Command("ban", RunMode = RunMode.Async)]
        [RequireContext(ContextType.Guild)]
        [RequireUserPermission(GuildPermission.BanMembers, ErrorMessage = "You don't have required permission to ban people!")]
        [RequireBotPermission(GuildPermission.BanMembers, ErrorMessage = "I dont have required permission to ban people!")]
        public async Task BanUserAsync(IGuildUser user, [Remainder]string reason)
        {
            await user.Guild.AddBanAsync(user, reason: reason);
            await ReplyAsync(user.Username + "#" + user.DiscriminatorValue + " has been banned!");
        }

        [Command("kick", RunMode = RunMode.Async)]
        [RequireContext(ContextType.Guild)]
        [RequireUserPermission(GuildPermission.KickMembers, ErrorMessage = "You don't have required permission to kick people!")]
        [RequireBotPermission(GuildPermission.KickMembers, ErrorMessage = "I dont have required permission to kick people!")]
        public async Task KickUserAsync(IGuildUser user, [Remainder]string reason)
        {
            await user.KickAsync(reason: reason);
            await ReplyAsync(user.Username + "#" + user.DiscriminatorValue + " has been kicked!");
        }

        [Command("purge", RunMode = RunMode.Async)]
        [RequireContext(ContextType.Guild)]
        [RequireUserPermission(GuildPermission.ManageMessages, ErrorMessage = "You don't have required permission to delete messages!")]
        [RequireBotPermission(ChannelPermission.ManageMessages, ErrorMessage = "I have required permission to delete messages!")]
        public async Task ClearAsync(int i)
        {
            var messages = await Context.Channel.GetMessagesAsync(i).FlattenAsync();
            var filteredMessages = messages.Where(x => (DateTimeOffset.UtcNow - x.Timestamp).TotalDays <= 14);
            await (Context.Channel as SocketTextChannel).DeleteMessagesAsync(filteredMessages);
        }

    }
}
