using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Berries
{
    [Serializable]
    class Timbleberry : Item
    {
        public Timbleberry()
        {
            type = Type.Berry;
            price = 20;
            name = "Timbleberry";
            description = "owo what's this?";
            hunger = 10;
        }
    }
}