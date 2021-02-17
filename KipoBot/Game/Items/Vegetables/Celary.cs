using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class Celary : Item
    {
        public Celary()
        {
            type = Type.Vegetable;
            price = 15;
            name = "Celary";
            description = "Rich in vitamins and minerals great thing to use as spices ";
            hunger = 5;
        }
    }
}