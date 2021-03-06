﻿using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Banana : Item
    {
        public Banana()
        {
            type = Type.Fruit;
            price = 15;
            name = "Banana";
            description = "Yellow long fruit that is great both in taste and benefits";
            hunger = 5;
        }
    }
}