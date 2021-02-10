using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class HugeBall : Item
    {
        public HugeBall()
        {
            type = Type.Toy;
            price = 50;
            name = "Huge Ball";
            description = "A big ball for your pets to play with roll on it or use it as a weapon to throw at you when they get mad ";
            hapiness = 30;
        }
    }
}
