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
    [Name("market")]
    [Summary("List your valuable things on market for other players.")]
    public class MarketModule : ModuleBase<SocketCommandContext>
    {
        private readonly DatabaseService database;

        public MarketModule(DatabaseService _database)
        {
            database = _database;
        }

    }
}
