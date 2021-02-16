using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Guitar : Item
    {
        public Guitar()
        {
            type = Type.Tool;
            price = 200;
            name = "Guitar";
            description = "Let your pet learn how to play guitar and most importantly enjoy doing so";
        }
    }
}
