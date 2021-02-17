using System;
using KipoBot.Game.Base;


namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class Potato : Item
    {
        public Potato()
        {
            type = Type.Vegetable;
            price = 15;
            name = "Potato";
            description = "Most favorite food of people, it's amazing everyone knows it - nothing to say there";
            hunger = 5;
        }
    }
}
