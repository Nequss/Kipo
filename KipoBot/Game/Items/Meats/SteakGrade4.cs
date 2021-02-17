using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class SteakGrade4 : Item
    {
        public SteakGrade4()
        {
            type = Type.Meat;
            price = 70;
            name = "Steak Grade 4";
            description = "Well even better than grade 3 and the lower ones  ";
            hunger = 45;
        }
    }
}
