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
using KipoBot.Utils;

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
        public async Task DC()
        {
            WorkManager.running = false;
            await client.LogoutAsync();
        }
        
        //Resets DB and memory
        [Command("reset", RunMode = RunMode.Async)]
        public async Task Reset()
        {
            database.servers = new List<DatabaseService.Server>();
            database.players = new List<Player>();
        }

        //Lists all items
        [Command("listitems", RunMode = RunMode.Async)]
        public async Task ListItems()
        {
            Program.Logger.info("_____________________________");

            foreach (var x in database.shop)
            {
                Program.Logger.info("_____________________________");

                foreach (var y in x)
                {
                    Program.Logger.info($"Name: {y.name}");
                    Program.Logger.info($"Type: {y.type}");
                    Program.Logger.info($"Description: {y.description}");
                    Program.Logger.info($"Price: {y.price}");
                    Program.Logger.info($"Health: {y.health}");
                    Program.Logger.info($"Hunger: {y.hunger}");
                    Program.Logger.info($"Thirst: {y.thirst}");
                    Program.Logger.info($"Energy: {y.energy}");
                    Program.Logger.info($"Hapiness: {y.hapiness}");
                    Program.Logger.info($"Health: {y.health}");
                    Program.Logger.info("_____________________________");
                }
            }
        }

        //Adds a pet to user
        [Command("addpet", RunMode = RunMode.Async)]
        public async Task AddPet(SocketUser user = null, [Remainder]string pet = null)
        {
            user = user ?? Context.User;
            
            if (await database.AddPet(user.Id, pet))
                Program.Logger.info($"Pet has been sucessfuly added to player: {user.Id}");
            else
                Program.Logger.warn("Either player or pet doesn't exists!");
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
                Program.Logger.info("================");

                foreach (var player in database.players)
                {
                    Program.Logger.info("ID         : " + player.id);
                    Program.Logger.info("Wallet     : " + player.wallet);
                    Program.Logger.info("Active pet : " + player.active.name);
                    Program.Logger.info("Pets count : " + player.pets.Count);
                    Program.Logger.info("Items count: " + player.items.Count);
                    Program.Logger.info("================");
                }
            }
            else
            {
                Program.Logger.info("================");
                Program.Logger.warn("List is empty!");
                Program.Logger.info("================");
            }
        }

        //Lists players pets
        [Command("checkpets", RunMode = RunMode.Async)]
        public async Task CheckPets()
        {
            if (database.players != null && database.players.Count != 0)
            {
                Program.Logger.info("================");

                foreach (var players in database.players)
                {
                    Program.Logger.info("Owner's ID : " + players.id);
                    foreach (var pet in players.pets)
                    {
                        Program.Logger.info("Name       : " + pet.name);
                        Program.Logger.info("================");
                    }
                }
            }
            else
            {
                Program.Logger.info("================");
                Program.Logger.warn("List is empty!");
                Program.Logger.info("================");
            }
        }

        //Lists servers to the console.
        [Command("checkservers", RunMode = RunMode.Async)]
        public async Task CheckServers()
        {
            if (database.servers != null && database.servers.Count != 0)
            {
                Program.Logger.info("================");

                foreach (var server in database.servers)
                {
                    Program.Logger.info("ID         : " + server.id);
                    Program.Logger.info("Channel ID : " + server.channel_id);
                    Program.Logger.info("Message    : " + server.message);
                    Program.Logger.info("Caption    : " + server.caption);
                    Program.Logger.info("Prefix     : " + server.prefix);
                    Program.Logger.info("================");
                }
            }
            else
            {
                Program.Logger.info("================");
                Program.Logger.warn("List is empty!");
                Program.Logger.info("================");
            }
        }
    }
}
