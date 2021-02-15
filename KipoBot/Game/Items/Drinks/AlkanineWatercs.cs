using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class AlkanineWater : Item
    {
        public AlkanineWater()
        {
            type = Type.Drink;
            price = 25;
            name = "AlkanineWater";
            description = " High ph level can't drink everyday or you might get sick";
            thirst = 15;
        }
    }
}