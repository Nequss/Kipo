using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Berries
{
    [Serializable]
    class Youngberry : Item
    {
        public Youngberry()
        {
            type = Type.Berry;
            price = 18;
            name = "Youngberry";
            description = "almost same as blackberry but YOUNG";
            hunger = 10;
        }
    }
}