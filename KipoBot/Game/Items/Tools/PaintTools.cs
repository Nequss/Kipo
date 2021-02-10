using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Tools
{
    [Serializable]
    class PaintTools : Item
    {
        public PaintTools()
        {
            type = Type.Tool;
            price = 120;
            name = "Paint tools";
            describtion = "Your pet can draw some pretty pictures with this";
        }
    }
}