using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class BerryJuice : Item
    {
        public BerryJuice()
        {
            type = Type.Drink;
            price = 25;
            name = "BerryJuice";
            description = "Just some berries that were combined to bring you best taste  ";
            thirst = 15;
        }
    }
}