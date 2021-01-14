using System;
using Discord.Commands;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Kipo.Modules
{
    public class ImgurModule : ModuleBase<SocketCommandContext>
    {
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

        public async Task GetRandomImage(string command)
        {

            string id = "7f6c96ad9740937";

            HttpClient imgurClient = new HttpClient();
            imgurClient.DefaultRequestHeaders.Add("Authorization", "Client-ID " + id);

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

        [Command("imgur")]
        public async Task RandomSearch(params string[] objects) => await GetRandomImage(string.Join(" ", objects));
    }
}