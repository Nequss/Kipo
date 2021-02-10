﻿using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Beaf : Item
    {
        public Beaf()
        {
            type = Type.Meat;
            price = 10;
            name = "Beaf";
            description = "Meat from a cow, bull or ox";
            hunger = 5;
        }
    }
}