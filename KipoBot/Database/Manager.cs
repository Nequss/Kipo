using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using System.Threading;
using System.Linq;
using System.Data.SQLite;

namespace KipoBot.Database
{
    public class Manager
    {
        public async Task CreateDatabase() => SQLiteConnection.CreateFile("KipoDB.db");

        public async Task Configure()
        {
            using (var connection = new SQLiteConnection("Data Source=" + Directory.GetCurrentDirectory() + @"\KipoDB.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "DROP TABLE IF EXISTS servers";
                    command.ExecuteNonQuery();

                    command.CommandText = "DROP TABLE IF EXISTS users";
                    command.ExecuteNonQuery();

                    command.CommandText = @"CREATE TABLE servers(guild_id TEXT PRIMARY KEY, channel_id TEXT, banner INTEGER)";
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public async Task InsertWelcome(string guild_id, string channel_id, int banner)
        {
            using (var connection = new SQLiteConnection("Data Source=" + Directory.GetCurrentDirectory() + @"\KipoDB.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "INSERT INTO servers(guild_id, channel_id, banner) VALUES(@guild_id, @channel_id, @banner)";

                    command.Parameters.AddWithValue("@guild_id", guild_id);
                    command.Parameters.AddWithValue("@channel_id", channel_id);
                    command.Parameters.AddWithValue("@banner", banner);
                    command.Prepare();

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public async Task DeleteWelcome(string id)
        {
            using (var connection = new SQLiteConnection("Data Source=" + Directory.GetCurrentDirectory() + @"\KipoDB.db"))
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
            int banner = 0;

            using (var connection = new SQLiteConnection("Data Source=" + Directory.GetCurrentDirectory() + @"\KipoDB.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT channel_id, banner FROM servers WHERE guild_id=@guild_id";
                    command.Parameters.AddWithValue("@guild_id", id);
                    command.Prepare();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            channel_id = reader.GetString(0);
                            banner = reader.GetInt32(1);
                        }
                    }
                }

                connection.Close();
            }

            if (channel_id != string.Empty)
            {
                return channel_id + ";" + banner.ToString();
            }
            else
            {
                return String.Empty;
            }
        }
    }
}
