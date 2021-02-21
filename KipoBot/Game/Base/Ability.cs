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
using System.Reflection;
using KipoBot.Utils;

namespace KipoBot.Game.Base
{
    [Serializable]
    public abstract class Ability
    {
        public string name;
        public string description;
        public short price;

        public int Damage(Pet pet) 
            => Math.Round((pet.strength * 0.1) + (Speed(pet) * 0.1) + (pet.agility * 0.4) + (pet.level * 0.2));

        public abstract bool Dodge(Pet pet);

        public abstract bool Hit(Pet pet);

        public abstract int Speed(Pet pet);

        public abstract Task Use(Pet attacker, Pet target);
    }
}