using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Treats
{
    [Serializable]
    class IceCream : Item
    {
        public IceCream()
        {
            type = Type.Treat;
            price = 15;
            name = "Ice cream";
            description = "Tasty and good but be carefull! Kept warm might melt";
            hapiness = 10;
        }
    }
}