using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class Water : Item
    {
        public Water()
        {
            type = Type.Drink;
            price = 15;
            name = "Water";
            description = "NORMAL WATER NOTHING WRONG HERE";
            thirst = 5;
        }
    }
}
