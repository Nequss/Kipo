using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Book : Item
    {
        public Book()
        {
            type = Type.Toy;
            price = 100;
            name = "Book";
            describtion = "Perfect pass time for your pet";
            hapiness = 20;
            energy = 20;
        }
    }
}
