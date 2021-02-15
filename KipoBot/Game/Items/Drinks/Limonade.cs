using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class Limonade : Item
    {
        public Limonade()
        {
            type = Type.Drink;
            price = 10;
            name = "Limonade";
            description = "Some random limonade found at shop even I don’t know what it is   ";
            thirst = 5;
        }
    }
}