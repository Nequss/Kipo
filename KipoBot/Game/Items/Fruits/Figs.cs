using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Figs : Item
    {
        public Figs()
        {
            type = Type.Fruit;
            price = 30;
            name = "Figs";
            description = "Soft and smell sweet, one of the best sources of nutrition ";
            hunger = 20;
        }
    }
}
