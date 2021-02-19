using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class Combo : Ability
    {
        public Combo()
        {
            name = "Combo";
            description = "Does double damage but hard to hit";
            price = 1500;
        }

        public override int Use(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}