using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class Mushrooms : Item
    {
        public Mushrooms()
        {
            type = Type.Vegetable;
            price = 15;
            name = "Mushrooms";
            description = "Found in forests, they are fleshy and weird shaped ";
            hunger = 5;
        }
    }
}