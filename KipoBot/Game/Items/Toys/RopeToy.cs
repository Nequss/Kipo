using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class RopeToy : Item
    {
        public RopeToy()
        {
            type = Type.Toy;
            price = 25;
            name = "Rope Toy";
            description = "Little thingy on a ball for your pet to try catch or stare for hours";
            hapiness = 15;
        }
    }
}
