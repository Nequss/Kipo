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
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using KipoBot.Game.Base;
using KipoBot.Game.Jobs;
using KipoBot.Services;

namespace KipoBot.Modules
{
    [Group("t")]
    [Name("work")]
    [Summary("Work module")]
    public class WorkModule : ModuleBase<SocketCommandContext>
    {
        private static DatabaseService database;

        public WorkModule(DatabaseService _database)
        {
            database = _database;
        }

        public async Task<Type> FindJob(string name)
        {
            foreach (var job in database.jobs)
                if (job.Name.ToLower() == name.ToLower().Replace(" ", ""))
                    return job;
            return null;
        }

        [Command("work", RunMode = RunMode.Async)]
        [Summary("Just do it")]
        public async Task Work([Remainder]string name)
        {
            Player tmp = await database.FindPlayer(Context.Message.Author.Id);

            if (tmp != null)
            {
                if (!tmp.active.hasWork())
                {
                    Type job = await FindJob(name);
                    object[] constructor = { tmp.active, tmp, Context };

                    Activator.CreateInstance(job, constructor);
                }
                else
                {
                    await Context.Channel.SendMessageAsync("Pet already has a job!");
                }
            }
            else
            {
                await Context.Channel.SendMessageAsync("You are not a member of the Kipo's tamagotchi club.\n" +
                    "You can join by choosing your first pet, try +help starters");
            }
        }
    }
}
