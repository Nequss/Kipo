using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class RingSword : Item
    {
        public RingSword()
        {
            type = Type.Weapon;
            price = 300;
            name = "Ring sword";
            description = "Holly molly this circle is whole blades";
        }
    }
}
