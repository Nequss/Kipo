using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class CallOfGuns : Item
    {
        public CallOfGuns()
        {
            type = Type.Toy;
            price = 50;
            name = "Call of guns";
            description = "let pet learn about historical wars through playing a game ";
            hapiness = 35;
        }
    }
}