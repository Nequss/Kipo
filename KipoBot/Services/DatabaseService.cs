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

        /* Serializable/Deserializable */
        public List<Server> servers;
        public List<Player> players;
        public List<Item> market;

        /* Shop list indexes [x][y] | x - category | y - items
         * [0][y] - berries
         * [1][y] - drinks
         * [2][y] - fruits
         * [3][y] - meats
         * [4][y] - potions
         * [5][y] - tools
         * [6][y] - toys
         * [7][y] - treats
         * [8][y] - vegetables */

        public List<List<Item>> shop = new List<List<Item>>();
        public List<Ability> abilities = new List<Ability>();
        public List<Type> jobs = new List<Type>();

        string PATH = Helpers.WORKING_DIRECTORY + @"/data/";

        public DatabaseService(DiscordSocketClient client)
        {
            string[] spaces = {
                "KipoBot.Game.Items.Berries",
                "KipoBot.Game.Items.Drinks",
                "KipoBot.Game.Items.Fruits",
                "KipoBot.Game.Items.Meats",
                "KipoBot.Game.Items.Potions",
                "KipoBot.Game.Items.Tools",
                "KipoBot.Game.Items.Toys",
                "KipoBot.Game.Items.Treats",
                "KipoBot.Game.Items.Vegetables",
            };

            int x = 0;

            foreach (string name in spaces)
            {
                var items = Assembly.GetExecutingAssembly().GetTypes()
                    .Where(t => t.Namespace == name)
                    .ToList();

                Program.Logger.info($"Following items' instances will be created from {name} and added to shop list:");
                
                shop.Add(new List<Item>());

                foreach (Type item in items)
                {
                    Program.Logger.info(item.ToString() + ".cs");
                    shop[x].Add((Item)Activator.CreateInstance(item));
                }

                Program.Logger.info("Finished!");

                x++;
            }

            Program.Logger.info($"Following jobs class types will be created from KipoBot.Game.Jobs and added to the job list");

            jobs = Assembly.GetExecutingAssembly().GetTypes()
                    .Where(t => t.Namespace == "KipoBot.Game.Jobs")
                    .ToList();

            foreach (Type job in jobs)
                Program.Logger.info(job.ToString() + ".cs");

            Program.Logger.info($"Following abilities instances will be created from KipoBot.Game.Abilities and added to the abilities list");

            var abilitiesTypes = Assembly.GetExecutingAssembly().GetTypes()
                    .Where(t => t.Namespace == "KipoBot.Game.Abilities")
                    .ToList();

            foreach (var ability in abilitiesTypes)
            {
                abilities.Add((Ability)Activator.CreateInstance(ability));
                Program.Logger.info(ability.ToString() + ".cs");
            }

            _client = client;

            _client.UserJoined += UserJoined;
            _client.Connected += Connected;
            _client.Disconnected += Disconnected; 
        }
        
        private void loadJobs()
        {
            foreach (var player in players)
            {
                foreach (var pet in player.pets)
                {
                    if (pet.hasWork())
                        pet.currentWork.addToWorkList();
                }
            }
        }
       
        private Task Disconnected(Exception arg)
        {
            var binaryformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            Stream stream;

            using (stream = File.Open(Path.Combine(PATH, "servers.bin"), FileMode.OpenOrCreate))
                binaryformatter.Serialize(stream, servers);

            using (stream = File.Open(Path.Combine(PATH, "players.bin"), FileMode.OpenOrCreate))
                binaryformatter.Serialize(stream, players);

            using (stream = File.Open(Path.Combine(PATH, "market.bin"), FileMode.OpenOrCreate))
                binaryformatter.Serialize(stream, market);

            return Task.CompletedTask;
        }

        private Task Connected()
        {
            Stream stream;
            var binaryformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            if (Helpers.FileExists($"{PATH}servers.bin"))
            {
                stream = File.Open(Path.Combine(PATH, "servers.bin"), FileMode.Open);
                servers = (List<Server>)binaryformatter.Deserialize(stream);
                Program.Logger.info($"Succesfully loaded DB: {PATH}servers.bin");
                stream.Close();
            }
            else
            {
                servers = new List<Server>();
            }

            if (Helpers.FileExists($"{PATH}players.bin"))
            {
                stream = File.Open(Path.Combine(PATH, "players.bin"), FileMode.Open);
                players = (List<Player>)binaryformatter.Deserialize(stream);
                Program.Logger.info($"Succesfully loaded DB: {PATH}players.bin");
                stream.Close();
            }
            else
            {
                players = new List<Player>();
            }

            if (Helpers.FileExists($"{PATH}market.bin"))
            {
                stream = File.Open(Path.Combine(PATH, "market.bin"), FileMode.Open);
                market = (List<Item>)binaryformatter.Deserialize(stream);
                Program.Logger.info($"Succesfully loaded DB: {PATH}market.bin");
                stream.Close();
            }
            else
            {
                market = new List<Item>();
            }

            loadJobs();
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

        public async Task Save()
        {
            var binaryformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            Stream stream;

            using (stream = File.Open(Path.Combine(PATH, "servers.bin"), FileMode.OpenOrCreate))
                binaryformatter.Serialize(stream, servers);

            using (stream = File.Open(Path.Combine(PATH, "players.bin"), FileMode.OpenOrCreate))
                binaryformatter.Serialize(stream, players);
        }

        public async Task AddServer(ulong id, ulong channel_id) => servers.Add(new Server(id, channel_id));

        public async Task<Player> PlayerInfo(ulong id)
        {
            if (players != null && players.Count != 0)
            {
                foreach (var player in players)
                {
                    if (player.id == id)
                    {
                        return player;
                    }
                }
            }

            return null;
        }

        public async Task<bool> AddPet(ulong id, string pet)
        {
            if (players != null && players.Count != 0)
            {
                foreach (var player in players)
                {
                    if (player.id == id)
                    {
                        switch (pet.ToLower())
                        {
                            case "bird":
                                player.pets.Add(new Bird());
                                return true;
                            case "dog":
                                player.pets.Add(new Dog());
                                return true;
                            case "cat":
                                player.pets.Add(new Cat());
                                return true;
                            case "lizard":
                                player.pets.Add(new Lizard());
                                return true;
                            case "hamster":
                                player.pets.Add(new Hamster());
                                return true;
                            case "snake":
                                player.pets.Add(new Snake());
                                return true;
                            case "bunny":
                                player.pets.Add(new Bunny());
                                return true;
                            default:
                                return false;
                        }
                    }
                }
            }

            return false;
        }

        public async Task<string> AddPlayer(ulong id, string pet)
        {
            switch (pet.ToLower())
            {
                case "bird":
                    players.Add(new Player(id, new Bird()));
                    return "You have succesfully joined to the Kipo's tamagotchi club with a bird!";
                case "dog":
                    players.Add(new Player(id, new Dog()));
                    return "You have succesfully joined to the Kipo's tamagotchi club with a dog!";
                case "cat":
                    players.Add(new Player(id, new Cat()));
                    return "You have succesfully joined to the Kipo's tamagotchi club with a cat!";
                case "lizard":
                    players.Add(new Player(id, new Lizard()));
                    return "You have succesfully joined to the Kipo's tamagotchi club with a lizard!";
                case "hamster":
                    players.Add(new Player(id, new Hamster()));
                    return "You have succesfully joined to the Kipo's tamagotchi club with a hamster!";
                case "snake":
                    players.Add(new Player(id, new Snake()));
                    return "You have succesfully joined to the Kipo's tamagotchi club with a snake!";
                case "bunny":
                    players.Add(new Player(id, new Bunny()));
                    return "You have succesfully joined to the Kipo's tamagotchi club with a bunny!";
                default:
                    return "error";
            }
        }
        
        public async Task<Player> FindPlayer(ulong id)
        {
            if (players != null && players.Count != 0)
            {
                foreach (var player in players)
                {
                    if (player.id == id)
                    {
                        return player;
                    }
                }

                return null;
            }
            else
            {
                return null;
            }
        }
    }
}