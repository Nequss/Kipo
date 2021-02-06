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
    class Bird : Pet
    {
        public Bird()
        {
            type = Type.Bird;
            name = "Bird";
            health = 40;
            hunger = 25;
            thirst = 25;
            energy = 15;
            speed = 10;
            inteligence = 10;
            strength = 5;
            agility = 10;
            accuracy = 10;
        }
    }
}
