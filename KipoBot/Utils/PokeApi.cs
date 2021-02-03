using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Kipo.Utils
{
    public class PokeApi
    {
        class Pokemon
        {
            public string name { get; set; }
            public Sprites sprites { get; set; }
        }
        
        public class Other{
            [JsonProperty("official-artwork")]
            public OfficialArtwork officialArtwork { get; set; } 
        }
        
        public class Sprites{
            public Other other { get; set; } 
        }
        
        public class OfficialArtwork{
            public string front_default { get; set; } 
        }

        public static async Task getPokemonInfo(SocketCommandContext ctx, string name)
        {
            HttpClient apiClient = new HttpClient();
            var response = await apiClient.GetAsync("https://pokeapi.co/api/v2/pokemon/"+name);
            var json = await response.Content.ReadAsStringAsync();
            Pokemon pokemonData = JsonConvert.DeserializeObject<Pokemon>(json);

            EmbedBuilder builder = new EmbedBuilder();
            builder.Color = Color.Purple;
            
            builder.AddField(pokemonData.name, "-")
                .WithImageUrl(pokemonData.sprites.other.officialArtwork.front_default);
            

            ctx.Channel.SendMessageAsync(embed: builder.Build());
        }
    }
}