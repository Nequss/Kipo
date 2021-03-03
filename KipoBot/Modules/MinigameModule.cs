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
    [Name("minigames")]
    [Summary("Contains all fun minigames to play")]
    public class MinigameModule : ModuleBase<SocketCommandContext>
    {
        private readonly DatabaseService database;
        private readonly InteractiveService interaction;

        public MinigameModule(DatabaseService _database, InteractiveService _interaction)
        {
            interaction = _interaction;
            database = _database;
       
        }

        [Command("guess", RunMode = RunMode.Async)]
        [Summary("Play a number guesing game agaisnt Kipo +guess (your number)")]
        public async Task Guess(int x)
        {
            await ReplyAsync("Your petis thinking of a number between 1 to " + x + " try to guess ");

            int parseResult;
            Random rnd = new Random();
            int num = rnd.Next(1, x + 1);
            int playertries = 3;
            bool end = true;
            if (p1 == null)
            {
                await Context.Channel.SendMessageAsync("You are not a member of kipo tamogotchi club\n" +"please join it by typing +help starter");
                return;
            }
           
            else
            {
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
                        await ReplyAsync("Your pet is thinking of a different number try again you have " + playertries + " attemts left");
                    }
                }
                }
            }
        }

        [Command("friends", RunMode = RunMode.Async)]
        [Summary("Says how much you and your friend like each other ")]
        public async Task Friends(SocketUser user2)
        {
            SocketUser user1 = Context.Message.Author;

            await Context.Channel.SendMessageAsync(user1.Mention + " and " + user2.Mention + " your friendship is... ");

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

        [Command("rps", RunMode = RunMode.Async)]
        [Summary("Play a game of rock, paper, scissors against Kipo")]
        public async Task RPS()
        {
            await Context.Channel.SendMessageAsync("**You have started a game of Rock, Paper, Scissors\n**" + "Choose:\n" +
                "+rock\n" + "+paper\n" + "+scissors");
            
            SocketUser user = Context.Message.Author;
            Player p1 = await database.FindPlayer(Context.Message.Author.Id);
            SocketMessage response = await interaction.NextMessageAsync(Context, new EnsureFromUserCriterion(user));

            string[] Choices = new string[] { "Rock", "Paper", "Scissors" };
            String KipoChoice = (Choices[new Random().Next(Choices.Length)]);

            if (p1 == null)
            {
                await Context.Channel.SendMessageAsync("You have to join the tamogatchi club\n" + "You can join by choosing your first pet, try +help starters");
                return;
            }
            
            else 
            {
            if (response.Content == "+rock")
            {
                await Context.Channel.SendMessageAsync("You chose Rock");

                if (KipoChoice == "Paper")
                {
                   await Context.Channel.SendMessageAsync("Your pet chose paper\n" + "it beats rock! You lose!");
                }
                else if (KipoChoice == "Rock")
                {
                    await Context.Channel.SendMessageAsync("Your pet chose Rock\n" + " ITS A TIE");
                }
                else
                {
                    await Context.Channel.SendMessageAsync($" chose Scissors\n" + "You win Congrats!");
                }
                return;
            }
            if (response.Content == "+paper")
            {
                await Context.Channel.SendMessageAsync("You chose Paper");

                if (KipoChoice == "Scissors")
                {
                    await Context.Channel.SendMessageAsync("Your pet chose Scissors\n" + "it cuts trough paper! You lose!");
                }
                else if (KipoChoice == "Paper")
                {
                    await Context.Channel.SendMessageAsync("Your pet chose Paper\n" + " ITS A TIE");
                }
                else
                {
                    await Context.Channel.SendMessageAsync("Your pet chose Rock\n" + "Paper covers Rock! You win Congrats!");
                }
                return;
            }
            if (response.Content == "+scissors")
            {
                await Context.Channel.SendMessageAsync("You chose Scissors");

                if (KipoChoice == "Rock")
                {
                    await Context.Channel.SendMessageAsync("Your pet chose Rock\n" + "Rock breaks Scissors! You lose!");
                }
                else if (KipoChoice == "Scissors")
                {
                    await Context.Channel.SendMessageAsync("Your pet chose Scissors\n" + " ITS A TIE");
                }
                else
                {
                    await Context.Channel.SendMessageAsync("Your pet chose Papar\n" + "Scissors cut trough Paper! You win Congrats!");

                }
                return;
            }
            if (response.Content != "+rock" || response.Content != "+paper" || response.Content != "+scissors")
            {
                await Context.Channel.SendMessageAsync("You can only choose: +rock\n" + "+paper\n" + "+scissors");
                return;
            }
            }
        }
    }
}


