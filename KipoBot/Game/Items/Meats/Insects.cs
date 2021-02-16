using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class Insects : Item
    {
        public Insects()
        {
            type = Type.Meat;
            price = 15;
            name = "Insects";
            description = "Who the hell likes them? Well whatever! Your pets must have a specific type of taste to eat these ";
            hunger = 5;
        }
    }
}