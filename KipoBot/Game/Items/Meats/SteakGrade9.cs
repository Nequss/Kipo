using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class SteakGrade9 : Item
    {
        public SteakGrade9()
        {
            type = Type.Meat;
            price = 290;
            name = "Steak Grade 9";
            description = "Highest quality steak, this is best quality thing right here, only rich people can eat it sadly  ";
            hunger = 100;
            hapiness = 15;
        }
    }
}
