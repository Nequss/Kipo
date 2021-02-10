using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Picture : Item
    {
        public Picture()
        {
            type = Type.Toy;
            price = 10;
            name = "Picture";
            describtion = "Picture to hang on your wall for pets and look at it";
            hapiness = 5;
        }
    }
}