using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class ChickenBreasts : Item
    {
        public ChickenBreasts()
        {
            type = Type.Meat;
            price = 15;
            name = "Chicken Breasts";
            description = "Chicken's boobs";
            hunger = 5;
        }
    }
}