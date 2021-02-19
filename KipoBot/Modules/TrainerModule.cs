using Discord;
using Discord.Webhook;
using Discord.WebSocket;
using Discord.Commands;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using KipoBot.Services;
using KipoBot.Game.Base;
using System.Reflection;
using KipoBot.Utils;

namespace KipoBot.Modules
{
    [Group("t")]
    [Name("trainer")]
    [Summary("Train pettos! Get new abilities for pettos and such!")]
    public class TrainerModule : ModuleBase<SocketCommandContext>
    {
        private readonly DatabaseService database;

        public TrainerModule(DatabaseService _database)
        {
            database = _database;
        }

        [Command("learn", RunMode = RunMode.Async)]
        [Summary("No description")]
        public async Task Learn([Remainder]string name)
        {
            Player player = await database.PlayerInfo(Context.User.Id);

            if (player != null)
            {
                foreach (var ability in database.abilities)
                {
                    foreach (var petAbility in player.active.abilities)
                    {
                        if (ability == petAbility)
                        {
                            await Context.Channel.SendMessageAsync($"Your pet already knows that!");
                            return;
                        }
                    }

                    if (ability.name.ToLower() == name.ToLower() & ability.name.ToLower() != "run")
                    {
                        if (player.wallet >= ability.price)
                        {
                            player.wallet -= ability.price;
                            player.active.abilities.Add(ability);
                            await Context.Channel.SendMessageAsync($"You have succesfully taught {player.active.name} a new ability!\n" +
                                $"Funds left: {player.wallet}");
                            return;
                        }
                        else
                        {
                            await Context.Channel.SendMessageAsync($"Not enough funds!\n" +
                                $"Your funds: {player.wallet} | Price: {ability.price}");
                            return;
                        }
                    }
                }

                await Context.Channel.SendMessageAsync($"Ability not found! Are you sure you spelled it correctly?");
            }
            else
            {
                await Context.Channel.SendMessageAsync("You are not a member of the Kipo's tamagotchi club.\n" +
                    "You can join by choosing your first pet, try +help starters");
            }
        }

        [Command("moves", RunMode = RunMode.Async)]
        [Summary("backpack summary")]
        public async Task Moves()
        {
            Player player = await database.FindPlayer(Context.Message.Author.Id);

            if (player != null)
            {
                string text = "";

                EmbedBuilder embedBuilder = new EmbedBuilder();

                embedBuilder.Color = Color.Purple;

                foreach (var ability in player.active.abilities)
                    text += $"{ability.name} - {ability.description}\n";

                embedBuilder.AddField($"{player.active.name} moves", text);

                await Context.Channel.SendMessageAsync(embed: embedBuilder.Build());
            }
            else
            {
                await Context.Channel.SendMessageAsync("You are not a member of the Kipo's tamagotchi club.\n" +
                    "You can join by choosing your first pet, try +help starters");
            }
        }

        [Command("abilities", RunMode = RunMode.Async)]
        [Summary("No description")]
        public async Task Abilities()
        {
            Player player = await database.PlayerInfo(Context.User.Id);

            if (player != null)
            {
                EmbedBuilder embedBuilder = new EmbedBuilder();

                embedBuilder.Color = Color.Purple;

                foreach (var ability in database.abilities)
                {
                    if (ability.name != "Run")
                        embedBuilder.AddField($"{ability.name} | {ability.price} ₭", $"{ability.description}");
                }

                await Context.Channel.SendMessageAsync(embed: embedBuilder.Build());
            }
            else
            {
                await Context.Channel.SendMessageAsync("You are not a member of the Kipo's tamagotchi club.\n" +
                    "You can join by choosing your first pet, try +help starters");
            }
        }
    }
}
