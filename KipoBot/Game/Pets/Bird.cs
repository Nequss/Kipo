using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Pets
{
    [Serializable]
    class Bird : Pet
    {
        public Bird()
        {
            type = Type.Bird;
            name = "Bird";

            health = 40;
            hunger = 25;
            thirst = 25;
            energy = 15;

            speed = 10;
            inteligence = 10;
            strength = 5;
            agility = 10;
            accuracy = 10;
        }

        public override byte getMaxHealth(byte level) => (byte)(40 + level);

        public override short getMaxEnergy(byte level) => (short)((15 + level) * 2);

        public override byte getMaxThirst() => 25;

        public override byte getMaxHunger() => 25;
    }
}
