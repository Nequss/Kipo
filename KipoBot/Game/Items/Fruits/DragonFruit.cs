using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class DragonFruit : Item
    {
        public DragonFruit()
        {
            type = Type.Fruit;
            price = 45;
            name = "DragonFruit";
            description = "IT’S A DRAGON O.O YOU MIGHT GROW WINGS AND START BREATHING FIRE";
            hunger = 35;
        }
    }
}