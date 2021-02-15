using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class Corn : Item
    {
        public Corn()
        {
            type = Type.Vegetable;
            price = 15;
            name = "Corn";
            description = "one of the best things in life, you can make so much stuff form them ";
            hunger = 10;
        }
    }
}