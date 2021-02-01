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

namespace KipoBot.Modules
{
    [Name("database")]
    [Summary("Database configuration module.")]
    public class DatabaseModule : ModuleBase<SocketCommandContext>
    {
        Manager manager = new Manager();

        [Command("createdb", RunMode = RunMode.Async)]
        [Summary("Creates new database file.")]
        //[RequireOwner(ErrorMessage = "Avaiable only for bot owner.")]
        public async Task CreateDB() => await manager.CreateDatabase();

        [Command("configure", RunMode = RunMode.Async)]
        [Summary("Configures new database or cleans existing one.")]
        //[RequireOwner(ErrorMessage = "Avaiable only for bot owner.")]
        public async Task Configure() => await manager.Configure();
    }
}
