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
            price = 15;
            name = "Bearberry";
            describtion = "It’s a bear but berry? o.o";
            hunger = 10;
        }
    }
}