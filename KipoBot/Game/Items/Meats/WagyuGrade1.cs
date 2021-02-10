using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class WagyuGrade1 : Item
    {
        public WagyuGrade1()
        {
            type = Type.Meat;
            price = 30;
            name = "Wagyu Grade 1";
            description = "Meat from japanese kettle, really amazing taste";
            hunger = 20;
        }
    }
}