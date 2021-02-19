using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class Kick : Ability
    {
        public Kick()
        {
            name = "Kick";
            description = "Normal kick what else do you expect";
            price = 70;
        }

        public override int Use(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}