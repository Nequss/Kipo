using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Treats
{
    [Serializable]
    class Candy : Item
    {
        public Candy()
        {
            type = Type.Treat;
            price = 15;
            name = "Candy";
            description = "The most typical candy you can think of";
            hapiness = 5;
        }
    }
}