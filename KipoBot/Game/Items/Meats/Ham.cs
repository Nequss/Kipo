using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class Ham : Item
    {
        public Ham()
        {
            type = Type.Meat;
            price = 15;
            name = "Ham";
            description = "Cured meat from a pig's upper leg";
            hunger = 10;
        }
    }
}