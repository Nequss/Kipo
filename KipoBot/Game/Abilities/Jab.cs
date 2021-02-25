using System;
using System.Threading.Tasks;
using KipoBot.Game.Base;
using Discord;
using Discord.Commands;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class Jab : Ability
    {
        public Jab()
        {
            name = "Jab";
            description = "Jabs the sucker";
            price = 500;
        }

        public override int Speed(Pet pet) => pet.speed;

        public override Task Use(SocketCommandContext ctx, Pet attacker, Pet target)
        {
            int agil = attacker.accuracy -2 ;
            double damage = Math.Round(Damage(attacker) + (Damage(attacker)*0.5));
            target.health -= (short)Damage(attacker);
            attacker.accuracy += (byte)attacker.accuracy;


            ctx.Channel.SendMessageAsync($"{attacker.name} attacked {target.name} using {name} ability!\n" +
                $"{target.name} Health - {target.health}");

            return Task.CompletedTask;
        }
    }
}