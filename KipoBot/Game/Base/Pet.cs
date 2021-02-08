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
    public abstract class Pet
    {
        public enum Rarity
        {
            Common,
            Uncommon,
            Rare,
            Legendary
        }

        public enum Stage
        {
            Baby,
            Toddler,
            Teenager,
            Adult
        }

        public enum Type
        {
            Dog,
            Cat,
            Lizard,
            Hamster,
            Bunny,
            Snake,
            Bird
        }

        public Rarity rarity;
        public Stage stage;
        public Type type;

        //default
        public byte hapiness;
        public byte level;
        public int xp;
        public Work currentWork=null;
         
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
            rarity = Rarity.Common;
            stage = Stage.Baby;
            hapiness = 25;
            level = 1;
            xp = 0;
        }

        public void removeWork()
        {
            currentWork = null;
        }
    }
}
