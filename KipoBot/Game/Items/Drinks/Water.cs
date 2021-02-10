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
            price = 10;
            name = "Water";
            describtion = "NORMAL WATER NOTHING WRONG HERE";
            thirst = 5;
        }
    }
}
