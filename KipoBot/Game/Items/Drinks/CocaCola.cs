using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class CocaCola : Item
    {
        public CocaCola()
        {
            type = Type.Drink;
            price = 25;
            name = "Coca-Cola";
            description = "We all know this drink right?  ";
            thirst = 15;
        }
    }
}