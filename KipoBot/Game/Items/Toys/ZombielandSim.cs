using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class ZombielandSim : Item
    {
        public ZombielandSim()
        {
            type = Type.Toy;
            price = 35;
            name = "Run from evil mastermind zombies that sing ";
            description = "O AND X";
            hapiness = 20;
        }
    }
}
