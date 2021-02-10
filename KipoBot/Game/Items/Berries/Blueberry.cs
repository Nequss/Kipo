using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Berries
{
    [Serializable]
    class Blueberry : Item
    {
        public Blueberry()
        {
            type = Type.Berry;
            price = 10;
            name = "Blueberry";
            description = "THE BEST BERRY IN THE WORLD - opinion of some pets";
            hunger = 5;
        }
    }
}