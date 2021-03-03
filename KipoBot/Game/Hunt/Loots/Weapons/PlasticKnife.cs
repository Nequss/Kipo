using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Hunt.Loots
{
    [Serializable]
    class PlasticKnife : Item
    {
        public PlasticKnife()
        {
            type = Type.Weapons;
            price = 200;
            name = "Plastic knife";
            description = "Tiny cheap knife";
            damage = 1;
        }
    }
}
