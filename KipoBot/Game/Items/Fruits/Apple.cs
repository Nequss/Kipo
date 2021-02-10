using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Apple : Item
    {
        public Apple()
        {
            type = Type.Fruit;
            price = 10;
            name = "Apple";
            description = "Well shaped, smooth skinned fruit that is high in nutrients and sugar";
            hunger = 5;
        }
    }
}
