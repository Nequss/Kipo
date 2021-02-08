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
    class Beets : Item
    {
        public Beets()
        {
            type = Type.Vegetable;
            price = 15;
            name = "Beets";
            describtion = "Root type veggy, packed with essential vitamins, minerals and plant compounds, some of which have medicinal properties.";
            hunger = 10;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}