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
    class MediumPotion : Item
    {
        public MediumPotion()
        {
            type = Type.Potion;
            price = 300;
            name = "Medium Potion";
            describtion = "Smoth tasting weird drink, your pets always wonder what it does";
            health = 50;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}