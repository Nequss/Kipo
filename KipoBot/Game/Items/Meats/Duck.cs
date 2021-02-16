using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class Duck : Item
    {
        public Duck()
        {
            type = Type.Meat;
            price = 20;
            name = "Duck";
            description = "Duck said quick, duck doenst say quick anymore ";
            hunger = 10;
        }
    }
}