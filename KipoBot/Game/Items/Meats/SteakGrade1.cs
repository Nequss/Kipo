using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class SteakGrade1 : Item
    {
        public SteakGrade1()
        {
            type = Type.Meat;
            price = 35;
            name = "Steak Grade 1";
            description = "Normal steak you can buy for cheap price";
            hunger = 25;
        }
    }
}
