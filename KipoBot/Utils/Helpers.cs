using Discord.WebSocket;
using Discord.Commands;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Discord;

namespace KipoBot.Utils
{
    public static class Helpers
    {
        public static readonly String WORKING_DIRECTORY = Directory.GetCurrentDirectory();
        
        public static SocketGuildUser extractUser(SocketCommandContext ctx, string message)
        {
            string impliedUser = message.TrimStart().TrimEnd();

            if (impliedUser.StartsWith("<@"))
            {
                return ctx.Guild.GetUser(ctx.Message.MentionedUsers.First().Id);
            }
            else
            {
                try
                {
                    return ctx.Guild.GetUser(UInt64.Parse(impliedUser));
                }
                catch
                {
                    foreach (var user in ctx.Guild.Users)
                    {
                        if (user.Nickname == impliedUser || user.Username == impliedUser)
                        {
                            return user;
                        }
                    }
                }
            }
            return null;
        }

        public static bool AssertDirectory(String path)
        {
            bool isSuccess = true;
                if (!Directory.Exists( $"{WORKING_DIRECTORY}/{path}"))
                {
                    try
                    {
                        Directory.CreateDirectory($"{WORKING_DIRECTORY}/{path}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Failed to create directory: " + path + "\n" + e);
                        isSuccess = false;
                    }
                }
            return isSuccess;
        }

        public static async Task<string> getHttpResponseString(string url)
        {
            HttpClient client = new HttpClient();
            return await client.GetStringAsync(url);
        }
    }
}