using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Pokermon : Item
    {
        public Pokermon()
        {
            type = Type.Toy;
            price = 30;
            name = "Pokermon";
            description = "Play a game where you go and catch cute and scary pokerman";
            hapiness = 20;
        }
    }
}