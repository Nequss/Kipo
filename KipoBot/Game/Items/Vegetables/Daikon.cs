using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class Daikon : Item
    {
        public Daikon ()
        {
            type = Type.Vegetable;
            price = 50;
            name = "Daikon";
            description = "White radish, Japanese radish… just basically radish but whith a bit of a different taste";
            hunger = 40;
        }
    }
}