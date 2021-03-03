using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class NerfGun : Item
    {
        public NerfGun()
        {
            type = Type.Weapons;
            price = 200;
            name = "Nerf gun";
            description = "Time to get nerfed";
        }
    }
}
