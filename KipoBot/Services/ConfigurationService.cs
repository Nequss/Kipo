using Discord;
using Discord.Webhook;
using Discord.WebSocket;
using Discord.Commands;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using KipoBot.Utils;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
            public string token { get; set; }
            [JsonPropertyName("prefix")]
            public string prefix { get; set; }
            [JsonPropertyName("imgurid")]
            public string imgurid { get; set; }
        }
   
        public ConfigurationService()
        {
            Serialized serialized = JsonSerializer.Deserialize<Serialized>(myConfig);
            token = serialized.token;
            prefix = serialized.prefix;
            imgurid = serialized.imgurid;
        }

        private static bool createConfigTemplate()
        {
            Serialized template = new Serialized();
            template.token = "REPLACE_WITH_YOUR_BOT_TOKEN";
            template.prefix = "+";
            template.imgurid = "REPLACE_WITH_YOUR_IMGUR_API_KEY";

            try
            {
                File.WriteAllText("config.json", JsonConvert.SerializeObject(template, Formatting.Indented));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public static bool AssertConfigFile()
        {
            if (!File.Exists($"{Helpers.WORKING_DIRECTORY}/config.json"))
            {
                if (createConfigTemplate())
                    return false;
            }
            return true;
        }
    }
}
