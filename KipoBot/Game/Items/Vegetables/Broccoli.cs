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
    class Broccoli : Item
    {
        public Broccoli()
        {
            type = Type.Vegetable;
            price = 20;
            name = "Broccoli";
            describtion = "Something what most people and pets hate but trust me this is good as hell";
            hunger = 30;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}