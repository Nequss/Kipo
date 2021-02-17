using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class TBoneSteak : Item
    {
        public TBoneSteak ()
        {
            type = Type.Meat;
            price = 35;
            name = "TBoneSteak";
            description = "Really amazing steak rich in taste uwu";
            hunger = 25;
        }
    }
}
