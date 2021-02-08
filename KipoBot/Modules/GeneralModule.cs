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
using KipoBot.Game.Base;

namespace KipoBot.Modules
{
    [Group("t")]
    [Name("general")]
    [Summary("Commands used to manage your equipment, profile, pets and such.")]
    public class GeneralModule : ModuleBase<SocketCommandContext>
    {
        private static DatabaseService database;

        public GeneralModule(DatabaseService _database)
        {
            database = _database;
        }

        [Command("profile", RunMode = RunMode.Async)]
        [Summary("Shows your profile page.\n+t profile")]
        public async Task Profile()
        {
            Player player = await database.PlayerInfo(Context.User.Id);

            if (player != null)
            {
                EmbedBuilder embedBuilder = new EmbedBuilder();

                embedBuilder.Color = Color.Purple;
                embedBuilder.WithAuthor(author =>
                {
                    author.WithName("Profile Card | " + Context.Message.Author.Username);
                });

                embedBuilder.AddField("Statistics",
                    $"ID: {player.id}\n" +
                    $"Wallet: {player.wallet}\n" +
                    $"Active pet: {player.active.name}\n" +
                    $"Type: {player.active.type}\n" +
                    $"Pets: {player.pets.Count}\n" +
                    $"Items: {player.items.Count}");

                embedBuilder.WithThumbnailUrl(Context.Message.Author.GetAvatarUrl());

                await Context.Channel.SendMessageAsync(embed: embedBuilder.Build());
            }
            else
            {
                await Context.Channel.SendMessageAsync("You are not a member of the Kipo's tamagotchi club.\n" +
                    "You can join by choosing your first pet, try +help starters");
            }
        }

        [Command("active", RunMode = RunMode.Async)]
        [Summary("Shows your active pet\n+t active")]
        public async Task Active()
        {
            Player player = await database.PlayerInfo(Context.User.Id);

            if (player != null)
            {
                EmbedBuilder embedBuilder = new EmbedBuilder();

                embedBuilder.Color = Color.Purple;
                embedBuilder.WithAuthor(author =>
                {
                    author.WithName($"Pet Card | {player.active.type}");
                });

                embedBuilder.AddField("Pet info",
                    $"Name: {player.active.name}\n" +
                    $"Rarity: {player.active.rarity}\n" +
                    $"Level: {player.active.level}\n" +
                    $"Experience: {player.active.xp}\n" +
                    $"Has job: {player.active.hasWork()}");

                embedBuilder.AddField("Pet needs",
                    $"Health: {player.active.health}\n" +
                    $"Hapiness: {player.active.hapiness}\n" +
                    $"Hunger: {player.active.hunger}\n" +
                    $"Thirst: {player.active.thirst}");

                embedBuilder.AddField("Pet statistics",
                    $"Strength: {player.active.strength}\n" +
                    $"Agility: {player.active.agility}\n" +
                    $"Speed: {player.active.speed}\n" +
                    $"Inteligence: {player.active.inteligence}\n" +
                    $"Accuracy: {player.active.accuracy}\n" +
                    $"Energy: {player.active.energy}");

                embedBuilder.WithImageUrl("https://images2.imgbox.com/eb/4e/Wp74ahXN_o.png");

                await Context.Channel.SendMessageAsync(embed: embedBuilder.Build());
            }
            else
            {
                await Context.Channel.SendMessageAsync("You are not a member of the Kipo's tamagotchi club.\n" +
                    "You can join by choosing your first pet, try +help starters");
            }
        }

        [Command("name", RunMode = RunMode.Async)]
        [Summary("Changes the name of your active pet.\n+t name [name]")]
        public async Task Name([Remainder]string name = null)
        {
            if (name == null)
            {
                await Context.Channel.SendMessageAsync("Name can't be blank!");
                return;
            }

            foreach (var player in database.players)
            {
                if (player.id == Context.Message.Author.Id)
                {
                    player.active.name = name;
                    await Context.Channel.SendMessageAsync("The name of your pet has been changed!");
                    return;
                }
            }

            await Context.Channel.SendMessageAsync("You are not a member of the Kipo's tamagotchi club.\n" +
                "You can join by choosing your first pet, try +help starters");
        }

        [Command("pets", RunMode = RunMode.Async)]
        [Summary("Lists all your pets.\n+t pets")]
        public async Task Pets()
        {
            foreach (var player in database.players)
            {
                if (player.id == Context.Message.Author.Id)
                {
                    EmbedBuilder embedBuilder = new EmbedBuilder();

                    embedBuilder.Color = Color.Purple;

                    string text = string.Empty;

                    for (int i = 0; i < player.pets.Count; i++)
                        text += $"Index: {i} - {player.pets[i].name}\n";

                    embedBuilder.AddField($"Pet List | {Context.Message.Author.Username}", text);

                    await Context.Channel.SendMessageAsync(embed: embedBuilder.Build());
                    return;
                }
            }

            await Context.Channel.SendMessageAsync("You are not a member of the Kipo's tamagotchi club.\n" +
                "You can join by choosing your first pet, try +help starters");
        }

        [Command("change", RunMode = RunMode.Async)]
        [Summary("Changes active pet, indexes of your pets can be found in +t pets\n+t change [pet's index]")]
        public async Task Change(int? index = null)
        {
            foreach (var player in database.players)
            {
                if (player.id == Context.Message.Author.Id)
                {
                    try
                    {
                        player.active = player.pets[index.Value];
                        await Context.Channel.SendMessageAsync("Active pet has been changed!");
                        return;
                    }
                    catch
                    {
                        await Context.Channel.SendMessageAsync("There is no pet with such index! Type +t pets to find your pet's index!");
                        return;
                    }
                }
            }

            await Context.Channel.SendMessageAsync("You are not a member of the Kipo's tamagotchi club.\n" +
                "You can join by choosing your first pet, try +help starters");
        }
    }
}
