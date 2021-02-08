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
    class HugeBall : Item
    {
        public HugeBall()
        {
            type = Type.Toy;
            price = 50;
            name = "Huge Ball";
            describtion = "A big ball for your pets to play with roll on it or use it as a weapon to throw at you when they get mad ";
            hapiness = 30;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}
