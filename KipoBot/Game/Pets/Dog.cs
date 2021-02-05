using Discord;
using Discord.Webhook;
using Discord.WebSocket;
using Discord.Commands;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using KipoBot.Services;
using KipoBot.Game.Base;

namespace KipoBot.Game.Pets
{
    class Dog : Pet
    {
        public Dog(int petId)
        {
            name = "Dog";
            id = petId;
            health = 50;
            hunger = 20;
            thirst = 20;
            energy = 10;
            speed  = 10;
            inteligence = 15;
            strength = 10;
            agility = 10;
            accuracy = 10;
        }
    }
}
