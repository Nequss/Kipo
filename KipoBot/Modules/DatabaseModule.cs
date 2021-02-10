using Discord;
using Discord.Webhook;
using Discord.WebSocket;
using Discord.Commands;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using KipoBot.Services;
using KipoBot.Game.Base;
using System.Reflection;

namespace KipoBot.Modules
{
    [Name("database")]
    [Summary("Database module")]
    public class DatabaseModule : ModuleBase<SocketCommandContext>
    {
        private readonly DatabaseService database;
        private readonly DiscordSocketClient client;

        public DatabaseModule(DiscordSocketClient _client, DatabaseService _database)
        {
            database = _database;
            client = _client;
        }

        //disconnects the bot
        [Command("dc", RunMode = RunMode.Async)]
        public async Task DC() => await client.LogoutAsync();
     
        //Resets DB and memory
        [Command("reset", RunMode = RunMode.Async)]
        public async Task Reset()
        {
            database.servers = new List<DatabaseService.Server>();
            database.players = new List<Player>();
        }

        //Adds a pet to user
        [Command("addpet", RunMode = RunMode.Async)]
        public async Task AddPet(SocketUser user = null, [Remainder]string pet = null)
        {
            user = user ?? Context.User;
            
            if (await database.AddPet(user.Id, pet))
                Console.WriteLine($"Pet has been sucessfuly added to player: {user.Id}");
            else
                Console.WriteLine("Either player or pet doen't exists!");
        }

        //saves database to files
        [Command("savedb", RunMode = RunMode.Async)]
        public async Task SaveDB() => await database.Save(); 

        //Lists players database
        [Command("checkplayers", RunMode = RunMode.Async)]
        public async Task CheckPlayers()
        {
            if (database.players != null && database.players.Count != 0)
            {
                Console.WriteLine("================");

                foreach (var player in database.players)
                {
                    Console.WriteLine("ID         : " + player.id);
                    Console.WriteLine("Wallet     : " + player.wallet);
                    Console.WriteLine("Active pet : " + player.active.name);
                    Console.WriteLine("Pets count : " + player.pets.Count);
                    Console.WriteLine("Items count: " + player.items.Count);
                    Console.WriteLine("================");
                }
            }
            else
            {
                Console.WriteLine("================");
                Console.WriteLine("List is empty!");
                Console.WriteLine("================");
            }
        }

        //Lists players pets
        [Command("checkpets", RunMode = RunMode.Async)]
        public async Task CheckPets()
        {
            if (database.players != null && database.players.Count != 0)
            {
                Console.WriteLine("================");

                foreach (var players in database.players)
                {
                    Console.WriteLine("Owner's ID : " + players.id);
                    foreach (var pet in players.pets)
                    {
                        Console.WriteLine("Name       : " + pet.name);
                        Console.WriteLine("================");
                    }
                }
            }
            else
            {
                Console.WriteLine("================");
                Console.WriteLine("List is empty!");
                Console.WriteLine("================");
            }
        }

        //Lists servers to the console.
        [Command("checkservers", RunMode = RunMode.Async)]
        public async Task CheckServers()
        {
            if (database.servers != null && database.servers.Count != 0)
            {
                Console.WriteLine("================");

                foreach (var server in database.servers)
                {
                    Console.WriteLine("ID         : " + server.id);
                    Console.WriteLine("Channel ID : " + server.channel_id);
                    Console.WriteLine("Message    : " + server.message);
                    Console.WriteLine("Caption    : " + server.caption);
                    Console.WriteLine("Prefix     : " + server.prefix);
                    Console.WriteLine("================");
                }
            }
            else
            {
                Console.WriteLine("================");
                Console.WriteLine("List is empty!");
                Console.WriteLine("================");
            }
        }
    }
}
