using System;
using System.Threading.Tasks;
using KipoBot.Game.Base;
using Discord;
using Discord.Commands;
using KipoBot.Game.Base;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class QuickHit : Ability
    {
        public QuickHit()
        {
            name = "Quick Hit";
            description = "Fast as heck!";
            price = 200;
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