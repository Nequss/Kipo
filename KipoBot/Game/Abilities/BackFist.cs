﻿using System;
using System.Threading.Tasks;
using KipoBot.Game.Base;
using Discord;
using Discord.Commands;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class BackFist : Ability
    {
        public BackFist()
        {
            name = "Back Fist";
            description = "Little bit more damage than normal punch";
            price = 70;
        }
        public override int Speed(Pet pet) => pet.speed;

        public override Task Use(SocketCommandContext ctx, Pet attacker, Pet target)
        {
            int damage = Damage(attacker) +1;
            target.health -= (short)Damage(attacker);

            return Task.CompletedTask;
        }
    }
}