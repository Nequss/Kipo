using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class TheWildAssSkin : Item
    {
        public TheWildAssSkin()
        {
            type = Type.Toy;
            price = 50;
            name = "The wild ass skin";
            description = "Book about a guy whose wishes cost him way too much  ";
            hapiness = 20;
            energy = 5;
        }
    }
}
