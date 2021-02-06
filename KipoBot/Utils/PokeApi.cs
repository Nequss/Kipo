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

namespace KipoBot.Utils
{
    public class PokeApi
    {
        class Pokemon
        {
            public string name { get; set; }
            public Sprites sprites { get; set; }
            public int id { get; set; }
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
        
        public class PokemonInfo
        {
            public List<FlavorTextEntry> flavor_text_entries { get; set; }
        }
        
        public class FlavorTextEntry
        {
            public string flavor_text { get; set; }
        }

        public static async Task getPokemonInfo(SocketCommandContext ctx, string name)
        {
            try
            {
                var pokeInfo = await Helpers.getHttpResponseString("https://pokeapi.co/api/v2/pokemon-species/" + name);
                var pokeData = await Helpers.getHttpResponseString("https://pokeapi.co/api/v2/pokemon/" + name);
                Pokemon pokemonData = JsonConvert.DeserializeObject<Pokemon>(pokeData);
                PokemonInfo pokemonInfo = JsonConvert.DeserializeObject<PokemonInfo>(pokeInfo);

                EmbedBuilder builder = new EmbedBuilder();
                builder.Color = Color.Purple;

                builder.AddField(pokemonData.name, "-")
                    .WithImageUrl(pokemonData.sprites.other.officialArtwork.front_default);
                builder.AddField("Pokedex ID:", pokemonData.id);
                builder.AddField("Pokedex Says: ", pokemonInfo.flavor_text_entries[0].flavor_text.Replace("\f"," "));

                await ctx.Channel.SendMessageAsync(embed: builder.Build());
            }
            catch (Exception e)
            {
                await ctx.Channel.SendMessageAsync("Pokemon not found: "+name);
            }
        }
    }
}