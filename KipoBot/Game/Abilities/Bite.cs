﻿using System;
using System.Threading.Tasks;
using KipoBot.Game.Base;
using Discord;
using Discord.Commands;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class Bite : Ability
    {
        public Bite()
        {
            name = "Bite";
            description = "Bites enemy";
            price = 20;
        }

        public override int Speed(Pet pet) => pet.speed;

        public override Task Use(SocketCommandContext ctx, Pet attacker, Pet target)
        {
            int damage = Damage(attacker);
            target.health -= (short)Damage(attacker);

            if (target.health <= 0)
                target.health = 0;

            return Task.CompletedTask;
        }
    }
}