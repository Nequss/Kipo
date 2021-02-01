using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using System.Threading;
using System.Linq;
using System.Data.SQLite;
using Discord.Commands;

namespace KipoBot.Database
{
    public class Manager
    {
        private String DB_FILE = "KipoDB.db";

        public async Task CreateDatabase() => SQLiteConnection.CreateFile("KipoDB.db");

        public async Task Configure()
        {
            using (var connection = new SQLiteConnection("Data Source=" + Directory.GetCurrentDirectory() + "/" + DB_FILE))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "DROP TABLE IF EXISTS servers";
                    command.ExecuteNonQuery();

                    command.CommandText = "DROP TABLE IF EXISTS users";
                    command.ExecuteNonQuery();

                    command.CommandText = @"CREATE TABLE servers(
                                            guild_id TEXT PRIMARY KEY, 
                                            channel_id TEXT, 
                                            banner INTEGER, 
                                            welcomeBannerText TEXT DEFAULT 'Hello %USERNAME%!\nWelcome to the server!',
                                            welcomeBannerDesc TEXT DEFAULT '')";
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public async Task InsertWelcome(string guild_id, string channel_id)
        {
            using (var connection = new SQLiteConnection("Data Source=" + Directory.GetCurrentDirectory() + "/" + DB_FILE))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "INSERT INTO servers(guild_id, channel_id) VALUES(@guild_id, @channel_id)";
                    command.Parameters.AddWithValue("@guild_id", guild_id);
                    command.Parameters.AddWithValue("@channel_id", channel_id);
                    command.Prepare();

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public async Task DeleteWelcome(string id)
        {
            using (var connection = new SQLiteConnection("Data Source=" + Directory.GetCurrentDirectory() + "/" + DB_FILE))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "DELETE FROM servers WHERE " + id;
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public async Task<string> GetWelcome(string id)
        {
            string channel_id = string.Empty;
            string welcomeBannerText = string.Empty;
            string welcomeBannerDesc = string.Empty;

            using (var connection = new SQLiteConnection("Data Source=" + Directory.GetCurrentDirectory() + "/" + DB_FILE))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT channel_id, welcomeBannerText, welcomeBannerDesc FROM servers WHERE guild_id=@guild_id";
                    command.Parameters.AddWithValue("@guild_id", id);
                    command.Prepare();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            channel_id = reader.GetString(0);
                            welcomeBannerText = reader.GetString(1);
                            welcomeBannerDesc = reader.GetString(2);
                        }
                    }
                }

                connection.Close();
            }

            if (channel_id != string.Empty)
            {
                return channel_id + ";" + welcomeBannerText + ";" + welcomeBannerDesc;
            }
            else
            {
                return String.Empty;
            }
        }

        public async Task setBannerText(SocketCommandContext context, string text)
        {
            using (var connection = new SQLiteConnection("Data Source=" + Directory.GetCurrentDirectory() + "/" + DB_FILE))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "UPDATE servers SET welcomeBannerText = @text WHERE guild_id = @guild_id ";
                    command.Parameters.AddWithValue("@text", text);
                    command.Parameters.AddWithValue("@guild_id", context.Guild.Id.ToString());
                    command.Prepare();
                    
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
        
        public async Task setBannerDesc(SocketCommandContext context, string text)
        {
            using (var connection = new SQLiteConnection("Data Source=" + Directory.GetCurrentDirectory() + "/" + DB_FILE))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "UPDATE servers SET welcomeBannerDesc = @text WHERE guild_id = @guild_id ";
                    command.Parameters.AddWithValue("@text", text);
                    command.Parameters.AddWithValue("@guild_id", context.Guild.Id.ToString());
                    command.Prepare();
                    
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
