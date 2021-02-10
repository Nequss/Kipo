using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Lego : Item
    {
        public Lego()
        {
            type = Type.Toy;
            price = 50;
            name = "Lego";
            describtion = "Let your pets become architects of big worlds in this bricky world";
            hapiness = 30;
        }
    }
}