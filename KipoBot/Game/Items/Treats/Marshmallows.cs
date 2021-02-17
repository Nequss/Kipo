using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Treats
{
    [Serializable]
    class Marshmallows : Item
    {
        public Marshmallows()
        {
            type = Type.Treat;
            price = 20;
            name = "Marshmallows";
            description = "Soft and sticky, i kinda want to cuddle them";
            hapiness = 10;
        }
    }
}