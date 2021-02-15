using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class RomanMythology : Item
    {
        public RomanMythology()
        {
            type = Type.Toy;
            price = 50;
            name = "Roman Mythology";
            description = "Read about mythology from roman times   ";
            hapiness = 20;
            energy = 5;
        }
    }
}
