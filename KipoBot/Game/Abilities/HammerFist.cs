using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class HammerFist : Ability
    {
        public HammerFist()
        {
            name = "Hammer Fist";
            description = "More damage than normal one!";
            price = 1000;
        }

        public override int Use(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}