using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class AttackOnGiants: Item
    {
        public AttackOnGiants()
        {
            type = Type.Toy;
            price = 35;
            name = "Attack on giants";
            description = " ";
            hapiness = 22;
        }
    }
}
