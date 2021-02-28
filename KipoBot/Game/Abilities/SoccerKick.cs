using System;
using System.Threading.Tasks;
using KipoBot.Game.Base;
using Discord;
using Discord.Commands;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class SoccerKick : Ability
    {
        public SoccerKick()
        {
            name = "Soccer Kick";
            description = "Soccer kicks the enemy like a ball, has more damage harder to hit";
            price = 800;
        }

        public override int Speed(Pet pet) => pet.speed;

        public override Task Use(SocketCommandContext ctx, Pet attacker, Pet target)
        {
            int agil = attacker.accuracy - 1;
            double damage = Math.Round(Damage(attacker)+ (Damage(attacker)*0.5));
            target.health -= (short)Damage(attacker);

             attacker.accuracy -= (byte)attacker.accuracy;

            return Task.CompletedTask;
        }
    }
}