using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class Katana : Item
    {
        public Katana()
        {
            type = Type.Weapons;
            price = 400;
            name = "Katana";
            description = "Very long japanese sword";
        }
    }
}
