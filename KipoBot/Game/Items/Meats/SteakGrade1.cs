using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class SteakGrade1 : Item
    {
        public SteakGrade1()
        {
            type = Type.Meat;
            price = 30;
            name = "Steak Grade 1";
            describtion = "Normal steak you can buy for cheap price";
            hunger = 25;
        }
    }
}
