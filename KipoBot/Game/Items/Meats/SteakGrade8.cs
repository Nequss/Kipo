using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class SteakGrade8 : Item
    {
        public SteakGrade8()
        {
            type = Type.Meat;
            price = 180;
            name = "Steak Grade 8";
            description = "What the hell.. Why is it so good  ";
            hunger = 85;
            hapiness = 10;
        }
    }
}
