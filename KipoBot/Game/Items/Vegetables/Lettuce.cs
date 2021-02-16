using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class Lettuce : Item
    {
        public Lettuce()
        {
            type = Type.Vegetable;
            price = 25;
            name = "Lettuce";
            description = "True lettuce uwu";
            hunger = 15;
        }
    }
}