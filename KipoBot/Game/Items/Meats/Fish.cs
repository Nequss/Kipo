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

namespace KipoBot.Game.Items.Toys
{
    class Fish : Item
    {
        public Fish()
        {
            type = Type.Meat;
            price = 30;
            name = "Fish";
            describtion = "Straight out of cleanest waters in the world, just basically melts in your pets mouths";
            hunger = 25;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}