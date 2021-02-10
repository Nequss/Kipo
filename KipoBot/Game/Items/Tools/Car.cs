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

namespace KipoBot.Game.Items.Tools
{
    class Car : Item
    {
        public Car()
        {
            type = Type.Tool;
            price = 3000;
            name = "Car";
            describtion = "Let your pet drive around the city in brand new car!";
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}