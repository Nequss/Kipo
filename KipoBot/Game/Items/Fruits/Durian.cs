using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Durian : Item
    {
        public Durian()
        {
            type = Type.Fruit;
            price = 55;
            name = "Durian";
            description = "Smells so bad it's even banned in some coutries not for everyones taste aparently ";
            hunger = 40;
        }
    }
}
