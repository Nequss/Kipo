using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Diablo : Item
    {
        public Diablo()
        {
            type = Type.Toy;
            price = 25;
            name = "Diablo";
            description = "Epic monster hunting and running trough difficult dungeons ";
            hapiness = 12;
        }
    }
}
