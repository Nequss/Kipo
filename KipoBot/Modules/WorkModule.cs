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

        [Command("work", RunMode = RunMode.Async)]
        [Summary("just do it")]
        public async Task Work()
        {
            Player tmp = null;
            foreach (var player in database.players)
            {
                if (player.id == Context.User.Id)
                {
                    tmp = player;
                    break;
                }
            }

            if (tmp != null && !tmp.active.hasWork())
            {
                new Factory(tmp.active, tmp, Context);
            }
            else
            {
                await Context.Channel.SendMessageAsync("Pet already has a job!");
            }
        }
    }
}
