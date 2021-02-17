using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class Turkey : Item
    {
        public Turkey ()
        {
            type = Type.Meat;
            price = 15;
            name = "Turkey";
            description = "Turkey is turkey man";
            hunger = 5;
        }
    }
}
