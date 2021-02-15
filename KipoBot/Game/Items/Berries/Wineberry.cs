using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Berries
{
    [Serializable]
    class Wineberry : Item
    {
        public Wineberry()
        {
            type = Type.Berry;
            price = 25;
            name = "Wineberry";
            description = "Tastes like raspebries but more meh but pets like it";
            hunger = 18;
        }
    }
}