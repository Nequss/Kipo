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

namespace KipoBot.Game.Items.Drinks
{
    class Milk : Item
    {
        public Milk()
        {
            type = Type.Drink;
            price = 20;
            name = "Milk";
            describtion = "Milked straight from a cow, it's deliciuos and good for babies";
            thirst = 15;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}