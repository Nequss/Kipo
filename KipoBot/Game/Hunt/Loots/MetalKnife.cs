using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class MetalKnife : Item
    {
        public MetalKnife()
        {
            type = Type.Weapons;
            price = 300;
            name = "Metal Knife";
            description = "Normal kitchen knife";
        }
    }
}
