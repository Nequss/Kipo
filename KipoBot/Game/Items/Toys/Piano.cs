using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Piano : Item
    {
        public Piano()
        {
            type = Type.Toy;
            price = 200;
            name = "Piano";
            describtion = "Let your pets earn notes, play songs, become pro pianist, join epic band and earn tons of money… ah what a nice dream";
            hapiness = 60;
        }
    }
}
