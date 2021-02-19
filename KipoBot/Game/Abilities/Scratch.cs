using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class Scratch : Ability
    {
        public Scratch()
        {
            name = "Scratch";
            description = "You got nice nails bruh...";
            price = 200;
        }

        public override int Use(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}