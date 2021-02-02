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

namespace KipoBot.Utils
{
    public class ImgurApi
    {
        class Image
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

        class Item
        {
            [JsonPropertyName("images")]
            public List<Image> images { get; set; }
            [JsonPropertyName("link")]
            public string link { get; set; }
        }

        class Data
        {
            [JsonPropertyName("items")]
            public List<Item> items { get; set; }

            [JsonPropertyName("total_items")]
            public int total_items { get; set; }
        }

        class Root
        {
            [JsonPropertyName("data")]
            public Data data { get; set; }
            [JsonPropertyName("status")]
            public int status { get; set; }
        }

        private readonly ConfigurationService _config;
        public ImgurApi(ConfigurationService config) => _config = config;

        Random getrandom = new Random();

        public async Task GetRandomImage(SocketCommandContext Context, string command)
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
    }
}
