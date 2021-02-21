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
using KipoBot.Utils;
using Discord.Addons.Interactive;
using KipoBot.Game.PvP;
using Discord;

namespace KipoBot.Modules
{
    [Group("t")]
    [Name("pvp")]
    [Summary("Pet versus Per! Fight with your pettos!")]
    public class PvPModule : ModuleBase<SocketCommandContext>
    {
        private readonly DatabaseService database;
        private InteractiveService interaction;
        public PvPModule(DatabaseService _database, InteractiveService _interaction)
        {
            database = _database;
            interaction = _interaction;
        }

        [Command("challenge", RunMode = RunMode.Async)]
        [Summary("Fight with other owners\n+t challenge [user]")]
        public async Task Challenge([Remainder]string message)
        {
            SocketUser u1 = Context.Message.Author;
            Player p1 = await database.FindPlayer(Context.Message.Author.Id);

            if (p1 == null)
            {
                await Context.Channel.SendMessageAsync("You are not a member of the Kipo's tamagotchi club.\n" +
                    "You can join by choosing your first pet, try +help starters");
                return;
            }

            SocketUser u2 = Helpers.extractUser(Context, message);
            Player p2 = await database.FindPlayer(u2.Id);

            if (p2 == null)
            {
                await Context.Channel.SendMessageAsync("Your enemy is not a member of the Kipo's tamagotchi club.");
                return;
            }

            await Context.Channel.SendMessageAsync($"Hey, {u2.Mention}! Wanna fight with {Context.Message.Author.Mention}?\n" +
                $"Type +accept in chat and let's see what happens! Remember you fight with your active pet.");

            SocketMessage response = await interaction.NextMessageAsync(Context, new EnsureFromUserCriterion(u2));

            if (response.Content == "+accept")
            {
                await Context.Channel.SendMessageAsync($"Pet vs Pet competition has started!\n" +
                    $"Tell your pet what to do when it's your turn by typing one of pet's abilities' name!\n" +
                    $"{p1.active.name} vs {p2.active.name}");

                await new PvPLogic(database, interaction).StartPvP(Context, p1, p2, u1, u2);
            }
            else
            {
                await Context.Channel.SendMessageAsync($"Challenge declined or ignored!");
            }
        }
    }
}