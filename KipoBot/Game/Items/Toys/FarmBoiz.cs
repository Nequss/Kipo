using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class FarmBoiz : Item
    {
        public FarmBoiz()
        {
            type = Type.Toy;
            price = 22;
            name = "FarmBoyz";
            description = "Game where pet farms and enjoy life in a chill coutryside";
            hapiness = 13;
        }
    }
}
