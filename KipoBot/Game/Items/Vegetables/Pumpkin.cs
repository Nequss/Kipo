using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class Pumpkin : Item
    {
        public Pumpkin()
        {
            type = Type.Vegetable;
            price = 50;
            name = "Pumpkin";
            description = "Big orange and scary if carved, it just screams halloween";
            hunger = 40;
        }
    }
}
