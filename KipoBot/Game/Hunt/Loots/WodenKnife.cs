using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class WoodenKnife : Item
    {
        public WoodenKnife()
        {
            type = Type.Weapons;
            price = 300;
            name = "Wooden knife";
            description = "Used a lot on old time... probably";
        }
    }
}
