using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KipoBot.Modules
{
    public class NekosLifeModule : ModuleBase<SocketCommandContext>
    {
        public class NekosLifeApi
        {
            [JsonPropertyName("url")]
            public string Url { get; set; }
        }

        [Command("neko")]
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

        [Command("smug")]
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

        [Command("slap")]
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

        [Command("kiss")]
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

        [Command("poke")]
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

        [Command("hug")]
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

        [Command("baka")]
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

        [Command("pat")]
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
