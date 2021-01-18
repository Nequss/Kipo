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
using System.Collections.Generic;
using KipoBot.Services;


namespace KipoBot.Modules
{ 
    [Name("public")]
    [Summary("Contains commands available for standard users")]
    public class PublicModule : ModuleBase<SocketCommandContext>
    {
        private readonly ConfigurationService _config;
        public PublicModule(ConfigurationService config) => _config = config;

        private static readonly Random getrandom = new Random();

        public class Image
        {
            [JsonPropertyName("title")]
            public string title { get; set; }
            [JsonPropertyName("description")]
            public string description { get; set; }
            [JsonPropertyName("gifv")]
            public string gifv { get; set; }
            [JsonPropertyName("mp4")]
            public string mp4 { get; set; }
            [JsonPropertyName("link")]
            public string link { get; set; }
        }

        public class Item
        {
            [JsonPropertyName("images")]
            public List<Image> images { get; set; }
            [JsonPropertyName("link")]
            public string link { get; set; }
        }

        public class Data
        {
            [JsonPropertyName("items")]
            public List<Item> items { get; set; }

            [JsonPropertyName("total_items")]
            public int total_items { get; set; }
        }

        public class Root
        {
            [JsonPropertyName("data")]
            public Data data { get; set; }
            [JsonPropertyName("status")]
            public int status { get; set; }
        }

        public class NekosLifeApi
        {
            [JsonPropertyName("url")]
            public string Url { get; set; }
        }

        [Command("neko", RunMode = RunMode.Async)]
        [Summary("Sends random anime neko image")]
        public async Task RandomNekoAsync()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://nekos.life/api/v2/img/neko");
            NekosLifeApi nekosLifeApi = JsonSerializer.Deserialize<NekosLifeApi>(response);

            var embed = new EmbedBuilder
            {
                Title = "(≈>ܫ<≈)",
                Color = Color.Purple,
                ImageUrl = nekosLifeApi.Url
            };

            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("smug", RunMode = RunMode.Async)]
        [Summary("Sends random anime smug image")]
        public async Task RandomSmugAsync()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://nekos.life/api/v2/img/smug");
            NekosLifeApi nekosLifeApi = JsonSerializer.Deserialize<NekosLifeApi>(response);

