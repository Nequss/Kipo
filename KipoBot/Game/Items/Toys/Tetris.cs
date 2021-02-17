using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Tetris : Item
    {
        public Tetris()
        {
            type = Type.Toy;
            price = 15;
            name = "Tetris";
            description = "Match falling shapes with always increasing speed";
            hapiness = 5;
        }
    }
}
