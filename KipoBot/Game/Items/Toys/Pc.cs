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
    class Pc : Item
    {
        public Pc()
        {
            type = Type.Toy;
            price = 700;
            name = "PC";
            describtion = "Gamus! we got them! Movies we got as well! And something more… ;)";
            hapiness = 50; //full - to change
            energy = 50;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}