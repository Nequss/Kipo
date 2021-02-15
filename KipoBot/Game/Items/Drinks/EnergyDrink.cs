using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class EnergyDrink : Item
    {
        public EnergyDrink()
        {
            type = Type.Drink;
            price = 60;
            name = "Energy drink";
            description = "Gibs energy tho too much will bring you hell  ";
            thirst = 10;
            energy = 20;
        }
    }
}