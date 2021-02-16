using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class Mutton : Item
    {
        public Mutton ()
        {
            type = Type.Meat;
            price = 25;
            name = "Mutton";
            description = "Meat from lamb ";
            hunger = 15;
        }
    }
}