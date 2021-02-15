using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class HarryFlopper : Item
    {
        public HarryFlopper()
        {
            type = Type.Toy;
            price = 50;
            name = "Harry Flopper";
            description = "Story of how floppa entered a magic school and defeated most evil being of all";
            hapiness = 20;
            energy = 5;
        }
    }
}
