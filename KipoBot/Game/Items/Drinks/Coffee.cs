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
    class Coffee : Item
    {
        public Coffee()
        {
            type = Type.Drink;
            price = 20;
            name = "Coffee";
            describtion = "Coffee is good for your pet's mind and soul to get some energy and motivation";
            thirst = 10;
            energy = 5;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}