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

namespace KipoBot.Game.Items.Berries
{
    class Raspberry : Item
    {
        public Raspberry()
        {
            type = Type.Berry;
            price = 10;
            name = "Raspberry";
            describtion = "Low in calories but high in fiber, vitamins, minerals and antioxidants";
            hunger = 5;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}