using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class Coffee : Item
    {
        public Coffee()
        {
            type = Type.Drink;
            price = 30;
            name = "Coffee";
            description = "Coffee is good for your pet's mind and soul to get some energy and motivation";
            thirst = 10;
            energy = 5;
        }
    }
}