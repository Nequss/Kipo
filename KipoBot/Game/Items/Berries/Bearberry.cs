using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Berries
{
    [Serializable]
    class Bearberry : Item
    {
        public Bearberry()
        {
            type = Type.Berry;
            price = 28;
            name = "Bearberry";
            description = "It’s a bear but berry? o.o";
            hunger = 18;
        }
    }
}