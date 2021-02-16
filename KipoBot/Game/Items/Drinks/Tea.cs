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
            price = 22;
            name = "Tea";
            description = "Any tea you want, leave it to your imagination";
            thirst = 12;
        }
    }
}