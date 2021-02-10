using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Treats
{
    [Serializable]
    class CottonCandy : Item
    {
        public CottonCandy()
        {
            type = Type.Treat;
            price = 10;
            name = "Cotton candy";
            describtion = "Mostly found in festivals, circus and amusement parks - high sugar treat";
            hapiness = 5;
        }
    }
}