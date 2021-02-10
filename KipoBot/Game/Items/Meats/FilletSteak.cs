using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class FilletSteak : Item
    {
        public FilletSteak()
        {
            type = Type.Meat;
            price = 20;
            name = "Fillet Steak";
            description = "A slice of beef from back of cow or whatever";
            hunger = 20;
        }
    }
}