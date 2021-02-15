using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class GamerJuice : Item
    {
        public GamerJuice()
        {
            type = Type.Drink;
            price = 1000;
            name = "Gamer juice";
            description = "drink from gamer water is op ";
            thirst = 70;
            hapiness = 70;
            energy = 100;
        }
    }
}