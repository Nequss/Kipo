using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class Milk : Item
    {
        public Milk()
        {
            type = Type.Drink;
            price = 20;
            name = "Milk";
            describtion = "Milked straight from a cow, it's deliciuos and good for babies";
            thirst = 15;
        }
    }
}