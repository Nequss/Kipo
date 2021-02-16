using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class RichWater : Item
    {
        public RichWater()
        {
            type = Type.Drink;
            price = 500;
            name = "Rich water";
            description = "water not for peasants  ";
            thirst = 85;
            hapiness = 55;
            energy = 10;
        }
    }
}