            var embed = new EmbedBuilder
            {
                Title = @"(ಸ‿‿ಸ)",
                Color = Color.Purple,
                ImageUrl = nekosLifeApi.Url
            };

            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("slap", RunMode = RunMode.Async)]
        [Summary("Sends a random anime slap gif \n +slap [user]")]
        public async Task RandomSlapAsync(IUser user)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://nekos.life/api/v2/img/slap");
            NekosLifeApi nekosLifeApi = JsonSerializer.Deserialize<NekosLifeApi>(response);

            var embed = new EmbedBuilder
            {
                Title = Context.User.Username + " slaps " + user.Username + " (；^＿^)ッ☆(　゜o゜)",
                Color = Color.Purple,
                ImageUrl = nekosLifeApi.Url
            };

            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("kiss", RunMode = RunMode.Async)]
        [Summary("Sends a random anime kiss gif \n +kiss [user]")]
        public async Task RandomKissAsync(IUser user)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://nekos.life/api/v2/img/kiss");
            NekosLifeApi nekosLifeApi = JsonSerializer.Deserialize<NekosLifeApi>(response);

            var embed = new EmbedBuilder
            {
                Title = Context.User.Username + " kisses " + user.Username + " (ꈍᴗꈍ)ε｀*)",
                Color = Color.Purple,
                ImageUrl = nekosLifeApi.Url
            };

            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("poke", RunMode = RunMode.Async)]
        [Summary("Sends a random anime poke gif \n +poke [user]")]
        public async Task RandomPokeAsync(IUser user)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://nekos.life/api/v2/img/poke");
            NekosLifeApi nekosLifeApi = JsonSerializer.Deserialize<NekosLifeApi>(response);

            var embed = new EmbedBuilder
            {
                Title = Context.User.Username + " pokes " + user.Username + " ( ๑‾̀◡‾́)σ»",
                Color = Color.Purple,
                ImageUrl = nekosLifeApi.Url
            };

            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("hug", RunMode = RunMode.Async)]
        [Summary("Sends a random anime hug gif \n +hug [user]")]
        public async Task RandomHugAsync(IUser user)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://nekos.life/api/v2/img/hug");
            NekosLifeApi nekosLifeApi = JsonSerializer.Deserialize<NekosLifeApi>(response);

            var embed = new EmbedBuilder
            {
                Title = Context.User.Username + " hugs " + user.Username + " (✿˶◕‿◕˶人◕ᴗ◕✿)",
                Color = Color.Purple,
                ImageUrl = nekosLifeApi.Url
            };

            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("baka", RunMode = RunMode.Async)]
        [Summary("Sends a random anime baka gif \n +baka [user]")]
        public async Task RandomBakaAsync(IUser user)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://nekos.life/api/v2/img/baka");
            NekosLifeApi nekosLifeApi = JsonSerializer.Deserialize<NekosLifeApi>(response);

            var embed = new EmbedBuilder
            {
                Title = Context.User.Username + " thinks " + user.Username + " is baka! (◣_◢)",
                Color = Color.Purple,
                ImageUrl = nekosLifeApi.Url
            };

            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("pat", RunMode = RunMode.Async)]
        [Summary("Sends a random anime pat gif \n +pat [user]")]
        public async Task RandomPatAsync(IUser user)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://nekos.life/api/v2/img/pat");
            NekosLifeApi nekosLifeApi = JsonSerializer.Deserialize<NekosLifeApi>(response);

            var embed = new EmbedBuilder
            {
                Title = Context.User.Username + " pats " + user.Username + " (；^＿^)ッ☆(　゜w゜)",
                Color = Color.Purple,
                ImageUrl = nekosLifeApi.Url
            };

            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        public async Task GetRandomImage(string command)
        {
            HttpClient imgurClient = new HttpClient();
            imgurClient.DefaultRequestHeaders.Add("Authorization", "Client-ID " + _config.imgurid);

            var response = await imgurClient.GetStringAsync("https://api.imgur.com/3/gallery/t/" + command);
            Root root = JsonSerializer.Deserialize<Root>(response);

            if (root.data.total_items != 0)
            {
                int randomgallery = getrandom.Next(root.data.items.Count);

                if (root.data.items[randomgallery].images == null)
                {
                    await Context.Channel.SendMessageAsync(root.data.items[randomgallery].link);
                }
                else
                {
                    int randomimage = getrandom.Next(root.data.items[randomgallery].images.Count);
                    await Context.Channel.SendMessageAsync(root.data.items[randomgallery].images[randomimage].link);
                }
            }
            else
            {
                await Context.Channel.SendMessageAsync($"I couldn't find anything :c");
            }
        }

        [Command("imgur", RunMode = RunMode.Async)]
        [Summary("Searches for a random imgur image \n +imgur [phrase]")]
        public async Task RandomSearch(params string[] objects) => await GetRandomImage(string.Join(" ", objects));

        //TODO using pokemon api - +pokemon [name]
        [Command("pokemon", RunMode = RunMode.Async)]
        public async Task Pokemon()
        {

        }

        //TODO using covid api - +covid [country]
        [Command("covid", RunMode = RunMode.Async)]
        public async Task Covid()
        {

        }

        //TODO - flips a coin
        [Command("flip", RunMode = RunMode.Async)]
        public async Task Flip()
        {

        }

        //TODO +rps Play rock, papers, scissors with the bot.	
        //+rps [choice]
        [Command("rps", RunMode = RunMode.Async)]
        public async Task Rps()
        {

        }

        //TODO +poll [bot_message] [choice_1] ... [choice_9]
        //Starts a poll for people to vote on. Up to max. 9 choices
        [Command("poll", RunMode = RunMode.Async)]
        public async Task Poll()
        {

        }
    }
}
