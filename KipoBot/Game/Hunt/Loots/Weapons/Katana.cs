using KipoBot.Game.Base;
using System;

namespace KipoBot.Game.Hunt.Loots
{
    [Serializable]
    class Katana : Item
    {
        public Katana()
        {
            type = Type.Weapon;
             name = "Katana";
            description = "Very long japanese sword";
            price = 400;
            damage = 3;
            

        }
    }
}
