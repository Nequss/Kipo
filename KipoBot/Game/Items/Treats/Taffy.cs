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

namespace KipoBot.Game.Items.Treats
{
    class Taffy : Item
    {
        public Taffy()
        {
            type = Type.Treat;
            price = 20;
            name = "Taffy";
            describtion = "Chewwy ropes of gum that are tasty as heck";
            hapiness = 15;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}