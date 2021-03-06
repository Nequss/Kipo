﻿using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class Bacon : Item
    {
        public Bacon()
        {
            type = Type.Meat;
            price = 15;
            name = "Bacon";
            description = "Meat from the back or sides of a pig that's cured and sliced";
            hunger = 5;
        }
    }
}