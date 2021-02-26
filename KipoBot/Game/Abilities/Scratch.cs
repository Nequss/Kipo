using System;
using System.Threading.Tasks;
using KipoBot.Game.Base;
using Discord;
using Discord.Commands;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class Scratch : Ability
    {
        public Scratch()
        {
            name = "Scratch";
            description = "You got nice nails bruh...";
            price = 400;
        }

        public override int Speed(Pet pet) => pet.speed;

        public override Task Use(SocketCommandContext ctx, Pet attacker, Pet target)
        {
            double damage = Math.Round(Damage(attacker) + (Damage(attacker) * 0.4));

            return Task.CompletedTask;
        }
    }
}