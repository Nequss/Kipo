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

namespace KipoBot.Game.Items.Treats
{
    class Gummy : Item
    {
        public Gummy()
        {
            type = Type.Treat;
            price = 15;
            name = "Gummy";
            describtion = "Tender and plump, these delicious gummies are sure to surprise and delight with every bite!";
            hapiness = 10;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}