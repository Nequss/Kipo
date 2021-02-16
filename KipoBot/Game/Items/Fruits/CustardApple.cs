using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class CustardApple :Item
    {
        public CustardApple ()
        {
            type = Type.Fruit;
            price = 20;
            name = "CustardApple";
            description = "Apple but even with more sugar than before it looks like it has scales owo ";
            hunger = 12;
        }
    }
}
