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
using Discord.Addons.Interactive;

namespace KipoBot.Modules
{
    [Group("t")]
    [Name("pvp")]
    [Summary("Fight with pettos!")]
    public class PvPModule : ModuleBase<SocketCommandContext>
    {
        private readonly DatabaseService database;

        public PvPModule(DatabaseService _database)
        {
            database = _database;
        }

        Task Fight()
        {
            return Task.CompletedTask;
        }

        [Command("challenge", RunMode = RunMode.Async)]
        [Summary("Fight with other owners\n+t challenge [user]")]
        public async Task Challenge()
        {

        }

        [Command("pvp", RunMode = RunMode.Async)]
        [Summary("leaderboard")]
        public async Task PvP()
        {

        }
    }
}