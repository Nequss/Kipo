using System;
using System.Threading.Tasks;
using KipoBot.Game.Base;
using Discord;
using Discord.Commands;
using KipoBot.Game.Base;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class BodySlam : Ability
    {
        public BodySlam()
        {
            name = "Body Slam";
            description = "Body slams enemy, double the damage, has chance of impacting you instead ";
            price = 2000;
        }

        public override int Speed(Pet pet) => pet.speed;

        public override Task Use(SocketCommandContext ctx, Pet attacker, Pet target)
        {
            int damage = Damage(attacker);
            target.health -= (byte)damage;
            ctx.Channel.SendMessageAsync($"{attacker.name} attacked {target.name} using {name} ability!\n" +
                $"{target.name} Health - {target.health}");

            return Task.CompletedTask;
        }
    }
}