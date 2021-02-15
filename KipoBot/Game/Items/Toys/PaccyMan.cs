using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class PaccyMan : Item
    {
        public PaccyMan()
        {
            type = Type.Toy;
            price = 10;
            name = "Paccy Man";
            description = "Yellow little thing runs around from ghosts eating white thingies  ";
            hapiness = 5;
        }
    }
}
