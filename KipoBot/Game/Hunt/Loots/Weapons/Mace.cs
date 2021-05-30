﻿using KipoBot.Game.Base;
using System;
namespace KipoBot.Game.Hunt.Loots
{
    [Serializable]
    class Mace : Item
    {
        public Mace()
        {
            type = Type.Weapon;
            price = 500;
            name = "Mace";
            description = "Spiky boyyyyy";
            damage = 4;
        }
    }
}
