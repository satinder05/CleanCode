using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace API.IntegrationTests.Common.Fixtures
{
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            if (!File.Exists("products.db"))
                SQLiteConnection.CreateFile("products.db");

            var connection = new SqliteConnection("DataSource=products.db");
            connection.Open();

            Utilities.CreateTables(connection);
            Utilities.PopulateTestData(connection);

            // ... initialize data in the test database ...
        }

        public void Dispose()
        {
            var connection = new SqliteConnection("DataSource=products.db");
            connection.Open();

            Utilities.DropTables(connection);
            connection.Close();
        }

        //public SqlConnection Db { get; private set; }
    }
}
