using System;
using System.Threading.Tasks;
using KipoBot.Game.Base;
using Discord;
using Discord.Commands;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class Kick : Ability
    {
        public Kick()
        {
            name = "Kick";
            description = "Normal kick what else do you expect";
            price = 70;
        }

        public override int Speed(Pet pet) => pet.speed;

        public override Task Use(SocketCommandContext ctx, Pet attacker, Pet target)
        {
            int damage = Damage(attacker)+1;
            target.health -= (short)Damage(attacker);

            return Task.CompletedTask;
        }
    }
}