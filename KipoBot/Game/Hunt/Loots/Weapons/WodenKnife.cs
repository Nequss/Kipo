using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Hunt.Loots
{
    [Serializable]
    class WoodenKnife : Item
    {
        public WoodenKnife()
        {
            type = Type.Weapon;
            price = 300;
            name = "Wooden knife";
            description = "Used a lot on old time... probably";
            damage = 2;
        }
    }
}
