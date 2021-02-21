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

namespace KipoBot.Game.PvP
{
    public class PvPLogic
    {
        private readonly DatabaseService database;
        private readonly InteractiveService interaction;

        public PvPLogic(DatabaseService _database, InteractiveService _interaction)
        {
            database = _database;
            interaction = _interaction;
        }

        public async Task<Ability> FindAbility(string message, Pet pet)
        {
            if (message == null)
            {
                return null;
            }

            foreach (var ability in pet.abilities)
            {
                if (ability.name.ToLower() == message.ToLower())
                {
                    return ability;
                }
            }

            return null;
        }

        public async Task<Ability> ChooseAbility(SocketCommandContext ctx, Pet pet, SocketUser u)
        {
            await ctx.Channel.SendMessageAsync($"It's {pet.name} turn | Choose ability");
            SocketMessage response = await interaction.NextMessageAsync(ctx, new EnsureFromUserCriterion(u));
            Ability ability = await FindAbility(response.Content, pet);

            if (ability == null)
            {
                await ctx.Channel.SendMessageAsync($"Ability not found or you were thinking too long! Your pet will decide on its own!");
                return pet.abilities[new Random().Next(pet.abilities.Count)];
            }

            return ability;
        }

        public async Task StartPvP(SocketCommandContext ctx, Player p1, Player p2, SocketUser u1, SocketUser u2)
        {
            Pet pet1 = p1.active.Clone();
            Pet pet2 = p2.active.Clone();

            Ability ability1;
            Ability ability2;

            do
            {
                ability1 = await ChooseAbility(ctx, pet1, u1);
                ability2 = await ChooseAbility(ctx, pet2, u2);

                if (ability1.Speed(pet1) >= ability2.Speed(pet2))
                {
                    await ability1.Use(pet1, pet2);
                    await ability2.Use(pet2, pet1);
                }
                else
                {
                    await ability2.Use(pet2, pet1);
                    await ability1.Use(pet1, pet2);
                }

            } while (pet1.health <= 0 | pet2.health <= 0);
        }

        public async Task<Embed> MakeEmbed()
        {
            EmbedBuilder embedBuilder = new EmbedBuilder();



            return embedBuilder.Build();
        }
    }
}
