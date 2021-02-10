using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Bricks : Item
    {
        public Bricks()
        {
            type = Type.Toy;
            price = 25;
            name = "Bricks";
            describtion = "Not as good as lego but should work fine to build some destcuctable structures";
            hapiness = 15;
        }
    }
}