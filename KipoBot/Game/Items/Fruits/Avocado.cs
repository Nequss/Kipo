using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Avocado : Item
    {
        public Avocado()
        {
            type = Type.Fruit;
            price = 20;
            name = "Avocado";
            describtion = "Ripe and soft fruit that you can make so much good stuff from - eat it! it's incredible";
            hunger = 10;
        }
    }
}