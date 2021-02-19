using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class Tackle : Ability
    {
        public Tackle()
        {
            name = "Tackle";
            description = "Can make enemy paralized - has very low chance of hiting";
            price = 1000;
        }

        public override int Use(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}