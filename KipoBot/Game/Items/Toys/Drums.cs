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
    class Drums : Item
    {
        public Drums()
        {
            type = Type.Toy;
            price = 200;
            name = "Drums";
            describtion = "Boom Dum-ba-badump, let's play with some boom-ba-drooms!";
            hapiness = 60;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}