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

namespace KipoBot.Modules
{
    [Name("Minigames")]
    [Summary("Contains all fun minigames to play")]
    public class MinigameModule : ModuleBase<SocketCommandContext>
    {
        private readonly InteractiveService interaction;

        public MinigameModule(InteractiveService _interaction)
        {
            interaction = _interaction;
        }

        [Command("Guess", RunMode = RunMode.Async)]
        [Summary("Play a number guesing game agaisnt Kipo +guess (your number)")]
        public async Task Guess(int x)
        {
            await ReplyAsync("Kipo is thinking of a number between 1 to "+x+" try to guess ");

           

            int parseResult;
            Random rnd = new Random();
            int num = rnd.Next(1, x + 1);
            int playertries = 3;
            bool end = true; 
            
            while (end == true)
            {
                playertries--;
                SocketMessage answer = await interaction.NextMessageAsync(Context);
                if (answer == null)
                {
                    await ReplyAsync("You didn't pick a number before the timeout");
                    return;
                }
                bool result = Int32.TryParse(answer.Content, out parseResult);

                if (result == false)
                {
                    await Context.Channel.SendMessageAsync("Your guess has to be a number");
                    return;
                }

                if (result == true)
                {
                    if (playertries == 0)
                    {
                        await Context.Channel.SendMessageAsync("You lost the game :c");
                        return;
                    }
                    if (parseResult == num)
                    {
                        await Context.Channel.SendMessageAsync("You win! CONGRATS");
                        return;
                    }
                    else
                    {
                        await ReplyAsync("Kipo is thinking of a different number try again you have " + playertries + " attemts left");
                    }
                }
               
            }
        }

        [Command("Friends", RunMode = RunMode.Async)]
        [Summary("Says how much you and your friend like each other ")]
        public async Task Friends(SocketUser user2)
        {
            SocketUser user1 = Context.Message.Author;

            await Context.Channel.SendMessageAsync( user1.Mention + " and " + user2.Mention + " your friendship is... ");
            
            string[] message = new string[] {
            "**0%** You should not be friends it almost feels like you hate each other",
            "**10%** VERY, VERY SLIM precent of liking you might as well be just strangers",
            "**20%**  Do you two even talk with each other you sure you didnt just met? ",
            "**30% **Well meh you both are still basically on the level of acquaintances",
            "**40%** are you classmates who dont talk or what? ",
            "**50%** Welllllll your friendship is half good",
            "**60%** tiny little bit more than half but hey you getting there",
            "**70% **ohohohoho very nice average friendship",
            "**80%** your friendship is very strong it's nice to see :3",
            "**90%** The heck you guys how do you stay such good friends you practically soulmates ",
            "**100%** YOUR FRIENDSHIP IS TOO STRONG FOR THIS WORLD AAAAAAAAAA" };
            
            await Context.Channel.SendMessageAsync(message[new Random().Next(message.Length)]);


        }
    }
}

