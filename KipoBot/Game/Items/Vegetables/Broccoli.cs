using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class Broccoli : Item
    {
        public Broccoli()
        {
            type = Type.Vegetable;
            price = 20;
            name = "Broccoli";
            description = "Something what most people and pets hate but trust me this is good as hell";
            hunger = 30;
        }
    }
}