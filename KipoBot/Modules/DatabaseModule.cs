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

namespace KipoBot.Modules
{
    [Name("database")]
    [Summary("Database module")]
    public class DatabaseModule : ModuleBase<SocketCommandContext>
    {
        private readonly DatabaseService _database;
        private readonly DiscordSocketClient _client;

        public DatabaseModule(DiscordSocketClient client, DatabaseService database)
        {
            _database = database;
            _client = client;
        }

        [Command("dc", RunMode = RunMode.Async)]
        public async Task DC() => await _client.LogoutAsync();
     
        //Resets DB and memory
        [Command("reset", RunMode = RunMode.Async)]
        public async Task Reset()
        {
            _database.servers = new List<DatabaseService.Server>();
            _database.players = new List<Player>();
        }

        //TODO
        //Adds a pet to user
        [Command("addpet", RunMode = RunMode.Async)]
        public async Task AddPet()
        {

        }

        //TODO
        //saves to files
        [Command("savedb", RunMode = RunMode.Async)]
        public async Task SaveDB()
        {

        }

        //Lists players database
        [Command("checkplayers", RunMode = RunMode.Async)]
        public async Task CheckPlayers()
        {
            if (_database.players != null && _database.players.Count != 0)
            {
                Console.WriteLine("================");

                foreach (var player in _database.players)
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
            if (_database.players != null && _database.players.Count != 0)
            {
                Console.WriteLine("================");

                foreach (var players in _database.players)
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
            if (_database.servers != null && _database.servers.Count != 0)
            {
                Console.WriteLine("================");

                foreach (var server in _database.servers)
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
