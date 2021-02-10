using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Drums : Item
    {
        public Drums()
        {
            type = Type.Toy;
            price = 200;
            name = "Drums";
            describtion = "Boom Dum-ba-badump, let's play with some boom-ba-drooms!";
            hapiness = 60;
        }
    }
}