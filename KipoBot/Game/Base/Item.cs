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

namespace KipoBot.Game.Base
{
    public abstract class Item
    {
        public enum Type
        {
            Toy,
            Potion,
            Meat,
            Vegetable,
            Berry,
            Drink,
            Fruits,
            Treats
        }

        public Type type;
        public short price;
        public string name;
        public string describtion;
        public byte hapiness;
        public byte health;
        public byte hunger;
        public byte thirst;
        public byte energy;

        public abstract Pet Use(Pet pet);
    }
}
