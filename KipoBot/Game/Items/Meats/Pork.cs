using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class Pork : Item
    {
        public Pork()
        {
            type = Type.Meat;
            price = 20;
            name = "Pork";
            description = "Pigs meat";
            hunger = 10;
        }
    }
}
