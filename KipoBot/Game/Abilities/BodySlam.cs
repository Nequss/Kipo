using System;
using System.Threading.Tasks;
using KipoBot.Game.Base;
using Discord;
using Discord.Commands;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class BodySlam : Ability
    {
        public BodySlam()
        {
            name = "Body Slam";
            description = "Body slams enemy, double the damage, has chance of impacting you instead ";
            price = 3500;
        }

        public override int Speed(Pet pet) => pet.speed;

        public override Task Use(SocketCommandContext ctx, Pet attacker, Pet target)
        {
            int damage = Damage(attacker)*2;
            target.health -= (short)Damage(attacker);

            return Task.CompletedTask;
        }
    }
}