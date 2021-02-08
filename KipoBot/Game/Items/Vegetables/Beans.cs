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
    class Beans : Item
    {
        public Beans()
        {
            type = Type.Vegetable;
            price = 20;
            name = "Beans";
            describtion = "Beans… beans… beans… BEANS!!!";
            hunger = 15;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}