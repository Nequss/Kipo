using System;
using System.Data.Entity;
using System.Threading;
using Discord.Commands;
using Discord.WebSocket;
using KipoBot.Modules;
using KipoBot.Services;

namespace KipoBot.Utils
{
    public class PetUpdater : ModuleBase<SocketCommandContext>
    { 
        private readonly DiscordSocketClient client;
        private readonly DatabaseService database;
        
        public bool running = false;
        public int checkIntervalMS = 10000;
            
        public PetUpdater(DiscordSocketClient _client, DatabaseService _database)
        {
            database = _database;
            client = _client;
            new Thread(start).Start();
        }
        
        public void start()
        {
            if (running)
                return;

            running = true;
            Thread.Sleep(10*1000);
            while (running)
            {
                DateTime currentTime = DateTime.Now;

                foreach (var player in database.players)
                {
                    foreach (var pet in player.pets)
                    {
                        Program.Logger.info($"Updating pet: {pet.name}");
                        lock (pet)
                        {
                            pet.performUpdate(currentTime);
                            Program.Logger.info($"{pet.name}: Thirst: {pet.thirst} Hunger: {pet.hunger} Happiness: {pet.hapiness} Health: {pet.health}");
                        }
                        Program.Logger.info($"Finished updating pet: {pet.name}!");
                    }
                }
                Program.Logger.info($"Pet update complete! Next update in {new TimeSpan(0,0,0,0,checkIntervalMS)}");
                
                
                Thread.Sleep(checkIntervalMS);
            }
        }

        public void stop()
        {
            running = false;
        }
    }
}