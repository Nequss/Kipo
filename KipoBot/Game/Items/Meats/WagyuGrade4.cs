using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class WagyuGrade4 : Item
    {
        public WagyuGrade4()
        {
            type = Type.Meat;
            price = 250;
            name = "Wagyu Grade 4";
            description = "One of the best qualities of wagyu can't say more than that but you got to try it";
            hunger = 100;
            hapiness = 15;
        }
    }
}