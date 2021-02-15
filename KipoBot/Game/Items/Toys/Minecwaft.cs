using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Minecwaft : Item
    {
        public Minecwaft()
        {
            type = Type.Toy;
            price = 25;
            name = "Minecwaft";
            description = "Blocky word to build in and enjoy ";
            hapiness = 12;
        }
    }
}
