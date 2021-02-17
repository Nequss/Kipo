using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class OneNineEightFour : Item
    {
        public OneNineEightFour()
        {
            type = Type.Toy;
            price = 50;
            name = "1984";
            description = "Utopian word just let your pet read it they wont regret it ";
            hapiness = 20;
            energy = 5;
        }
    }
}
