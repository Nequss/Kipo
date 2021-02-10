using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Peach : Item
    {
        public Peach()
        {
            type = Type.Fruit;
            price = 30;
            name = "Peach";
            description = "Tastes sweet and it's just good overall";
            hunger = 20;
        }
    }
}