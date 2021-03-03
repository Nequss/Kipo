using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Hunt.Loots
{
    [Serializable]
    class MetalSword : Item
    {
        public MetalSword()
        {
            type = Type.Weapons;
            price = 400;
            name = "Metal sword";
            description = "Finally a decent sword";
            damage 3;
        }
    }
}
