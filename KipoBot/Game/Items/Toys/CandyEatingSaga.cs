using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class CandyEatingSaga : Item
    {
        public CandyEatingSaga()
        {
            type = Type.Toy;
            price = 15;
            name = "Candy eating saga";
            description = "Let your pet catch, match candy falling from the skies ";
            hapiness = 5;
        }
    }
}
