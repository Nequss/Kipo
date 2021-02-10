using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class SpinningToy : Item
    {
        public SpinningToy()
        {
            type = Type.Toy;
            price = 10;
            name = "Spinning Toy";
            description = "It spins round… and round… and round…";
            hapiness = 5;
        }
    }
}
