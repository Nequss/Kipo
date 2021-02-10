using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class Arizona : Item
    {
        public Arizona()
        {
            type = Type.Drink;
            price = 20;
            name = "Arizona";
            describtion = " No. 1 Selling Iced Tea Brand";
            thirst = 15;
        }
    }
}