using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Berries
{
    [Serializable]
    class Strawberry : Item
    {
        public Strawberry()
        {
            type = Type.Berry;
            price = 15;
            name = "Strawberry";
            description = "UwU really great and sweet berry ";
            hunger = 5;
        }
    }
}