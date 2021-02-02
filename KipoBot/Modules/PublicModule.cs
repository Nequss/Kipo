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

        //TODO
        [Command("imgur", RunMode = RunMode.Async)]
        [Summary("Searches for a random imgur image \n +imgur [text]")]
        public async Task Imgur([Remainder]string text) => await imgurApi.GetRandomImage(Context, text);

        //TODO using pokemon api - +pokemon [name]
        [Command("pokemon", RunMode = RunMode.Async)]
        public async Task Pokemon([Remainder] String name) => PokeApi.test(Context, name);

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
