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
            var embed = await CreateEmbedWithImage("(≈>ܫ<≈)", "https://nekos.life/api/v2/img/neko");
            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("smug", RunMode = RunMode.Async)]
        [Summary("Sends random anime smug image")]
        public async Task RandomSmugAsync()
        {
            var embed = await CreateEmbedWithImage(@"(ಸ‿‿ಸ)", "https://nekos.life/api/v2/img/smug");
            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("slap", RunMode = RunMode.Async)]
        [Summary("Sends a random anime slap gif \n +slap [user]")]
        public async Task RandomSlapAsync([Remainder] string specifiedUser)
        {
            IUser user = Helpers.extractUser(Context, specifiedUser);
            if (userNotFound(Context, user))
                return;
            var embed = await CreateEmbedWithImage(Context.User.Username + " slaps " + user.Username + @"(ಸ‿‿ಸ)", "https://nekos.life/api/v2/img/slap");
            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("kiss", RunMode = RunMode.Async)]
        [Summary("Sends a random anime kiss gif \n +kiss [user]")]
        public async Task RandomKissAsync([Remainder] string specifiedUser)
        {
            IUser user = Helpers.extractUser(Context, specifiedUser);
            if (userNotFound(Context, user))
                return;
            var embed = await CreateEmbedWithImage(Context.User.Username + " kisses " + user.Username + " (ꈍᴗꈍ)ε｀*)", "https://nekos.life/api/v2/img/kiss");
            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("poke", RunMode = RunMode.Async)]
        [Summary("Sends a random anime poke gif \n +poke [user]")]
        public async Task RandomPokeAsync([Remainder] string specifiedUser)
        {
            IUser user = Helpers.extractUser(Context, specifiedUser);
            if (userNotFound(Context, user))
                return;
            var embed = await CreateEmbedWithImage(Context.User.Username + " pokes " + user.Username + " ( ๑‾̀◡‾́)σ»", "https://nekos.life/api/v2/img/poke");
            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("hug", RunMode = RunMode.Async)]
        [Summary("Sends a random anime hug gif \n +hug [user]")]
        public async Task RandomHugAsync([Remainder] string specifiedUser)
        {
            IUser user = Helpers.extractUser(Context, specifiedUser);
            if (userNotFound(Context, user))
                return;
            var embed = await CreateEmbedWithImage(Context.User.Username + " hugs " + user.Username + " (✿˶◕‿◕˶人◕ᴗ◕✿)", "https://nekos.life/api/v2/img/hug");
            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("baka", RunMode = RunMode.Async)]
        [Summary("Sends a random anime baka gif \n +baka [user]")]
        public async Task RandomBakaAsync([Remainder] string specifiedUser)
        {
            IUser user = Helpers.extractUser(Context, specifiedUser);
            if (userNotFound(Context, user))
                return;
            var embed = await CreateEmbedWithImage(Context.User.Username + " thinks " + user.Username + " is baka! (◣_◢)", "https://nekos.life/api/v2/img/baka");
            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("pat", RunMode = RunMode.Async)]
        [Summary("Sends a random anime pat gif \n +pat [user]")]
        public async Task RandomPatAsync([Remainder] string specifiedUser)
        {
            IUser user = Helpers.extractUser(Context, specifiedUser);
            if (userNotFound(Context, user))
                return;
            var embed = await CreateEmbedWithImage(Context.User.Username + " pats " + user.Username + " (；^＿^)ッ☆(　゜w゜)", "https://nekos.life/api/v2/img/pat");
            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        private static async Task<EmbedBuilder> CreateEmbedWithImage(string title, string url)
        {
            NekosLifeApi api = JsonSerializer.Deserialize<NekosLifeApi>(await Helpers.getHttpResponseString(url));

            var embed = new EmbedBuilder()
            {
                Title = title,
                Color = Color.Purple,
                ImageUrl = api.Url
            };
            return embed;
        }

        private static bool userNotFound(SocketCommandContext ctx, IUser impliedUser)
        {
            if (impliedUser == null)
            {
                ctx.Channel.SendMessageAsync($"User not found.");
                return true;
            }

            return false;
        }
    }
}
