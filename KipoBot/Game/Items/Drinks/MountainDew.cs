using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class MountainDew : Item
    {
        public MountainDew()
        {
            type = Type.Drink;
            price = 30;
            name = "Mountain Dew";
            description = "Best drink for true pet gamers, very high in sugar";
            thirst = 12;
            energy = 5;
        }
    }
}