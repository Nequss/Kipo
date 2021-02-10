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
    class BubbleGum : Item
    {
        public BubbleGum()
        {
            type = Type.Treat;
            price = 10;
            name = "Bubble gum";
            describtion = "You can chew it and chew it for hours till it looses its taste";
            hapiness = 5;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}