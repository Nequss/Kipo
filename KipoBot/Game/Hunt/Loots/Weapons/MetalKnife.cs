using KipoBot.Game.Base;
using System;

namespace KipoBot.Game.Hunt.Loots
{
    [Serializable]
    class MetalKnife : Item
    {
        public MetalKnife()
        {
            type = Type.Weapon;
            price = 400;
            name = "Metal Knife";
            description = "Normal kitchen knife";
            damage = 3;
        }
    }
}
