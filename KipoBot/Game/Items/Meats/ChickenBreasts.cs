using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class ChickenBreasts : Item
    {
        public ChickenBreasts()
        {
            type = Type.Meat;
            price = 10;
            name = "Chicken Breasts";
            describtion = "Chicken's boobs";
            hunger = 5;
        }
    }
}