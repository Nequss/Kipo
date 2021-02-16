using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Appricorn : Item
    {
        public Appricorn()
        {
            type = Type.Fruit;
            price = 20;
            name = "Appricorn";
            description = "Plump, fairly firm fruit with as much golden orange as possible, good source of pottasium";
            hunger = 12;
        }
    }
}
