using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Berries
{
    [Serializable]
    class Snowberry : Item
    {
        public Snowberry()
        {
            type = Type.Berry;
            price = 20;
            name = "Snowberry";
            description = "Fav food of birds, white and looks like snow";
            hunger = 12;
        }
    }
}