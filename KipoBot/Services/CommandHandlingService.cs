using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace KipoBot.Services
{
    public class CommandHandlingService
    {
        private readonly CommandService _commands;
        private readonly DiscordSocketClient _discord;
        private readonly ConfigurationService _config;
        private readonly IServiceProvider _services;

        public CommandHandlingService(IServiceProvider services, DiscordSocketClient client)
        {
            _commands = services.GetRequiredService<CommandService>();
            _discord = client;
            _services = services;
            _config = services.GetRequiredService<ConfigurationService>();

            _commands.CommandExecuted += CommandExecutedAsync;
            _discord.MessageReceived += MessageReceivedAsync;
        }

        public async Task InitializeAsync()
        {
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        public async Task MessageReceivedAsync(SocketMessage rawMessage)
        {
            if (!(rawMessage is SocketUserMessage message)) return;
            if (message.Source != MessageSource.User) return;

            var prefPos = 0;
            if (!message.HasCharPrefix(char.Parse(_config.prefix), ref prefPos)) return;

            var context = new SocketCommandContext(_discord, message);

            await _commands.ExecuteAsync(context, prefPos, _services);
        }

        public async Task CommandExecutedAsync(Optional<CommandInfo> command, ICommandContext context, IResult result)
        {

            if (!command.IsSpecified)
                return;

            if (result.IsSuccess)
                return;
            
            //await context.Channel.SendMessageAsync($"{result.ErrorReason}");
            ITextChannel channel = await context.Guild.GetTextChannelAsync(586636898420654080);
            
            await context.Channel.SendMessageAsync($"{command.Value.Summary}");
            //await channel.SendMessageAsync($"--{Environment.NewLine}Author: {context.Message.Author.Username} {Environment.NewLine}Message: {context.Message.Content} {Environment.NewLine}Error: {result}{Environment.NewLine}--");
        }
    }
}