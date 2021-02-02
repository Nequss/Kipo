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
using Kipo.Utils;
using KipoBot.Services;
using KipoBot.Utils;

namespace KipoBot.Modules
{
    [Name("public")]
    [Summary("Contains other and fun commands")]
    public class PublicModule : ModuleBase<SocketCommandContext>
    {
        ImgurApi imgurApi = new ImgurApi(new ConfigurationService());

        [Command("imgur", RunMode = RunMode.Async)]
        [Summary("Searches for a random imgur image\n+imgur [text]")]
        public async Task Imgur([Remainder]string text) => await imgurApi.GetRandomImage(Context, text);

        //TODO using pokemon api - +pokemon [name]
        [Command("pokemon", RunMode = RunMode.Async)]
        public async Task Pokemon([Remainder] String name) => PokeApi.getPokemonInfo(Context, name);

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
    }
}
