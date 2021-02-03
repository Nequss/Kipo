using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord.Webhook;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using KipoBot.Services;

namespace KipoBot.Services
{
    public class DatabaseService
    {
        [Serializable]
        public class Server
        {
            public ulong _guild_id;
            public ulong? _channel_id;
            public string _caption;
            public string _message;
            public char _prefix;

            public Server(ulong guild_id,
                          ulong? channel_id = null, 
                          string caption = "Hello %USERNAME%!\nWelcome to the server!",
                          string message = "",
                          char prefix = '+')
            {
                _guild_id = guild_id;
                _channel_id = channel_id;
                _caption = caption;
                _message = message;
                _prefix = prefix;
            }
        }

        private readonly DiscordSocketClient _client;

        public DatabaseService(DiscordSocketClient client)
        {
            _client = client;

            _client.UserJoined += UserJoined;
            _client.JoinedGuild += JoinedGuild;
            _client.Connected += Connected;
            _client.Disconnected += Disconnected;
        }

        public List<Server> servers;

        string SERVERS_PATH = Directory.GetCurrentDirectory() + @"/data/";

        private Task Disconnected(Exception arg)
        {
            Directory.CreateDirectory(SERVERS_PATH);

            using (Stream stream = File.Open(Path.Combine(SERVERS_PATH,  "servers.bin"), FileMode.Create))
            {
                var binaryformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryformatter.Serialize(stream, servers);
            }

            return Task.CompletedTask;
        }

        private Task Connected()
        {
            using (Stream stream = File.Open(Path.Combine(SERVERS_PATH, "servers.bin"), FileMode.Open))
            {
                var binaryformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                servers = (List<Server>)binaryformatter.Deserialize(stream);
            }

            return Task.CompletedTask;
        }

        private Task JoinedGuild(SocketGuild arg)
        {
            servers.Add(new Server(arg.Id));
            return Task.CompletedTask;
        }

        private Task UserJoined(SocketGuildUser arg)
        {

            return Task.CompletedTask;
        }

        public Task AddServer(ulong id)
        {
            servers.Add(new Server(id));
            return Task.CompletedTask;
        }
    }
}
