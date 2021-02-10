using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Watermelon : Item
    {
        public Watermelon()
        {
            type = Type.Fruit;
            price = 45;
            name = "Watermelon";
            describtion = "Best summer food EVER";
            hunger = 35;
        }
    }
}