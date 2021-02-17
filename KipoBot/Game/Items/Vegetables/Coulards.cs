using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class Coulards : Item
    {
        public Coulards ()
        {
            type = Type.Vegetable;
            price = 35;
            name = "Coulards";
            description = "Some weird lettuce ";
            hunger = 25;
        }
    }
}