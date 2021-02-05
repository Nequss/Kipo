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
using System.Collections.Generic;

namespace KipoBot.Game.Base
{
    [Serializable]
    public class Player
    {
        public ulong id;
        public int wallet;
        public Pet active;
        public List<Pet> pets;
        public List<Item> items;

        public Player(ulong _id, Pet pet)
        {
            id = _id;
            this.wallet = 100;
            this.pets = new List<Pet>();
            this.pets.Add(pet);
            this.active = pet;
            this.items = new List<Item>();
        }
    }
}
