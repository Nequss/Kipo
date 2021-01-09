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
    public class UtilityModule : ModuleBase<SocketCommandContext>
    {
        [Command("ban")]
        [RequireContext(ContextType.Guild)]
        [RequireUserPermission(GuildPermission.BanMembers, ErrorMessage = "You don't have required permission to ban bad people! UwU")]
        [RequireBotPermission(GuildPermission.BanMembers, ErrorMessage = "I dont have required permission to ban bad people! UwU")]
        public async Task BanUserAsync(IGuildUser user, [Remainder] string reason)
        {
            await user.Guild.AddBanAsync(user, reason: reason);
            await ReplyAsync("The bad nyan has been banned! UwU");
        }

        [Command("kick")]
        [RequireContext(ContextType.Guild)]
        [RequireUserPermission(GuildPermission.KickMembers, ErrorMessage = "You don't have required permission to kick bad people! UwU")]
        [RequireBotPermission(GuildPermission.KickMembers, ErrorMessage = "I dont have required permission to kick people! UwU")]
        public async Task KickUserAsync(IGuildUser user, [Remainder] string reason)
        {
            await user.KickAsync(reason: reason);
            await ReplyAsync("The bad nyan has been kicked! UwU");
        }

        [Command("purge")]
        [RequireContext(ContextType.Guild)]
        [RequireUserPermission(GuildPermission.ManageMessages, ErrorMessage = "You don't have required permission to delete messages! UwU")]
        [RequireBotPermission(ChannelPermission.ManageMessages, ErrorMessage = "I have required permission to delete messages! UwU")]
        public async Task ClearAsync(int i)
        {
            if (i > 99)
            {

            }
            else
            {
                var messages = await Context.Channel.GetMessagesAsync(i + 1).FlattenAsync();
                await (Context.Channel as SocketTextChannel).DeleteMessagesAsync(messages);
            }
        }
    }
}
