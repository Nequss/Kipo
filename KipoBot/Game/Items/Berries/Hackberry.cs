using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Berries
{
    [Serializable]
    class Hackberry : Item
    {
        public Hackberry()
        {
            type = Type.Berry;
            price = 22;
            name = "Hackberry";
            description = "It grows in your pc";
            hunger = 12;
        }
    }
}