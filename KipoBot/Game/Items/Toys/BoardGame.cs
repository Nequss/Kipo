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
    class BoardGame : Item
    {
        public BoardGame()
        {
            type = Type.Toy;
            price = 15;
            name = "Board Game";
            describtion = @"Let your pet enjoy to play some board games like they are the smartest in the world, which we all know they are :3";
            hapiness = 50;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}