using Discord;
using Discord.Webhook;
using Discord.WebSocket;
using Discord.Commands;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using KipoBot.Services;

namespace Kipo.Modules
{
    [Group("t")]
    [Name("tamagotchi")]
    [Summary("Kipo's game module")]
    public class TamagotchiModule : ModuleBase<SocketCommandContext>
    {
        private static DatabaseService database;

        public TamagotchiModule(DatabaseService _database)
        {
            database = _database;
        }

        [Group("starters")]
        [Name("starters")]
        [Summary("Starter commands used to begin the game.")]
        public class StartersModule : ModuleBase<SocketCommandContext>
        {
            private static DatabaseService database;

            public StartersModule(DatabaseService _database)
            {
                database = _database;
            }

            [Command("show", RunMode = RunMode.Async)]
            [Summary("Shows starter pets avaiable to choose")]
            public async Task Show()
            {
                await Context.Channel.SendMessageAsync("Avaiable pets to choose as starter pet: \n" +
                    "\n - Bird" +
                    "\n - Dog" +
                    "\n - Cat" +
                    "\n - Lizard" +
                    "\n - Hamster" +
                    "\n - Snake" +
                    "\n - Bunny" +
                    "\n" +
                    "\n+t choose [pet]");
            }

            [Command("choose", RunMode = RunMode.Async)]
            [Summary("Shows starter pets avaiable to choose")]
            public async Task Choose([Remainder]string command) => await Context.Channel.SendMessageAsync(await database.AddPlayer(Context.Message.Author.Id, command));
        }

        [Group("profile")]
        [Name("profile")]
        [Summary("Profile commands")]
        public class ProfileModule : ModuleBase<SocketCommandContext>
        {
            private static DatabaseService database;

            public ProfileModule(DatabaseService _database)
            {
                database = _database;
            }

            [Command("show", RunMode = RunMode.Async)]
            [Summary("Shows your profile page.")]
            public async Task Show()
            {
                if (database.players != null && database.players.Count != 0)
                {
                    foreach (var player in database.players)
                    {
                        if(player.id == Context.Message.Author.Id)
                        {
                            EmbedBuilder embedBuilder = new EmbedBuilder();

                            embedBuilder.Color = Color.Purple;
                            embedBuilder.WithAuthor(author =>
                            {
                                author.WithName(Context.Message.Author.Username);
                                author.WithIconUrl(Context.Client.CurrentUser.GetAvatarUrl());
                            });

                            embedBuilder.AddField("ID         : ", player.id);
                            embedBuilder.AddField("Wallet     : ", player.wallet);
                            embedBuilder.AddField("Active pet : ", player.active.name);
                            embedBuilder.AddField("Pets count : ", player.pets.Count);
                            embedBuilder.AddField("Items count: ", player.items.Count);

                            await Context.Channel.SendMessageAsync(embed: embedBuilder.Build());
                            return;
                        }
                    }

                    await Context.Channel.SendMessageAsync("Profile not found!");
                    return;
                }
                else
                {
                    await Context.Channel.SendMessageAsync("Profile not found!");
                    return;
                }
            }

            [Command("pet", RunMode = RunMode.Async)]
            [Summary("Shows your active pet")]
            public async Task Pet()
            {
                if (database.players != null && database.players.Count != 0)
                {
                    foreach (var player in database.players)
                    {
                        if (player.id == Context.Message.Author.Id)
                        {

                            EmbedBuilder embedBuilder = new EmbedBuilder();

                            embedBuilder.Color = Color.Purple;
                            embedBuilder.WithAuthor(author =>
                            {
                                author.WithName(player.active.name);
                            });

                            embedBuilder.AddField("Name", player.active.name, true);
                            embedBuilder.AddField("Type", player.active.type, true);
                            embedBuilder.AddField("Health", player.active.health, true);
                            embedBuilder.AddField("Experience", player.active.xp, true);
                            embedBuilder.AddField("Level", player.active.level, true);
                            embedBuilder.AddField("Rarity", player.active.rarity, true);
                            embedBuilder.AddField("Hapiness", player.active.hapiness, true);
                            embedBuilder.AddField("Hunger", player.active.hunger, true);
                            embedBuilder.AddField("Thirst", player.active.thirst, true);
                            embedBuilder.AddField("Strength", player.active.strength, true);
                            embedBuilder.AddField("Agility", player.active.agility, true);
                            embedBuilder.AddField("Speed", player.active.speed, true);
                            embedBuilder.AddField("Inteligence", player.active.inteligence, true);
                            embedBuilder.AddField("Accuracy", player.active.accuracy, true);
                            embedBuilder.AddField("Energy", player.active.energy, true);

                            await Context.Channel.SendMessageAsync(embed: embedBuilder.Build());
                            return;
                        }
                    }

                    await Context.Channel.SendMessageAsync("Profile not found!");
                    return;
                }
                else
                {
                    await Context.Channel.SendMessageAsync("Profile not found!");
                    return;
                }
            }
        }
    }
}
