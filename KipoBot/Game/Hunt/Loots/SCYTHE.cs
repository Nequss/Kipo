using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class SCYTHE : Item
    {
        public SCYTHE()
        {
            type = Type.Weapons;
            price = 600;
            name = "SCYTHE";
            description = "Let your pet become grim reaper!!";
        }
    }
}
