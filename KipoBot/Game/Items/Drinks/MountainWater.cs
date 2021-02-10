using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class MountainWater : Item
    {
        public MountainWater()
        {
            type = Type.Drink;
            price = 10;
            name = "Mountain Water";
            describtion = "Water from mountains legends says a lot of things were sacrificed for this ";
            thirst = 5;
        }
    }
}