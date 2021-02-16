using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Berries
{
    [Serializable]
    class Cranberry : Item
    {
        public Cranberry()
        {
            type = Type.Berry;
            price = 20;
            name = "Cranberry";
            description = "Superfood berries because of their high nutrient and antioxidant";
            hunger = 10;
        }
    }
}