using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Figurines : Item
    {
        public Figurines()
        {
            type = Type.Toy;
            price = 30;
            name = "PC";
            describtion = "Some action figures to play with and make up amazing stories of heroes, villains or whatever your pet imagines";
            hapiness = 20;
        }
    }
}