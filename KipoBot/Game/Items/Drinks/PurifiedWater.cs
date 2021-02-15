using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class PurifiedWater : Item
    {
        public PurifiedWater()
        {
            type = Type.Drink;
            price = 18;
            name = "Purified water";
            description = "PURE WATER NO CHEMICALS OR ANYTHING  ";
            thirst = 10;
        }
    }
}