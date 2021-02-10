using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Tools
{
    [Serializable]
    class Car : Item
    {
        public Car()
        {
            type = Type.Tool;
            price = 3000;
            name = "Car";
            description = "Let your pet drive around the city in brand new car!";
        }
    }
}