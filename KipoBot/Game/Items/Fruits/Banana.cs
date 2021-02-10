using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Banana : Item
    {
        public Banana()
        {
            type = Type.Fruit;
            price = 10;
            name = "Banana";
            describtion = "Yellow long fruit that is great both in taste and benefits";
            hunger = 5;
        }
    }
}