using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Ball : Item
    {
        public Ball()
        {
            type = Type.Toy;
            price = 10;
            name = "Ball";
            describtion = "Most typical playing ball";
            hapiness = 5;
        }
    }
}
