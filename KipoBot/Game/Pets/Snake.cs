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
    class Snake : Pet
    {
        public Snake()
        {
            type = Type.Snake;
            name = "Snake";

            health = 40;
            hunger = 20;
            thirst = 25;
            energy = 10;

            speed = 10;
            inteligence = 10;
            strength = 10;
            agility = 10;
            accuracy = 15;
        }

        public override int getBaseHealth() => 40;

        public override byte getBaseHunger() => 20;

        public override byte getBaseThirst() => 25;

        public override byte getBaseEnergy() => 10;
    }
}
