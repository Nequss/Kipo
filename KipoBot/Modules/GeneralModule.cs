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
        [Summary("Shows your profile page.")]
        public async Task Profile()
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
                            author.WithName(Context.Message.Author.Username);
                            author.WithIconUrl(Context.Client.CurrentUser.GetAvatarUrl());
                        });

                        embedBuilder.AddField("ID         : ", player.id);
                        embedBuilder.AddField("Wallet     : ", player.wallet);
                        embedBuilder.AddField("Active pet : ", player.active.name);
                        embedBuilder.AddField("Pets count : ", player.pets.Count);
                        embedBuilder.AddField("Items count: ", player.items.Count);
                        embedBuilder.WithImageUrl(Context.Message.Author.GetAvatarUrl());

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

        [Command("active", RunMode = RunMode.Async)]
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

                        embedBuilder.AddField("Name", player.active.name);
                        embedBuilder.AddField("Type", player.active.type);
                        embedBuilder.AddField("Health", player.active.health);
                        embedBuilder.AddField("Experience", player.active.xp);
                        embedBuilder.AddField("Level", player.active.level);
                        embedBuilder.AddField("Rarity", player.active.rarity);
                        embedBuilder.AddField("Hapiness", player.active.hapiness);
                        embedBuilder.AddField("Hunger", player.active.hunger);
                        embedBuilder.AddField("Thirst", player.active.thirst);
                        embedBuilder.AddField("Strength", player.active.strength);
                        embedBuilder.AddField("Agility", player.active.agility);
                        embedBuilder.AddField("Speed", player.active.speed);
                        embedBuilder.AddField("Inteligence", player.active.inteligence);
                        embedBuilder.AddField("Accuracy", player.active.accuracy);
                        embedBuilder.AddField("Energy", player.active.energy);
                        embedBuilder.WithImageUrl("https://images2.imgbox.com/eb/4e/Wp74ahXN_o.png");

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
