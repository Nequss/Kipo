using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Treats
{
    [Serializable]
    class Chocolate : Item
    {
        public Chocolate()
        {
            type = Type.Treat;
            price = 10;
            name = "Chocolate";
            describtion = "Chocolate! Me wants much chocolate!";
            hapiness = 5;
        }
    }
}