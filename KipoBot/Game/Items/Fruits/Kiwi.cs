using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Kiwi : Item
    {
        public Kiwi()
        {
            type = Type.Fruit;
            price = 10;
            name = "Kiwi";
            describtion = "High in Vitamin C and dietary fiber - also provides a variety of health benefits";
            hunger = 5;
        }
    }
}