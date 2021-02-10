using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class FlavouredWater : Item
    {
        public FlavouredWater()
        {
            type = Type.Drink;
            price = 15;
            name = "Flavoured Water";
            describtion = "Water but with TASTE";
            thirst = 10;
        }
    }
}