﻿using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class Chicken : Item
    {
        public Chicken()
        {
            type = Type.Meat;
            price = 10;
            name = "Chicken";
            description = "Some chimken";
            hunger = 5;
        }
    }
}