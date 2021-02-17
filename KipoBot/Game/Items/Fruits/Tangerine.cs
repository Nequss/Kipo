using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Tangerine : Item
    {
        public Tangerine ()
        {
            type = Type.Fruit;
            price = 30;
            name = "Tangerine";
            description = "Mandarin but with different name ";
            hunger = 20;
        }
    }
}
