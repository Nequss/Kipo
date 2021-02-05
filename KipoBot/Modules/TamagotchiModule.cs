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
using KipoBot.Services;

namespace Kipo.Modules
{
    [Group("t")]
    [Name("tamagotchi")]
    [Summary("Kipo's game module")]
    public class TamagotchiModule : ModuleBase<SocketCommandContext>
    {
        private static DatabaseService database;

        public TamagotchiModule(DatabaseService _database)
        {
            database = _database;
        }

        [Group("starters")]
        [Name("starters")]
        [Summary("Starter commands used to begin the game.")]
        public class StartersModule : ModuleBase<SocketCommandContext>
        {
            private static DatabaseService database;

            public StartersModule(DatabaseService _database)
            {
                database = _database;
            }

            [Command("show", RunMode = RunMode.Async)]
            [Summary("Shows starter pets avaiable to choose")]
            public async Task Show()
            {
                await Context.Channel.SendMessageAsync("Avaiable pets to choose as starter pet: \n" +
                    "\n - Bird" +
                    "\n - Dog" +
                    "\n - Cat" +
                    "\n - Lizard" +
                    "\n - Hamster" +
                    "\n - Snake" +
                    "\n - Bunny" +
                    "\n" +
                    "\n+t choose [pet]");
            }

            [Command("choose", RunMode = RunMode.Async)]
            [Summary("Shows starter pets avaiable to choose")]
            public async Task Choose([Remainder]string command) => await database.AddPlayer(Context.Message.Author.Id, command);
        }
    }
}
