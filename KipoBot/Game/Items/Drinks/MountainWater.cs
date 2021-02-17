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
            price = 15;
            name = "Mountain Water";
            description = "Water from mountains legends says a lot of things were sacrificed for this ";
            thirst = 5;
        }
    }
}