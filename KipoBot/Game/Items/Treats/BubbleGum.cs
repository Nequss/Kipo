using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Treats
{
    [Serializable]
    class BubbleGum : Item
    {
        public BubbleGum()
        {
            type = Type.Treat;
            price = 10;
            name = "Bubble gum";
            description = "You can chew it and chew it for hours till it looses its taste";
            hapiness = 5;
        }
    }
}