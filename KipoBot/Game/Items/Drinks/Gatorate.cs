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
            price = 45;
            name = "BerryJuice";
            description = "Like coca-cola but for sports   ";
            thirst = 15;
            energy = 10;
        }
    }
}