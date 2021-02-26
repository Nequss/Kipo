using System;
using System.Threading.Tasks;
using KipoBot.Game.Base;
using Discord;
using Discord.Commands;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class Tackle : Ability
    {
        public Tackle()
        {
            name = "Tackle";
            description = "Can make enemy paralized - has very low chance of hiting";
            price = 3300;
        }

        public override int Speed(Pet pet) => pet.speed;

        public override Task Use(SocketCommandContext ctx, Pet attacker, Pet target)
        {

             double damage = Math.Round (Damage(attacker) + Damage(attacker)*0.9);
             target.health -= (short)Damage(attacker);

            return Task.CompletedTask;
        }
    }
}