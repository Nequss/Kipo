using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class Eggplants : Item
    {
        public Eggplants ()
        {
            type = Type.Vegetable;
            price = 25;
            name = "Eggplants";
            description = "MEME EMOJI NICE FOOD PET LIKEY t";
            hunger = 15;
        }
    }
}