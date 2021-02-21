using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Egg : Item
    {
        public Egg()
        {
            type = Type.Egg;
            price = 2000;
            name = "Egg";
            description = "A egg that will hatch into one out of many beutiful pets!";
        }
    }
}
