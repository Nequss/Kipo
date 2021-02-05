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

namespace KipoBot.Game.Base
{
    [Serializable]
    public abstract class Pet
    {
        //default
        public string rarity;
        public string stage;
        public byte hapiness;
        public byte level;
        public int xp;
         
        //to set
        public string name;
        public int health;
        public byte hunger;
        public byte thirst;
        public byte energy;
        public byte speed;
        public byte inteligence;
        public byte strength;
        public byte agility;
        public byte accuracy;

        protected Pet()
        {
            rarity = "Common";
            stage = "Baby";
            hapiness = 40;
            level = 1;
            xp = 0;
        }
    }
}
