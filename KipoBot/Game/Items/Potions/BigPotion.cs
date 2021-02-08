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
    class BigPotion : Item
    {
        public BigPotion()
        {
            type = Type.Potion;
            price = 500;
            name = "Big Potion";
            describtion = "This somehow weirdly heals a lot of your pets wounds";
            health = 100;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}