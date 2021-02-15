using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Berries
{
    [Serializable]
    class Loganberry : Item
    {
        public Loganberry()
        {
            type = Type.Berry;
            price = 20;
            name = "Loganberry";
            description = "Succulent berries that are delicious eaten out of hand or made into pies, jellies and jams";
            hunger = 12;
        }
    }
}