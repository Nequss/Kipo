using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class Caulflower : Item
    {
        public Caulflower()
        {
            type = Type.Vegetable;
            price = 15;
            name = "Caulflower";
            description = "Broocoli but white";
            hunger = 5;
        }
    }
}