using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class SpringWater : Item
    {
        public SpringWater()
        {
            type = Type.Drink;
            price = 20;
            name = "Spring water";
            description = "Is it only drinkable in spring? Or am I just confused ";
            thirst = 10;
        }
    }
}