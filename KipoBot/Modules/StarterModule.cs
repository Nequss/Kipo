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
        private readonly DatabaseService database;

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
            embedBuilder.AddField("Choose one of avaiable pets and remember to take care of it!", "\n **- Bird**" +
                "\n Sings pretty songs and always stays close sitting comfy on your shoulder"+
                "\n**- Dog**" +
                "\n Mad barker and talker will give you toons of love and kisses" +
                "\n **- Cat**" +
                "\n Sometimes can seem like it's annoyed at you but deep down it loves you" +
                "\n **- Lizard**" +
                "\n A reptile that look cool all the time anywhere it goes" +
                "\n** - Hamster**" +
                "\n Small and cute little one that will brighten up your day" +
                "\n** - Snake**" +
                "\n Goes hsss and wraps around your neck or arm, makes you look badass" +
                "\n** - Bunny**" +
                "\n Quick, full of energy and fluffy, loves to be close to you");
            embedBuilder.AddField("Use command below to choose your pet", "Example: +t choose Dog");
            embedBuilder.WithThumbnailUrl("https://thumbs2.imgbox.com/78/26/OS7ZaXwK_t.png");

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
            embedBuilder.AddField(result, "Welcome to the cute and fun game where you can raise a little cutie of a pet, have fun with it competing with other players, have small battles which each other and play some minigames, just don’t forget to take care of your little ones or they will get mad and run away! :3");
            embedBuilder.AddField("Useful commands:", "+help tamagotchi " +
                "\n" +
                "+t profile" +
                "\n" +
                "+t pet profile " +
                "\n");
            embedBuilder.AddField("Your pet:", "\u200b");
            embedBuilder.WithImageUrl("https://images2.imgbox.com/eb/4e/Wp74ahXN_o.png");

            await Context.Channel.SendMessageAsync(embed: embedBuilder.Build());
        }

        [Command("work", RunMode = RunMode.Async)]
        [Summary("just do it")]
        public async Task Work()
        {
            Player tmp = null;
            foreach (var player in database.players)
            {
                if (player.id == Context.User.Id)
                {
                    tmp = player;
                    break;
                }
            }

            if (tmp != null && !tmp.active.hasWork())
            {
                new Factory(tmp.active, tmp, Context);
            }
            else
            {
                await Context.Channel.SendMessageAsync("Pet already has a job!");
            }
        }
    }
}
