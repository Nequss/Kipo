using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class MetalSword : Item
    {
        public MetalSword()
        {
            type = Type.Weapons;
            price = 200;
            name = "Metal sword";
            description = "Finally a decent sword";
        }
    }
}
