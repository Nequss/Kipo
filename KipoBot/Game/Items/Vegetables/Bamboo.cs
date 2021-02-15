using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class Bamboo : Item
    {
        public Bamboo()
        {
            type = Type.Vegetable;
            price = 50;
            name = "Bamboo";
            description = "Best thing for pandas to eat";
            hunger = 15;
        }
    }
}