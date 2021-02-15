using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Happiness : Item
    {
        public Happiness()
        {
            type = Type.Toy;
            price = 50;
            name = "Happiness";
            description = "A realisting and chilling tale about vampires ";
            hapiness = 20;
            energy = 5;
        }
}
}
