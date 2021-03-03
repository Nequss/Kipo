using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Hunt.Loots
{
    [Serializable]
    class RealGun : Item
    {
        public RealGun()
        {
            type = Type.Weapons;
            price = 300;
            name = "Real gun";
            description = "Yeah its defiently real and dangerous yes sure sure";
            damage = 2;
        }
    }
}
