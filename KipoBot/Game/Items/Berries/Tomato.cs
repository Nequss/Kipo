using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Berries
{
    [Serializable]
    class Tomato : Item
    {
        public Tomato()
        {
            type = Type.Berry;
            price = 10;
            name = "Tomato";
            description = "Yes, it’s a berry. It's evil in my opinion but someone else will say they are good as hell so to each their own";
            hunger = 5;
        }
    }
}