using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class Kale : Item
    {
        public Kale()
        {
            type = Type.Vegetable;
            price = 25;
            name = "Kale";
            description = "Another weird lettuce looking thing ";
            hunger = 15;
        }
    }
}