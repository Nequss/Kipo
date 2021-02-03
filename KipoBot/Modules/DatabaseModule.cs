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

namespace KipoBot.Modules
{
    public class DatabaseModule : ModuleBase<SocketCommandContext>
    {
        private readonly DatabaseService _database;

        public DatabaseModule(DatabaseService database)
        {
            _database = database;
        }

        //Resets and adds the servers the bot is in with default values.
        [Command("configure", RunMode = RunMode.Async)]
        public async Task Configure()
        {
            _database.servers = new List<DatabaseService.Server>();
            foreach (var guild in Context.Client.Guilds)
                await _database.AddServer(guild.Id);
        }

        //Lists servers to the console.
        [Command("checkservers", RunMode = RunMode.Async)]
        public async Task ListServers()
        {
            await Context.Message.DeleteAsync();

            if (_database.servers != null)
            {
                Console.WriteLine("================");

                foreach (var server in _database.servers)
                {
                    Console.WriteLine("ID         : " + server._guild_id);
                    Console.WriteLine("Channel ID : " + server._channel_id);
                    Console.WriteLine("Message    : " + server._message);
                    Console.WriteLine("Caption    : " + server._caption);
                    Console.WriteLine("Prefix     : " + server._prefix);
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
