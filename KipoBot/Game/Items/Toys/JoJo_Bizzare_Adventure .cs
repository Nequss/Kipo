using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class JoJo_Bizzare_Adventure : Item
    {
        public JoJo_Bizzare_Adventure()
        {
            type = Type.Toy;
            price = 50;
            name = "JoJo Bizzare Adventure";
            description = "Most epiccc manga of all time sure to make pet feel like a chad ";
            hapiness = 20;
            energy = 5;
        }
    }
}
