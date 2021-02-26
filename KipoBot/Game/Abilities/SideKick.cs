using System;
using System.Threading.Tasks;
using KipoBot.Game.Base;
using Discord;
using Discord.Commands;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class SideKick : Ability
    {
        public SideKick()
        {
            name = "Side Kick";
            description = "Kicks side of enemy stand";
            price = 600;
        }

        public override int Speed(Pet pet) => pet.speed;

        public override Task Use(SocketCommandContext ctx, Pet attacker, Pet target)
        {
           double damage = Math.Round(Damage(attacker) + (Damage(attacker)*0.2) + 2);
            target.health -= (short)Damage(attacker);

            return Task.CompletedTask;
        }
    }
}