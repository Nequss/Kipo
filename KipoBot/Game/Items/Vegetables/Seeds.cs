﻿using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class Seeds : Item
    {
        public Seeds()
        {
            type = Type.Vegetable;
            price = 15;
            name = "Seeds";
            description = "Only for small pets, other ones woudn't even feel the nutrition values of it";
            hunger = 5;
        }
    }
}
