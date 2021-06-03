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
using KipoBot.Utils;
using KipoBot.Game.Base;
using Discord.Addons.Interactive;

namespace KipoBot.Modules
{
    [Name("public")]
    [Summary("Contains other and fun commands")]
    public class PublicModule : ModuleBase<SocketCommandContext>
    {
        ImgurApi imgurApi = new ImgurApi(new ConfigurationService());

        [Command("imgur", RunMode = RunMode.Async)]
        [Summary("Searches for a random imgur image\n+imgur [text]")]
        public async Task Imgur([Remainder] string text) => await imgurApi.GetRandomImage(Context, text);

        [Command("pokemon", RunMode = RunMode.Async)]
        public async Task Pokemon([Remainder] String name) => await PokeApi.getPokemonInfo(Context, name);

        [Command("coinflip", RunMode = RunMode.Async)]
        [Summary("Flips a coin!\n+coinflip")]
        public async Task CoinFlip()
        {
            string result = new Random().Next(0, 2) == 0 ? "Heads!" : "Tails!";
            await Context.Channel.SendMessageAsync("You got a " + result);
        }

        [Command("8ball", RunMode = RunMode.Async)]
        [Summary("8ball always tells you the thruth!\n+8ball")]
        public async Task Ball()
        {
            string[] answers = new string[] {
                        "It is certain",
                        "It is decidedly so",
                        "Without a doubt",
                        "Yes, definitely",
                        "You may rely on it",
                        "As I see it, yes",
                        "Most likely",
                        "Outlook good",
                        "Yes",
                        "Signs point to yes",
                        "Reply hazy try again",
                        "Ask again later",
                        "Better not tell you now",
                        "Cannot predict now",
                        "Concentrate and ask again",
                        "Don't count on it",
                        "My reply is no",
                        "My sources say no",
                        "Outlook not so good",
                        "Very doubtful"
                    };

            await Context.Channel.SendMessageAsync(answers[new Random().Next(answers.Length)]);
        }

        [Command("roll", RunMode = RunMode.Async)]
        [Summary("Random number generator")]
        public async Task Roll(int  x)
        {
            Random rnd = new Random();
            int dice = rnd.Next(1, x + 1);

            await Context.Channel.SendMessageAsync("The number is " + dice);
        }

        [Command("freebies", RunMode = RunMode.Async)]
        [Summary("Shows platforms with free game")]
        public async Task Freebies()
        {
            EmbedBuilder embedBuilder = new EmbedBuilder();
            embedBuilder.Color = Color.Purple;

            string message = "";
            var re = await new HttpClient().GetStringAsync("https://www.cheapshark.com/api/1.0/stores");
            Store[] store = JsonSerializer.Deserialize<Store[]>(re);

            for (int i = 0; i < 31; i++)
            {
              
            var response = await new HttpClient().GetStringAsync("https://www.cheapshark.com/api/1.0/deals?storeID=" +i+ "&upperPrice=0");
            Deal[] freebies = JsonSerializer.Deserialize<Deal[]>(response);

                if (freebies.Length == 0)
                {
                    continue;
                }

                    else if (freebies[0].storeID == store[i-1].storeID2)
                    {
                        for (int j = 0; j <= freebies.Length; j++)
                        {
                            message += store[i-1].storeName + ":   "+ freebies[j].title;

                            embedBuilder.AddField("**List of free games today!**", message);
                            await Context.Channel.SendMessageAsync(embed: embedBuilder.Build());

                        }
                    }
            }
            
        }

        public class Deal
        {
            [JsonPropertyName("title")]
            public string title { get; set; }
            
            [JsonPropertyName("storeID")]
            public string storeID { get; set; }
        }

        public class Store
        {
            [JsonPropertyName("storeName")]
            public string storeName { get; set; }

            [JsonPropertyName("storeID")]
            public string storeID2 { get; set; }
        }
    }
}
