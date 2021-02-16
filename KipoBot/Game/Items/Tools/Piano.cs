using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Piano : Item
    {
        public Piano()
        {
            type = Type.Tool;
            price = 200;
            name = "Piano";
            description = "Let your pets learn notes, play songs, become pro pianist, join epic band and earn tons of money… ah what a nice dream";
        }
    }
}
