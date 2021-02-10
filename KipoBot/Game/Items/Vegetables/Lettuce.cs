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
            price = 20;
            name = "Lettuce";
            describtion = "True lettuce uwu";
            hunger = 15;
        }
    }
}