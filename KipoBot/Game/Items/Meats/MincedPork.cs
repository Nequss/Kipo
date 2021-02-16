using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class MincedPork : Item
    {
        public MincedPork()
        {
            type = Type.Meat;
            price = 15;
            name = "MincedPork";
            description = "Pork that was completely destroyed and made into small noodles  ";
            hunger = 5;
        }
    }
}