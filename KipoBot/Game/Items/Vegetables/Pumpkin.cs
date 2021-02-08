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


namespace KipoBot.Game.Items.Vegetables
{
    class Pumpkin : Item
    {
        public Pumpkin()
        {
            type = Type.Vegetable;
            price = 50;
            name = "Pumpkin";
            describtion = "Big orange and scary if carved, it just screams halloween";
            hunger = 30;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}
