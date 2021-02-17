using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class AppleJuice : Item
    {
        public AppleJuice()
        {
            type = Type.Drink;
            price = 25;
            name = "Apple juice";
            description = "Why eat apples when you can drink them";
            thirst = 15;
        }
    }
}