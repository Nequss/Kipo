using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Guava :Item
    {
        public Guava ()
        {
            type = Type.Fruit;
            price = 55;
            name = "Guava";
            description = "Firm, green or yellow common tropical fruit";
            hunger = 40;
        }
    }
}
