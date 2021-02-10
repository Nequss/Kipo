﻿using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Treats
{
    [Serializable]
    class JellyBeans : Item
    {
        public JellyBeans()
        {
            type = Type.Treat;
            price = 20;
            name = "JellyBeans";
            describtion = "Chocolate beans but filled with jelly";
            hapiness = 15;
        }
    }
}