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

        public async Task<bool> Dodge()
        {
            
        }

        public async Task<bool> Hit()
        {

        }

        public async Task<int> Damage()
        {

        }

        public async Task<Ability> FindAbility(string message, Player player)
        {
            if (message == null)
            {
                return null;
            }

            foreach (var ability in player.active.abilities)
            {
                if (ability.name.ToLower() == message.ToLower())
                {
                    return ability;
                }
            }

            return null;
        }

        public async Task<Ability> ChooseAbility(SocketCommandContext ctx, Player p, SocketUser u)
        {
            await ctx.Channel.SendMessageAsync($"It's {p.active.name} turn | Choose ability");
            SocketMessage response = await interaction.NextMessageAsync(ctx, new EnsureFromUserCriterion(u));
            Ability ability = await FindAbility(response.Content, p);

            if (ability == null)
            {
                await ctx.Channel.SendMessageAsync($"Ability not found or you were thinking too long! Your pet will decide on its own!");
                return p.active.abilities[new Random().Next(p.active.abilities.Count)];
            }

            return ability;
        }

        public async Task StartPvP(SocketCommandContext ctx, Player p1, Player p2, SocketUser u1, SocketUser u2)
        {
            do
            {
                //TODO

                await ChooseAbility(ctx, p1, u1);
                await ChooseAbility(ctx, p2, u2);


            } while (p1.active.health <= 0 | p2.active.health <= 0);
        }

        public async Task<Embed> makeEmbed()
        {
            EmbedBuilder embedBuilder = new EmbedBuilder();



            return embedBuilder.Build();
        }
    }
}
