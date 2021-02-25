using System;
using System.Threading.Tasks;
using KipoBot.Game.Base;
using Discord;
using Discord.Commands;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class Combo : Ability
    {
        public Combo()
        {
            name = "Combo";
            description = "Does double damage, is extremely hard to hit";
            price = 2500;
        }

        public override int Speed(Pet pet) => pet.speed;

        public override Task Use(SocketCommandContext ctx, Pet attacker, Pet target)
        {
            int agil = attacker.accuracy - 4;
            int damage = Damage(attacker) * 2;
            target.health -= (short)Damage(attacker);
            attacker.accuracy += (byte)attacker.accuracy;

            ctx.Channel.SendMessageAsync($"{attacker.name} attacked {target.name} using {name} ability!\n" +
                $"{target.name} Health - {target.health}");

            return Task.CompletedTask;
        }
    }
}