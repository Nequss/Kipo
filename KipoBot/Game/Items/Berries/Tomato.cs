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
            description = "Yes, it’s a berry, bet you didn't know that :3";
            hunger = 5;
        }
    }
}