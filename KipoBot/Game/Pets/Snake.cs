using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Pets
{
    [Serializable]
    class Snake : Pet
    {
        public Snake()
        {
            type = Type.Snake;
            name = "Snake";

            health = 40;
            hunger = 25;
            thirst = 25;
            energy = 15;

            speed = 10;
            inteligence = 10;
            strength = 10;
            agility = 10;
            accuracy = 15;
        }

        public override byte getMaxHealth(byte level) => (byte)(40 + level);

        public override short getMaxEnergy(byte level) => (short)((10 + level) * 2);

        public override byte getMaxHunger() => 20;

        public override byte getMaxThirst() => 25;
    }
}
