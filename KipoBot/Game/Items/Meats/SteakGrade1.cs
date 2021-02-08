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
    class SteakGrade1 : Item
    {
        public SteakGrade1()
        {
            type = Type.Meat;
            price = 30;
            name = "Steak Grade 1";
            describtion = "Normal steak you can buy for cheap ";
            hunger = 25;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}
