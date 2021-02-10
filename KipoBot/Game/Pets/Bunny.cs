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
    class Bunny : Pet
    {
        public Bunny()
        {
            type = Type.Bunny;
            name = "Bunny";

            health = 50;
            hunger = 20;
            thirst = 20;
            energy = 10;

            speed = 10;
            inteligence = 15;
            strength = 10;
            agility = 10;
            accuracy = 10;
        }

        public override int getBaseHealth() => 50;

        public override byte getBaseHunger() => 20;

        public override byte getBaseThirst() => 20;

        public override byte getBaseEnergy() => 10;
    }
}
