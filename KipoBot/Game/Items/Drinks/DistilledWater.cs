using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class DistilledWater : Item
    {
        public DistilledWater()
        {
            type = Type.Drink;
            price = 22;
            name = "Distilled water";
            description = "Water that is blant and not that good tho works ";
            thirst = 12;
        }
    }
}