using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Hunt.Loots
{
    [Serializable]
    class NerfGun : Item
    {
        public NerfGun()
        {
            type = Type.Weapon;
            price = 200;
            name = "Nerf gun";
            description = "Time to get nerfed";
            damage = 1;
        }
    }
}
