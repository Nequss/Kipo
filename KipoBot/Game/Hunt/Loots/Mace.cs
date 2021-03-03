using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class Mace : Item
    {
        public Mace()
        {
            type = Type.Weapons;
            price = 500;
            name = "Mace";
            description = "Spiky boyyyyy";
        }
    }
}
