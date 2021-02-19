using Discord;
using Discord.Webhook;
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
using System.Reflection;
using KipoBot.Utils;

namespace KipoBot.Modules
{
    [Name("trainer")]
    [Summary("Train pettos! Get new abilities for pettos and such!")]
    public class TrainerModule : ModuleBase<SocketCommandContext>
    {

    }
}
