using System;
using System.Threading.Tasks;
using KipoBot.Game.Base;
using Discord.Commands;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class AxeKick : Ability
    {
        public AxeKick()
        {
            name = "Axe Kick";
            description = "Strong kick ;)!";
            price = 800;
        }

        public override int Speed(Pet pet) => pet.speed;

        public override Task Use(SocketCommandContext ctx, Pet attacker, Pet target)
        {
           double damage = Math.Round(Damage(attacker) + (Damage(attacker)*0.5) +2);
            target.health -= (short)Damage(attacker);
            ctx.Channel.SendMessageAsync($"{attacker.name} attacked {target.name} using {name} ability!\n" +
                $"{target.name} Health - {target.health}");

            return Task.CompletedTask;
        }
    }
}