using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class BoardGame : Item
    {
        public BoardGame()
        {
            type = Type.Toy;
            price = 15;
            name = "Board Game";
            describtion = @"Let your pet enjoy to play some board games like they are the smartest in the world, which we all know they are :3";
            hapiness = 50;
        }
    }
}