﻿using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class Fish : Item
    {
        public Fish()
        {
            type = Type.Meat;
            price = 35;
            name = "Fish";
            description = "Straight out of cleanest waters in the world, just basically melts in your pets mouths";
            hunger = 25;
        }
    }
}