using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Lyche : Item
    {
        public Lyche ()
        {
            type = Type.Fruit;
            price = 30;
            name = "Lyche";
            description = "Tropical fruit with a bumpy, red peel and white, taste like a mix of strawberry and watermelon";
            hunger = 20;
        }
    }
}
