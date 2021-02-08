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

namespace KipoBot.Game.Items.Potions
{
    class SmollPotion : Item
    {
        public SmollPotion()
        {
            type = Type.Potion;
            price = 100;
            name = "Smoll Potion";
            describtion = "Just enought to get back from little quarrel";
            health = 20;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}

