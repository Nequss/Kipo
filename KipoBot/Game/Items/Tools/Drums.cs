using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Tools
{
    [Serializable]
    class Drums : Item
    {
        public Drums()
        {
            type = Type.Tool;
            price = 200;
            name = "Drums";
            description = "Boom Dum-ba-badump, let's play with some boom-ba-drooms!";
            hapiness = 60;
        }
    }
}