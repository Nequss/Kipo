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
    class Tomato : Item
    {
        public Tomato()
        {
            type = Type.Berry;
            price = 10;
            name = "Tomato";
            describtion = "Yes, it’s a berry. It's evil in my opinion but someone else will say they are good as hell so to each their own";
            hunger = 5;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}