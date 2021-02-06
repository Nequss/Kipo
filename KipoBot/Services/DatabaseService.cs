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
                ulong _channel_id,
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

        string PATH = Helpers.WORKING_DIRECTORY + @"/data/";

        public DatabaseService(DiscordSocketClient client)
        {
            _client = client;

            _client.UserJoined += UserJoined;
            _client.JoinedGuild += JoinedGuild;
            _client.Connected += Connected;
            _client.Disconnected += Disconnected;
        }
       
        private Task Disconnected(Exception arg)
        {
            var binaryformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            Stream stream;

            using (stream = File.Open(Path.Combine(PATH, "servers.bin"), FileMode.OpenOrCreate))
                binaryformatter.Serialize(stream, servers);

            using (stream = File.Open(Path.Combine(PATH, "players.bin"), FileMode.OpenOrCreate))
                binaryformatter.Serialize(stream, players);

            return Task.CompletedTask;
        }

        private Task Connected()
        {
            Stream stream;
            var binaryformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            if (Helpers.FileExists($"{PATH}/servers.bin"))
            {
                stream = File.Open(Path.Combine(PATH, "servers.bin"), FileMode.Open);
                servers = (List<Server>)binaryformatter.Deserialize(stream);
                Console.WriteLine($"Succesfully loaded DB: {PATH}/servers.bin");
            }
            else
            {
                servers = new List<Server>();
            }

            if (Helpers.FileExists($"{PATH}/players.bin"))
            {
                stream = File.Open(Path.Combine(PATH, "players.bin"), FileMode.Open);
                players = (List<Player>)binaryformatter.Deserialize(stream);
                Console.WriteLine($"Succesfully loaded DB: {PATH}/players.bin");
            }
            else
            {
                players = new List<Player>();
            }

            return Task.CompletedTask;
        }

        private Task JoinedGuild(SocketGuild arg)
        {
            return Task.CompletedTask;
        }

        private Task UserJoined(SocketGuildUser arg)
        {
            if (servers != null && servers.Count != 0)
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
            }

            return Task.CompletedTask;
        }

        public Task AddServer(ulong id, ulong channel_id)
        {
            servers.Add(new Server(id, channel_id));
            return Task.CompletedTask;
        }

        public async Task<string> AddPlayer(ulong id, string command)
        {
            switch (command.ToLower())
            {
                case "bird":
                    players.Add(new Player(id, new Bird()));
                    return "You have succesfully joined to Kipo's tamagotchi club with a bird!";
                case "dog":
                    players.Add(new Player(id, new Dog()));
                    return "You have succesfully joined to Kipo's tamagotchi club with a dog!";
                case "cat":
                    players.Add(new Player(id, new Cat()));
                    return "You have succesfully joined to Kipo's tamagotchi club with a cat!";
                case "lizard":
                    players.Add(new Player(id, new Lizard()));
                    return "You have succesfully joined to Kipo's tamagotchi club with a lizard!";
                case "hamster":
                    players.Add(new Player(id, new Hamster()));
                    return "You have succesfully joined to Kipo's tamagotchi club with a hamster!";
                case "snake":
                    players.Add(new Player(id, new Snake()));
                    return "You have succesfully joined to Kipo's tamagotchi club with a snake!";
                case "bunny":
                    players.Add(new Player(id, new Bunny()));
                    return "You have succesfully joined to Kipo's tamagotchi club with a bunny!";
                default:
                    return "Pet not found! +t starters choose [pet]";

            }
        }
    }
}
