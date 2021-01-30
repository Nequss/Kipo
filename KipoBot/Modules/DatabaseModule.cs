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
using KipoBot.Database;

namespace Kipo.Modules
{
    [Name("database")]
    [Summary("Database configuration module.")]
    public class DatabaseModule : ModuleBase<SocketCommandContext>
    {
        [Command("createdb", RunMode = RunMode.Async)]
        [Summary("Creates new database or cleans existing one.")]
        [RequireOwner(ErrorMessage = "Avaiable only for bot owner.")]
        public async Task CreateDB(string dbName, Manager manager) => await manager.CreateDatabase(dbName);


    }
}
