using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Treats
{
    [Serializable]
    class Gummy : Item
    {
        public Gummy()
        {
            type = Type.Treat;
            price = 20;
            name = "Gummy";
            description = "Tender and plump, these delicious gummies are sure to surprise and delight with every bite!";
            hapiness = 10;
        }
    }
}