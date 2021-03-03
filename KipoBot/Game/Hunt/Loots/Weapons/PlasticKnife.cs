using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Hunt.Loots
{
    [Serializable]
    class PlasticKnife : Item
    {
        public PlasticKnife()
        {
            type = Type.Weapon;
            price = 200;
            name = "Plastic knife";
            description = "Tiny cheap knife";
            damage = 1;
        }
    }
}
