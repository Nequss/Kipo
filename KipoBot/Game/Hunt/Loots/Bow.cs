using KipoBot.Game.Base;
using System;

namespace KipoBot.Game.Hunt.Loots
{
    public class Bow : Pet
    {
        public Bow()
        {
            name = "Bow";
            health = 35;
            damage = 6;
            reward = 30;
        }