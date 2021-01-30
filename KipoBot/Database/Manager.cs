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
        public async Task CreateDatabase(string dbName) => SQLiteConnection.CreateFile(dbName + ".db");

        public async Task Configure(string dbName)
        {
            using (var connection = new SQLiteConnection(Directory.GetCurrentDirectory() + @"\" + dbName + ".db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "DROP TABLE IF EXISTS servers";
                    command.ExecuteNonQuery();

                    command.CommandText = "DROP TABLE IF EXISTS users";
                    command.ExecuteNonQuery();

                    command.CommandText = @"CREATE TABLE servers(id TEXT PRIMARY KEY, enabled INTEGER, banner INTEGER)";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
