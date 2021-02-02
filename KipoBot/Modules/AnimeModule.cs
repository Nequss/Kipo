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
    [Name("anime")]
    [Summary("Contains anime related commands")]
    public class AnimeModule : ModuleBase<SocketCommandContext>
    {
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

    }
}
