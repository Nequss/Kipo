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
     

        //Resets and adds the servers the bot is in with default values.
        [Command("configure", RunMode = RunMode.Async)]
        public async Task Configure()
        {
            _database.servers = new List<DatabaseService.Server>();
            foreach (var guild in Context.Client.Guilds)
                await _database.AddServer(guild.Id);
        }

        //Lists pets database
        [Command("checkplayers", RunMode = RunMode.Async)]
        public async Task CheckPlayers()
        {
            if (_database.players != null)
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

        //Lists pets database
        [Command("checkpets", RunMode = RunMode.Async)]
        public async Task CheckPets()
        {
            if (_database.players != null)
            {
                Console.WriteLine("================");

                foreach (var players in _database.players)
                {
                    foreach (var pet in players.pets)
                    {
                        Console.WriteLine("ID         : " + pet.id);
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
            if (_database.servers != null)
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
