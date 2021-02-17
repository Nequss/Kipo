using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Jackfruits : Item
    {
        public Jackfruits()
        {
            type = Type.Fruit;
            price = 20;
            name = "Jackfruits";
            description = "fruit to get jacked from";
            hunger = 10;
        }
    }
}
