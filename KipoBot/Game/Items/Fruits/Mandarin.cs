using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Mandarin : Item
    {
        public Mandarin()
        {
            type = Type.Fruit;
            price = 15;
            name = "Mandarin";
            description = "Not a language but fruit best for christmas season";
            hunger = 5;
        }
    }
}