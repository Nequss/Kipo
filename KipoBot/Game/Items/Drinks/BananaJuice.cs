using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class BananaJuice : Item
    {
        public BananaJuice()
        {
            type = Type.Drink;
            price = 25;
            name = "BananaJuice";
            description = "Poor babana it got extracted into good tasting juice ";
            thirst = 15;
        }
    }
}