using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Pear : Item
    {
        public Pear()
        {
            type = Type.Fruit;
            price = 25;
            name = "Pear";
            description = "Highly nutritious and juicy fruits that are weird shaped but amazing at taste ";
            hunger = 15;
        }
    }
}
