using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class Tripe : Item
    {
        public Tripe ()
        {
            type = Type.Meat;
            price = 25;
            name = "Tripe";
            description = "The stomach of a sheep or cow ";
            hunger = 15;
        }
    }
}
