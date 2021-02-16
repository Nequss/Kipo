using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class MineralWater : Item
    {
        public MineralWater()
        {
            type = Type.Drink;
            price = 15;
            name = "Mineral Water";
            description = "Water with minerals is good for you to drink during hot days";
            thirst = 5;
        }
    }
}