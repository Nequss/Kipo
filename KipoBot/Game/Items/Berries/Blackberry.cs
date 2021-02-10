using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Berries
{
    [Serializable]
    class Blacberry : Item
    {
        public Blacberry()
        {
            type = Type.Berry;
            price = 10;
            name = "Blacberry";
            describtion = "Rasberry but black";
            hunger = 5;
        }
    }
}