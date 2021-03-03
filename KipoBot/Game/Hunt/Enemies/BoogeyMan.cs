using KipoBot.Game.Base;
using System;

namespace KipoBot.Game.Hunt.Enemies
{
    public class Boogeyman : Pet
    {
        public Boogeyman()
        {
            name = "Boogeyman";
            health = 15;
            damage = 3;
            reward = 10;
        }

        public override short getMaxEnergy(byte level)
        {
            throw new NotImplementedException();
        }

        public override byte getMaxHealth(byte level)
        {
            throw new NotImplementedException();
        }

        public override byte getMaxHunger()
        {
            throw new NotImplementedException();
        }

        public override byte getMaxThirst()
        {
            throw new NotImplementedException();
        }
    }
}
