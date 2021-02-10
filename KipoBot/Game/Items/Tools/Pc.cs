using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Pc : Item
    {
        public Pc()
        {
            type = Type.Tool;
            price = 400;
            name = "PC";
            describtion = "Gamus! We got them! Movies we got as well! And something more… ;)";
        }
    }
}