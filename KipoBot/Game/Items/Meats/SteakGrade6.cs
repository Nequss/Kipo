using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class SteakGrade6 : Item
    {
        public SteakGrade6()
        {
            type = Type.Meat;
            price = 90;
            name = "Steak Grade 6";
            description = "Oh my, oh me, this is tastier than I even thought   ";
            hunger = 65;
        }
    }
}
