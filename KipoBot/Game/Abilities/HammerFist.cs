using System;
using System.Threading.Tasks;
using KipoBot.Game.Base;
using Discord;
using Discord.Commands;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class HammerFist : Ability
    {
        public HammerFist()
        {
            name = "Hammer Fist";
            description = "More damage than normal punch!";
            price = 900;
        }

        public override int Speed(Pet pet) => pet.speed;

        public override Task Use(SocketCommandContext ctx, Pet attacker, Pet target)
        {
            double damage = Math.Round(Damage(attacker) + (Damage(attacker)*0.6));
            target.health -= (short)Damage(attacker);

            return Task.CompletedTask;
        }
    }
}