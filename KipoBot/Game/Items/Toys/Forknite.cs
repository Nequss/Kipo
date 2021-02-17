using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Forknite : Item
    {
        public Forknite()
        {
            type = Type.Toy;
            price = 15;
            name = "Forknite";
            description = "Run around big map full of other pets and enjoy shooting each other  ";
            hapiness = 5;
        }
    }
}
