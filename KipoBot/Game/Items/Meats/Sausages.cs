using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class Sausage : Item
    {
        public Sausage()
        {
            type = Type.Meat;
            price = 15;
            name = "Sausage";
            description = "Sausage is always best";
            hunger = 5;
        }
    }
}
