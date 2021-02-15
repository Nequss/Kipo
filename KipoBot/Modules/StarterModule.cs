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
using KipoBot.Game.Base;
using KipoBot.Game.Jobs;
using KipoBot.Services;

namespace Kipo.Modules
{
    [Group("t")]
    [Name("starter")]
    [Summary("Constains all needed commands to join the game.")]
    public class StarterModule : ModuleBase<SocketCommandContext>
    {
        private static DatabaseService database;

        public StarterModule(DatabaseService _database)
        {
            database = _database;
        }

        [Command("starters", RunMode = RunMode.Async)]
        [Summary("Shows starter pets avaiable to choose")]
        public async Task ChoosePet()
        {
            EmbedBuilder embedBuilder = new EmbedBuilder();

            embedBuilder.WithAuthor(author =>
            {
                author.WithName("Kipo's tamagotchi club");
                author.WithIconUrl(Context.Client.CurrentUser.GetAvatarUrl());
            });

            embedBuilder.Color = Color.Purple;
            embedBuilder.AddField("Choose one of avaiable pets and remember to take care of it!", "\n - Bird" +
                "\n - Dog" +
                "\n - Cat" +
                "\n - Lizard" +
                "\n - Hamster" +
                "\n - Snake" +
                "\n - Bunny");
            embedBuilder.AddField("Use command below to choose your pet", "Example: +t choose Dog");
            embedBuilder.WithThumbnailUrl("https://images2.imgbox.com/eb/4e/Wp74ahXN_o.png");

            await Context.Channel.SendMessageAsync(embed: embedBuilder.Build());
        }

        [Command("choose", RunMode = RunMode.Async)]
        [Summary("Shows starter pets avaiable to choose")]
        public async Task Choose([Remainder]string command)
        {
            string result = await database.AddPlayer(Context.Message.Author.Id, command);

            if (result == "error")
            {
                await Context.Channel.SendMessageAsync("Pet not found! Make sure you spelled it right! \nExample: +t choose Lizard");
                return;
            }

            EmbedBuilder embedBuilder = new EmbedBuilder();

            embedBuilder.WithAuthor(author =>
            {
                author.WithName("Kipo's tamagotchi club | Welcome " + Context.Message.Author.Username + "!");
                author.WithIconUrl(Context.Client.CurrentUser.GetAvatarUrl());
            });

            embedBuilder.Color = Color.Purple;
            embedBuilder.AddField(result, "Welcome to the cute and fun game where you can raise a little cutie of a pet and have fun with it competing with other players and have small battles which each other and play some minigames, just don’t forget to take care of your little ones or they will get mad and run away! :3");
            embedBuilder.AddField("Useful commands:", "+command" +
                "\n" +
                "+command" +
                "\n" +
                "+command" +
                "\n");
            embedBuilder.AddField("Your pet:", "\u200b");
            embedBuilder.WithImageUrl("https://images2.imgbox.com/eb/4e/Wp74ahXN_o.png");

            await Context.Channel.SendMessageAsync(embed: embedBuilder.Build());
        }
    }
}
