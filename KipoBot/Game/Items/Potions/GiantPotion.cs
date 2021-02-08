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

namespace KipoBot.Game.Items.Potions
{
    class GiantPotion : Item
    {
        public GiantPotion()
        {
            type = Type.Potion;
            price = 800;
            name = "Giant Potion";
            describtion = "Oh ma gahd your pets feel so good after it!";
            health = 200; //full TODO
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}