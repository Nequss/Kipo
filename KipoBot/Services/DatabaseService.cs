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
using KipoBot.Utils;
using KipoBot.Game;
using KipoBot.Game.Base;
using KipoBot.Game.Pets;

namespace KipoBot.Services
{
    public class DatabaseService
    {
        [Serializable]
        public class Server
        {
            public ulong id;
            public ulong? channel_id;
            public string caption;
            public string message;
            public char prefix;

            public Server
            (
                ulong _id,
                ulong? _channel_id = null,
                string _caption = "Hello %USERNAME%!\nWelcome to the server!",
                string _message = "",
                char _prefix = '+'
            )
            {
                id = _id;
                channel_id = _channel_id;
                caption = _caption;
                message = _message;
                prefix = _prefix;
            }
        }

        private readonly DiscordSocketClient _client;

        public List<Server> servers;
        public List<Player> players;
        public List<Pet> pets;

        string PATH = Helpers.WORKING_DIRECTORY + @"/data/";

        public DatabaseService(DiscordSocketClient client)
        {
            String[] reqFiles = {"servers","players","pets"};
            foreach (var file in reqFiles)
            {
                String tmp = $"{PATH}{file}.bin";

                if (!Helpers.FileExists(tmp))
                {
                    File.Create(tmp);
                    Console.WriteLine($"Created DB file: {tmp}");
                }
                else
                {
                    Console.WriteLine($"Found existing DB file: {tmp}");
                }
            }
            
            _client = client;

            _client.UserJoined += UserJoined;
            _client.JoinedGuild += JoinedGuild;
            _client.Connected += Connected;
            _client.Disconnected += Disconnected;
        }
       
        private Task Disconnected(Exception arg)
        {
            Stream stream;
            var binaryformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            stream = File.Open(Path.Combine(PATH, "servers.bin"), FileMode.Open);
            binaryformatter.Serialize(stream, servers);

            stream = File.Open(Path.Combine(PATH, "pets.bin"), FileMode.Open);
            binaryformatter.Serialize(stream, pets);

            stream = File.Open(Path.Combine(PATH, "players.bin"), FileMode.Open);
            binaryformatter.Serialize(stream, players);

            return Task.CompletedTask;
        }

        private Task Connected()
        {
            Stream stream;
            var binaryformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            stream = File.Open(Path.Combine(PATH, "servers.bin"), FileMode.Open);
            servers = (List<Server>)binaryformatter.Deserialize(stream);

            stream = File.Open(Path.Combine(PATH, "pets.bin"), FileMode.Open);
            pets = (List<Pet>)binaryformatter.Deserialize(stream);

            stream = File.Open(Path.Combine(PATH, "players.bin"), FileMode.Open);
            players = (List<Player>)binaryformatter.Deserialize(stream);

            return Task.CompletedTask;
        }

        private Task JoinedGuild(SocketGuild arg)
        {
            servers.Add(new Server(arg.Id));
            return Task.CompletedTask;
        }

        private Task UserJoined(SocketGuildUser arg)
        {
            foreach (var server in servers)
            {
                if (server.id == arg.Guild.Id)
                {
                    if (server.channel_id != null)
                    {
                        Stream file = ImageMaker.welcomeUser(arg.Username, server.caption, arg.Guild.Name);
                        arg.Guild.GetTextChannel(server.channel_id.Value).SendFileAsync(file, "welcome.png", $"{server.message.Replace("%MENTION%", $"{arg.Mention}").Replace("%USERNAME%", $"{arg.Username}").Replace("%SERVERNAME%", $"{arg.Guild.Name}")}");
                    }
                }
            }

            return Task.CompletedTask;
        }

        public Task AddServer(ulong id)
        {
            servers.Add(new Server(id));
            return Task.CompletedTask;
        }

        public Task AddPlayer(ulong id, string command)
        {
            switch (command.ToLower())
            {
                case "bird":
                    break;
                case "dog":
                    players.Add(new Player(id, new Dog(pets.Count)));
                    break;
                case "cat":
                    break;
                case "lizard":
                    break;
                case "hamster":
                    break;
                case "snake":
                    break;
                case "bunny":
                    break;
            }
            
            return Task.CompletedTask;
        }
    }
}
