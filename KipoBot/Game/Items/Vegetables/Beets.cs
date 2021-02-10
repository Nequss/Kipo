using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class Beets : Item
    {
        public Beets()
        {
            type = Type.Vegetable;
            price = 15;
            name = "Beets";
            description = "Root type veggy, packed with essential vitamins, minerals and plant compounds, some of which have medicinal properties.";
            hunger = 10;
        }
    }
}