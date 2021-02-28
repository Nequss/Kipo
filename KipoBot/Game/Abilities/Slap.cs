using System;
using System.Threading.Tasks;
using KipoBot.Game.Base;
using Discord;
using Discord.Commands;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class Slap : Ability
    {
        public Slap()
        {
            name = "Slap";
            description = "Nice slap across the cheek";
            price = 400;
        }

        public override int Speed(Pet pet) => pet.speed;

        public override Task Use(SocketCommandContext ctx, Pet attacker, Pet target)
        {
            double damage = Math.Round(Damage(attacker) + (Damage(attacker)*0.4));
            target.health -= (short)Damage(attacker);

            return Task.CompletedTask;
        }
    }
}