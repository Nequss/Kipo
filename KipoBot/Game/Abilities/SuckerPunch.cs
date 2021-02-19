using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class SuckerPunch : Ability
    {
        public SuckerPunch()
        {
            name = "Sucker Punch";
            description = "More damage, it can surprise enemy and hit first next round";
            price = 700;
        }

        public override int Use(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}