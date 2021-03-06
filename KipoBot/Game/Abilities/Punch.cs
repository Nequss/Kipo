﻿using System;
using System.Threading.Tasks;
using KipoBot.Game.Base;
using Discord;
using Discord.Commands;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class Punch : Ability
    {
        public Punch()
        {
            name = "Punch";
            description = "Punch enemy like desk after raging";
            price = 20;
        }

        public override int Speed(Pet pet) => pet.speed;

        public override Task Use(SocketCommandContext ctx, Pet attacker, Pet target)
        {
            int damage = Damage(attacker);
            target.health -= (short)Damage(attacker);;

            return Task.CompletedTask;
        }
    }
}