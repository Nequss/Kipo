using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class Run : Ability
    {
        public Run()
        {
            name = "Run";
            description = "Runs away from the enemy!";
            price = 0;
        }

        public override int Use(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}