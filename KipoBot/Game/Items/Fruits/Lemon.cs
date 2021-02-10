﻿using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Lemon : Item
    {
        public Lemon()
        {
            type = Type.Fruit;
            price = 15;
            name = "Lemon";
            describtion = "Very sour that’s all you need to know";
            hunger = 10;
        }
    }
}