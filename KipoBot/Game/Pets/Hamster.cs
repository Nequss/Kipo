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
    [Serializable]
    class Hamster : Pet
    {
        public Hamster()
        {
            type = Type.Hamster;
            name = "Hamster";

            health = 40;
            hunger = 25;
            thirst = 25;
            energy = 10;

            speed = 15;
            inteligence = 15;
            strength = 5;
            agility = 10;
            accuracy = 10;
        }

        public override int getBaseHealth() => 40;

        public override byte getBaseHunger() => 25;

        public override byte getBaseThirst() => 25;

        public override byte getBaseEnergy() => 10;
    }
}
