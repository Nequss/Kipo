using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class TicTacToe : Item
    {
        public TicTacToe()
        {
            type = Type.Toy;
            price = 10;
            name = "TicTacToe";
            description = "O AND X";
            hapiness = 5;
        }
    }
}
