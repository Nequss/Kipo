using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class Slap : Ability
    {
        public Slap()
        {
            name = "Slap";
            description = "Nice slap across the cheek";
            price = 400;
        }

        public override int Use(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}