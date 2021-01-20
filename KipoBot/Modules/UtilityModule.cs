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

        [Command("showemotes", RunMode = RunMode.Async)]
        [Summary("Lists all of a guild emotes. \n +emotes")]
        [RequireContext(ContextType.Guild)]
        [RequireUserPermission(GuildPermission.ManageEmojis, ErrorMessage = "Lack of required permission: Manage Emojis")]
        public async Task ShowEmotes()
        {
            List<GuildEmote> animated = new List<GuildEmote>(Context.Guild.Emotes.Where(x => x.Animated));
            List<GuildEmote> standard = new List<GuildEmote>(Context.Guild.Emotes.Where(x => !x.Animated));

            string emotes = "";

            await Context.Channel.SendMessageAsync("Standard emotes | " + standard.Count);

            for (int i = 1 ; i <= standard.Count; i++)
            {
                if (i % 9 == 0)
                {
                    emotes += "<:" + standard[i - 1].Name + ":" + standard[i - 1].Id + ">";
                    await Context.Channel.SendMessageAsync(emotes);
                    emotes = "";
                }
                else
                {
                    emotes += "<:" + standard[i - 1].Name + ":" + standard[i - 1].Id + ">";
                }
                Console.WriteLine(i-1);
            }

            if (emotes != "")
                await Context.Channel.SendMessageAsync(emotes);

            await Context.Channel.SendMessageAsync("\nAnimated emotes | " + animated.Count);

            emotes = "";

            for (int i = 1; i <= animated.Count; i++)
            {
                if (i % 9 == 0)
                {
                    emotes += "<a:" + animated[i - 1].Name + ":" + animated[i - 1].Id + ">";
                    await Context.Channel.SendMessageAsync(emotes);
                    emotes = "";
                }
                else
                {
                    emotes += "<a:" + animated[i - 1].Name + ":" + animated[i - 1].Id + ">";
                }
                Console.WriteLine(i-1);
            }

            if (emotes != "")
                await Context.Channel.SendMessageAsync(emotes);
        }

        [Command("setnick", RunMode = RunMode.Async)]
        [Summary("Set new nickname for a user. No name - Resets the nicknames \n +setnick [user] (name)")]
        [RequireUserPermission(GuildPermission.ManageNicknames, ErrorMessage = "You don't have required permission: Manage Nicknames")]
        [RequireBotPermission(GuildPermission.ManageNicknames, ErrorMessage = "Lack of required permission: Manage Nicknames")]
        public async Task SetNick(SocketGuildUser user = null, string name = null)
        {
            if (user == null)
            {
                await Context.Channel.SendMessageAsync("User not found!");
                return;
            }

            await user.ModifyAsync(x => x.Nickname = name == null ? user.Username : name);
        }

        [Command("setnicks", RunMode = RunMode.Async)]
        [Summary("Set new nicknames for users with specific role. No name - Resets the nicknames \n +setnick [role] (name)")]
        [RequireUserPermission(GuildPermission.ManageNicknames, ErrorMessage = "You don't have required permission: Manage Nicknames")]
        [RequireBotPermission(GuildPermission.ManageNicknames, ErrorMessage = "Lack of required permission: Manage Nicknames")]
        public async Task SetNicks(SocketRole userRole = null, string name = null)
        {
            if (userRole == null)
            {
                await Context.Channel.SendMessageAsync("Role not found! \n+setnicks [role] [name]");
                return;
            }

            foreach (SocketRole role in Context.Guild.Roles)
                if (role.Name == userRole.Name)
                    foreach (SocketGuildUser user in role.Members)
                        await user.ModifyAsync(x => x.Nickname = name == null ? user.Username : name);
        }

        [Command("setglobal", RunMode = RunMode.Async)]
        [Summary("Set new nickname for a user. No name - Resets the nicknames \n +setnick [user] (name)")]
        [RequireUserPermission(GuildPermission.ManageNicknames, ErrorMessage = "You don't have required permission: Manage Nicknames")]
        [RequireBotPermission(GuildPermission.ManageNicknames, ErrorMessage = "Lack of required permission: Manage Nicknames")]
        public async Task SetNickss(string name = null)
        {
            foreach(SocketGuildUser user in Context.Guild.Users)
                await user.ModifyAsync(x => x.Nickname = name == null ? user.Username : name);
        }

        [Command("createrole", RunMode = RunMode.Async)]
        [Summary("Creates a role with a specified anme and optional hex color.\n +createrole [role_name] (hex colour)")]
        [RequireUserPermission(GuildPermission.ManageRoles, ErrorMessage = "You don't have required permission: Manage Roles")]
        [RequireBotPermission(GuildPermission.ManageRoles, ErrorMessage = "Lack of required permission: Manage Roles")]
        public async Task CreateRole(string name = null, string color = null)
        {
            if (name == null)
            {
                await Context.Channel.SendMessageAsync("Set a role name first! \n+createrole [name] (#hexvalue)");
                return;
            }

            if (color == null)
            {
                await Context.Channel.SendMessageAsync("Set a role name first! \n+createrole [name] (#hexvalue)");

            }

            Color newColor = new Color(UInt32.Parse(color[0] + color.Substring(1), System.Globalization.NumberStyles.HexNumber));
            await Context.Guild.CreateRoleAsync(name, null, newColor, false, null);

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
