using System;
using System.Threading.Tasks;
using KipoBot.Game.Base;
using Discord;
using Discord.Commands;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class SuckerPunch : Ability
    {
        public SuckerPunch()
        {
            name = "Sucker Punch";
            description = "Punch so strong even gods fear it ";
            price = 3000;
        }

        public override int Speed(Pet pet) => pet.speed;

        public override Task Use(SocketCommandContext ctx, Pet attacker, Pet target)
        {
            double damage = Math.Round(Damage(attacker) +( Damage(attacker)*0.8));
            target.health -= (short)Damage(attacker);
            

            ctx.Channel.SendMessageAsync($"{attacker.name} attacked {target.name} using {name} ability!\n" +
                $"{target.name} Health - {target.health}");

            return Task.CompletedTask;
        }
    }
}