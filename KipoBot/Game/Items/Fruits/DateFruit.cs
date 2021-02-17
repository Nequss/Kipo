using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class DateFruit :Item
    {
        public DateFruit()
        {
            type = Type.Fruit;
            price = 28;
            name = "Date fruit";
            description = "Frinkly looks old as heck but tastes good as heck  ";
            hunger = 18;
        }
    }
}
