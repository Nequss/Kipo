using System;
using System.Linq;
using Discord;
using Discord.Commands;

namespace KipoBot.Utils
{
    public static class Helpers
    {
        public static IGuildUser extractUser(SocketCommandContext ctx, String message)
        {
            String impliedUser = message.Split('-')[0];
            IGuildUser identifiedUser = null;
            impliedUser = impliedUser.TrimStart().TrimEnd();
            
            if (impliedUser.StartsWith("<@"))
            {
                foreach (var user in ctx.Guild.Users)
                {
                    if (user.Id.Equals(ctx.Message.MentionedUsers.First().Id))
                    {
                        identifiedUser = user;
                        return user;
                    }
                }
            }
            else
            {
                foreach (var user in ctx.Guild.Users)
                {
                    if (user.Nickname == impliedUser || user.Username == impliedUser)
                    {
                        identifiedUser = user;
                        return user;
                    }
                }

                foreach (var user in ctx.Guild.Users)
                {
                    if (user.Id.ToString().Equals(impliedUser))
                    {
                        identifiedUser = user;
                        return user;
                    }
                }
            }
            return null;
        }
    }
}