using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class Beans : Item
    {
        public Beans()
        {
            type = Type.Vegetable;
            price = 20;
            name = "Beans";
            description = "Beans… beans… beans… BEANS!!!";
            hunger = 15;
        }
    }
}