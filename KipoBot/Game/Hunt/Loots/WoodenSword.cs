using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class WoodenSword : Item
    {
        public WoodenSword()
        {
            type = Type.Weapons;
            price = 300;
            name = "Wooden sword";
            description = "Sword made out of wood";
        }
    }
}
