using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class WagyuGradeA5 : Item
    {
        public WagyuGradeA5()
        {
            type = Type.Meat;
            price = 400;
            name = "Wagyu Grade A5";
            description = "Highest quality meat, it's super good and tasty, feels like it melts on your tongue ahhhh";
            hunger = 150;
            hapiness = 20;
            energy = 10;
        }
    }
}