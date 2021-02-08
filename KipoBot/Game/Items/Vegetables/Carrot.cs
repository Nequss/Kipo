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
    class Carrot : Item
    {
        public Carrot()
        {
            type = Type.Vegetable;
            price = 10;
            name = "Carrot";
            describtion = "Orange vegetable, elders say its good for your eyes and skin so chew them all";
            hunger = 5;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}