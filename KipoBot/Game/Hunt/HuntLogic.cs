using System;
using System.Collections.Generic;
using System.Text;
using Discord.WebSocket;
using Discord.Commands;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using KipoBot.Services;
using KipoBot.Game.Base;
using KipoBot.Utils;
using Discord.Addons.Interactive;
using Discord;
using System.Reflection;

namespace KipoBot.Game.Hunt
{
    public class HuntLogic
    {
        public async Task<Pet> ChooseEnemy()
        {
            var items = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.Namespace == "KipoBot.Game.Hunt.Enemies")
                .ToList();

            return (Pet)Activator.CreateInstance(items[new Random().Next(items.Count - 1)]);
        }

        public async Task<Ability> GetAbility(Pet pet)
            => pet.abilities[new Random().Next(pet.abilities.Count - 1)];

        public async Task Hunt(SocketCommandContext ctx, InteractiveService interaction, Pet pet)
        {
            await ctx.Channel.SendMessageAsync($"Quick battle start");

            var enemy = await ChooseEnemy();

            do
            {
                var ability = await GetAbility(pet);

                await ctx.Channel.SendMessageAsync($"turn has started!\nAbility chosen by pet: {ability.name}");

                await ctx.Channel.SendMessageAsync($"Enemy HP: {enemy.health}");
                await ctx.Channel.SendMessageAsync($"Pet HP: {pet.health}");

                if (new Random().Next(0, 100) < ability.ChanceHit(pet))
                    if (new Random().Next(0, 100) > ability.ChanceDodge(pet))
                        await ability.Use(ctx, pet, enemy);

                pet.health -= enemy.damage;

                await ctx.Channel.SendMessageAsync($"Enemy HP: {enemy.health}");
                await ctx.Channel.SendMessageAsync($"Pet HP: {pet.health}");

                if (pet.health == 0)
                {
                    await ctx.Channel.SendMessageAsync($"Your pet has been killed! :(");
                    break;
                }

                if (enemy.health == 0)
                {
                    await ctx.Channel.SendMessageAsync($"{enemy.name} has been killed!");
                    break;
                }
            } while (true);
        }
    }
}
