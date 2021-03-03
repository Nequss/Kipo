using KipoBot.Game.Base;
using System;

namespace KipoBot.Game.Hunt.Enemies
{
    public class Troll : Pet
    {
        public Troll()
        {
            name = "Troll";
            health = 20;
            damage = 4;
            reward = 15;
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
