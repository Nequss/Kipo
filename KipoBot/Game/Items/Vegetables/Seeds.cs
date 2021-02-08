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
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using KipoBot.Services;
using KipoBot.Game.Base;


namespace KipoBot.Game.Items.Vegetables
{
    class Seeds : Item
    {
        public Seeds()
        {
            type = Type.Vegetable;
            price = 10;
            name = "Seeds";
            describtion = "Only for small pets, other ones woudn't even feel the nutrition values of it";
            hunger = 5;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}
