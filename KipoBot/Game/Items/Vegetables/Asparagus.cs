using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class Asparagus : Item
    {
        public Asparagus ()
        {
            type = Type.Vegetable;
            price = 25;
            name = "Asparagus";
            description = "Young shoots of a cultivated lily plant.";
            hunger = 15;
        }
    }
}