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
            price = 20;
            name = "Flavoured Water";
            description = "Water but with TASTE";
            thirst = 12;
        }
    }
}