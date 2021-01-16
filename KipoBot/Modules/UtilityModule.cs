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
using System.Linq;

namespace KipoBot.Modules
{
    [Name("utility")]
    [Summary("Contains all needed commands to manage a server.")]
    public class UtilityModule : ModuleBase<SocketCommandContext>
    { 
        [Command("ban", RunMode = RunMode.Async)]
        [Summary("Bans specified user \n +ban [user] (reason)")]
        [RequireContext(ContextType.Guild)]
        [RequireUserPermission(GuildPermission.BanMembers, ErrorMessage = "You don't have required permission to ban people!")]
        [RequireBotPermission(GuildPermission.BanMembers, ErrorMessage = "I don't have required permission to ban people!")]
        public async Task Ban(IGuildUser user = null, string reason = null)
        {
            if (user == null)
                await ReplyAsync("User not found! \n +ban [user] (reason)");
            else
                await user.BanAsync(reason: reason);

            await ReplyAsync(user.Username + "#" + user.DiscriminatorValue + " has been banned!");
        }

        //TODO +unban [user]
        [Command("unban", RunMode = RunMode.Async)]
        public async Task UnBan()
        {

        }

        [Command("kick", RunMode = RunMode.Async)]
        [Summary("Kicks specified user \n +kick [user] (reason)")]
        [RequireContext(ContextType.Guild)]
        [RequireUserPermission(GuildPermission.KickMembers, ErrorMessage = "You don't have required permission to kick people!")]
        [RequireBotPermission(GuildPermission.KickMembers, ErrorMessage = "I don't have required permission to kick people!")]
        public async Task Kick(IGuildUser user = null, string reason = null)
        {
            if (user == null)
                await ReplyAsync("User not found! \n +kick [user] (reason)");
            else
                await user.KickAsync(reason: reason);

            await ReplyAsync(user.Username + "#" + user.DiscriminatorValue + " has been kicked!");
        }

        [Command("purge", RunMode = RunMode.Async)]
        [Summary("Deletes specified amount of messages \n +purge [amount]")]
        [RequireContext(ContextType.Guild)]
        [RequireUserPermission(GuildPermission.ManageMessages, ErrorMessage = "You don't have required permission to delete messages!")]
        [RequireBotPermission(ChannelPermission.ManageMessages, ErrorMessage = "I don't have required permission to delete messages!")]
        public async Task Purge(string i = null)
        {
            IEnumerable<IMessage> messages;

            if (Int32.TryParse(i, out _))
            {
                messages = await Context.Channel.GetMessagesAsync(Int32.Parse(i)).FlattenAsync();
            }
            else
            {
                await Context.Channel.SendMessageAsync("Amount must be a number! \n +purge [amount]");
                return;
            }

            await (Context.Channel as SocketTextChannel).DeleteMessagesAsync(messages.Where(x => (DateTimeOffset.UtcNow - x.Timestamp).TotalDays <= 14));
        }

        [Command("say", RunMode = RunMode.Async)]
        [Summary("Says something as Kipo. \n +say [message] (channel)")]
        [RequireUserPermission(GuildPermission.ManageMessages, ErrorMessage = "Lack of required permission: Manage Messages")]
        public async Task Say(string text = null, ISocketMessageChannel guildChannel = null)
        {
            await Context.Message.DeleteAsync();

            if (text == null)
            { 
                await Context.Channel.SendMessageAsync("You forgot something to say! \n +say [Text] (TextChannel)");
                return;
            }

            guildChannel = guildChannel ?? Context.Channel;
            await guildChannel.SendMessageAsync(text);
        }

        //TODO - +setnick [user] [name]
        [Command("setnick", RunMode = RunMode.Async)]
        public async Task SetNick()
        {

        }

        //TODO +setnicks [role] [name]
        [Command("setnicks", RunMode = RunMode.Async)]
        public async Task SetNicks()
        {

        }

        //TODO +setglobal [name]
        [Command("setglobal", RunMode = RunMode.Async)]
        public async Task SetGlobal()
        {

        }

        //TODO +createrole [role_name] (hex colour)
        [Command("createrole", RunMode = RunMode.Async)]
        public async Task CreateRole()
        {

        }

        //TODO +delrole [role]
        [Command("delrole", RunMode = RunMode.Async)]
        public async Task DelRole()
        {

        }

        //TODO +roles [user]
        [Command("roles", RunMode = RunMode.Async)]
        public async Task Roles()
        {

        }

        //TODO +rolecolor [role] [hex color]
        [Command("rolecolor", RunMode = RunMode.Async)]
        public async Task RoleColor()
        {

        }

        //TODO +rolename [role] [new_name]
        [Command("rolename", RunMode = RunMode.Async)]
        public async Task RoleName()
        {

        }

        //TODO +members [role]
        [Command("members", RunMode = RunMode.Async)]
        public async Task Members()
        {

        }

        //TODO
        //+lock Locks a channel. No permission to send messages for standard users.
        //+lock [channel]
        [Command("lock", RunMode = RunMode.Async)]
        public async Task Lock()
        {

        }
        //TODO
        //+unlock [channel]
        [Command("unlock", RunMode = RunMode.Async)]
        public async Task UnLock()
        {

        }

    }
}
