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
using System.Reflection;

namespace KipoBot.Modules
{
    [Group("t")]
    [Name("work")]
    [Summary("Work module")]
    public class WorkModule : ModuleBase<SocketCommandContext>
    {
        private readonly DatabaseService database;

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

        [Command("start", RunMode = RunMode.Async)]
        [Summary("Sends your pet to work!\n+t start <job name>")]
        public async Task Start([Remainder]string name)
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

        [Command("job", RunMode = RunMode.Async)]
        [Summary("Shows information about the job\n+t job <job name>")]
        public async Task JobInfo([Remainder]string name)
        {
            Type job = await FindJob(name);

            if (job != null)
            {
                EmbedBuilder embedBuilder = new EmbedBuilder();

                embedBuilder.Color = Color.Purple;
                embedBuilder.WithAuthor(author =>
                {
                    author.WithName("Kipo's Tamagotchi Club");
                    author.WithIconUrl(Context.Client.CurrentUser.GetAvatarUrl());
                });

                object[] constructor = { null, null, null };
                Work work = (Work)Activator.CreateInstance(job, constructor);

                string text = $"Energy -{work.energyCost}\n" +
                    $"Hapiness -{work.happinessCost}\n" +
                    $"Hunger -{work.hungerCost}\n" +
                    $"Thirst -{work.thirstCost}\n\n" +
                    $"Min. requirements:\n" +
                    $"Pet's stage: {work.reqStage}\n";

                embedBuilder.AddField($"{work.name} | Info", text);

                await Context.Channel.SendMessageAsync(embed: embedBuilder.Build());
            }
            else 
            {
                await Context.Channel.SendMessageAsync("Job not found!");
            }
        }

        [Command("jobs", RunMode = RunMode.Async)]
        [Summary("Shows all avaiable jobs")]
        public async Task ShowJobs()
        {
            EmbedBuilder embedBuilder;
            string text = string.Empty;

            embedBuilder = new EmbedBuilder();

            embedBuilder.Color = Color.Purple;
            embedBuilder.WithAuthor(author =>
            {
                author.WithName("Kipo's Tamagotchi Club");
                author.WithIconUrl(Context.Client.CurrentUser.GetAvatarUrl());
            });

            foreach (var job in database.jobs)
            {
                object[] constructor = { null, null, null };
                Work work = (Work)Activator.CreateInstance(job, constructor);

                text += $"{work.name}\n";
            }

            embedBuilder.AddField("All avaiable jobs | +t job <job name>", text);

            await Context.Channel.SendMessageAsync(embed: embedBuilder.Build());
        }
    }
}
