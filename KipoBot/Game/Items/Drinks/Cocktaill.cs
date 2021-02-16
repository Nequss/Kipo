using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class Cocktail : Item
    {
        public Cocktail()
        {
            type = Type.Drink;
            price = 30;
            name = "Cocktail";
            description = "Only for adults I hope :)  ";
            thirst = 20;
           
        }
    }
}