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

namespace KipoBot.Services
{
    public class ConfigurationService
    {
        private string myConfig = File.ReadAllText(Directory.GetCurrentDirectory() + "/config.json");

        public string token;
        public string prefix;
        public string imgurid;

        public class Serialized
        {
            [JsonPropertyName("token")]
            public string _token { get; set; }
            [JsonPropertyName("prefix")]
            public string _prefix { get; set; }
            [JsonPropertyName("imgurid")]
            public string _imgurid { get; set; }
        }
   
        public ConfigurationService()
        {
            Serialized serialized = JsonSerializer.Deserialize<Serialized>(myConfig);
            token = serialized._token;
            prefix = serialized._prefix;
            imgurid = serialized._imgurid;
        }
    }
}
