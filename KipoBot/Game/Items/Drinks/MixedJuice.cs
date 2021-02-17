using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class MixedJuice : Item
    {
        public MixedJuice()
        {
            type = Type.Drink;
            price = 25;
            name = "MixedJuice";
            description = "Juice made from a lot of fruits and berries combined ";
            thirst = 15;
        }
    }
}