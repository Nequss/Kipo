using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Plushie : Item
    {
        public Plushie()
        {
            type = Type.Toy;
            price = 20;
            name = "Plushie";
            description = "Little plushie is like a the best friend to any pet";
            hapiness = 10;
        }
    }
}
