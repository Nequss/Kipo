using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class Gatorade : Item
    {
        public Gatorade()
        {
            type = Type.Drink;
            price = 65;
            name = "Gatorade";
            description = "Like coca-cola but for sports   ";
            thirst = 15;
            energy = 10;
        }
    }
}