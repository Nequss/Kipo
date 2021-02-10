using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Guitar : Item
    {
        public Guitar()
        {
            type = Type.Toy;
            price = 200;
            name = "Guitar";
            describtion = "Let your pet learn how to play guitar and most importantly enjoy doing so";
            hapiness = 60;
        }
    }
}
