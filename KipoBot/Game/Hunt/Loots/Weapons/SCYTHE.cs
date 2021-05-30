using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Hunt.Loots
{
    [Serializable]
    class SCYTHE : Item
    {
        public SCYTHE()
        {
            type = Type.Weapon;
            price = 600;
            name = "SCYTHE";
            description = "Let your pet become grim reaper!!";
            damage = 5;
        }
    }
}
