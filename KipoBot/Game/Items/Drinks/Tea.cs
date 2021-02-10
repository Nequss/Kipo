using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class Tea : Item
    {
        public Tea()
        {
            type = Type.Drink;
            price = 20;
            name = "Tea";
            describtion = "Any tea you want, leave it to your imagination";
            thirst = 15;
        }
    }
}