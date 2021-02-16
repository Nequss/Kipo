using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class SteakGrade3 : Item
    {
        public SteakGrade3()
        {
            type = Type.Meat;
            price = 50;
            name = "Steak Grade 3";
            description = "A little bit more expensive but is tad bit better ";
            hunger = 35;
        }
    }
}
