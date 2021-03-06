﻿using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Berries
{
    [Serializable]
    class Grape : Item
    {
        public Grape()
        {
            type = Type.Berry;
            price = 22;
            name = "Grape";
            description = "Commonly used in wine making";
            hunger = 12;
        }
    }
}