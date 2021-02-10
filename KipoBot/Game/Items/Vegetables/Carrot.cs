using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class Carrot : Item
    {
        public Carrot()
        {
            type = Type.Vegetable;
            price = 10;
            name = "Carrot";
            describtion = "Orange vegetable, elders say its good for your eyes and skin so chew them all";
            hunger = 5;
        }
    }
}