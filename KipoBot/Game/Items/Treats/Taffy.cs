using KipoBot.Game.Base;
using System;

namespace KipoBot.Game.Items.Treats
{
    [Serializable]
    class Taffy : Item
    {
        public Taffy()
        {
            type = Type.Treat;
            price = 25;
            name = "Taffy";
            description = "Chewwy ropes of gum that are tasty as heck";
            hapiness = 15;
        }
    }
}