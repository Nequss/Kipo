﻿using Discord;
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
    class Console : Item
    {
        public Console()
        {
            type = Type.Toy;
            price = 250;
            name = "Console";
            describtion = "Your pet can play epic games that will get it into true gamer mindset!";
            hapiness = 45; 
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}