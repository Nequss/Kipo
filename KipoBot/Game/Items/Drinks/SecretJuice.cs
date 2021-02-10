using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    class SecretJuice : Item
    {
        public SecretJuice()
        {
            type = Type.Drink;
            price = 100;
            name = "Secret Juice";
            description = "(7u7)";
            thirst = 30;
        }
    }
}