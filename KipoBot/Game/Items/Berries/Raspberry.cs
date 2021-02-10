using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Berries
{
    [Serializable]
    class Raspberry : Item
    {
        public Raspberry()
        {
            type = Type.Berry;
            price = 10;
            name = "Raspberry";
            description = "Low in calories but high in fiber, vitamins, minerals and antioxidants";
            hunger = 5;
        }
    }
}