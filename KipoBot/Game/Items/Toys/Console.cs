﻿using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Console : Item
    {
        public Console()
        {
            type = Type.Toy;
            price = 250;
            name = "Console";
            describtion = "Your pet can play epic games that will get it into true gamer mindset!";
            hapiness = 45; 
        }
    }
}