using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class Bite : Ability
    {
        public Bite()
        {
            name = "Bite";
            description = "Bites enemy";
            price = 20;
        }

        public override int Use(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}