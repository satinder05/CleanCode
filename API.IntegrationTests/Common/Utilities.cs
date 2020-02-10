using Newtonsoft.Json;
using Persistence;
using System;
using Domain.Entities;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;

namespace API.IntegrationTests.Common
{
    public class Utilities
    {
        public static StringContent GetRequestContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        public static async Task<T> GetResponseContent<T>(HttpResponseMessage response)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(stringResponse);

            return result;
        }

        public static void CreateTables(SqliteConnection connection)
        {
            string dropProductsTable = "DROP TABLE IF EXISTS Products";
            SqliteCommand dropProductsTableCommand = new SqliteCommand(dropProductsTable, connection);
            dropProductsTableCommand.ExecuteNonQuery();

            string createProduct = "create table Products (Id varchar(36) DEFAULT NULL, Name varchar(17) DEFAULT NULL, Description varchar(35) DEFAULT NULL, Price decimal(6,2) DEFAULT NULL, DeliveryPrice decimal(4,2) DEFAULT NULL)";
            SqliteCommand command = new SqliteCommand(createProduct, connection);
            command.ExecuteNonQuery();

            string dropOptionsTable = "DROP TABLE IF EXISTS ProductOptions";
            SqliteCommand dropOptionsTableCommand = new SqliteCommand(dropOptionsTable, connection);
            dropOptionsTableCommand.ExecuteNonQuery();

            string createOption = "create table ProductOptions (Id varchar(36) DEFAULT NULL, ProductId varchar(36) DEFAULT NULL, Name varchar(9) DEFAULT NULL, Description varchar(23) DEFAULT NULL)";
            SqliteCommand createOptionCommand = new SqliteCommand(createOption, connection);
            createOptionCommand.ExecuteNonQuery();
        }

        public static void PopulateTestData(SqliteConnection connection)
        {
            string insertCommand;
            SqliteCommand createOptionCommand;

            //products
            insertCommand = "Insert into Products Values('8F2E9176-35EE-4F0A-AE55-83023D2DB1A3', 'Samsung Galaxy S10', 'Newest mobile from Samsung.', 900.99, 20.99)";
            createOptionCommand = new SqliteCommand(insertCommand, connection);
            createOptionCommand.ExecuteNonQuery();

            insertCommand = "Insert into Products Values('DE1287C0-4B15-4A7B-9D8A-DD21B3CAFEC3', 'Apple iPhone 6S', 'New mobile product from Apple.', 1299.99, 10.99)";
            createOptionCommand = new SqliteCommand(insertCommand, connection);
            createOptionCommand.ExecuteNonQuery();

            insertCommand = "Insert into Products Values('8BDEAB77-6BBC-43AE-9E07-2561660F4811', 'Nokia New Model', 'NGood Old Nokia.', 200.99, 10.99)";
            createOptionCommand = new SqliteCommand(insertCommand, connection);
            createOptionCommand.ExecuteNonQuery();

            insertCommand = "Insert into Products Values('AE1287C0-4B15-4A7B-9D8A-DD21B3CAFEC2', 'New Phone', 'For Option Upadate Test', 188.99, 10.99)";
            createOptionCommand = new SqliteCommand(insertCommand, connection);
            createOptionCommand.ExecuteNonQuery();

            //Options
            insertCommand = "Insert into ProductOptions Values('0643CCF0-AB00-4862-B3C5-40E2731ABCC9', '8F2E9176-35EE-4F0A-AE55-83023D2DB1A3', 'White', 'White Samsung S10')";
            createOptionCommand = new SqliteCommand(insertCommand, connection);
            createOptionCommand.ExecuteNonQuery();

            insertCommand = "Insert into ProductOptions Values('A21D5777-A655-4020-B431-624BB331E9A2', '8F2E9176-35EE-4F0A-AE55-83023D2DB1A3', 'Gold', 'Gold Samsung S10')";
            createOptionCommand = new SqliteCommand(insertCommand, connection);
            createOptionCommand.ExecuteNonQuery();

            insertCommand = "Insert into ProductOptions Values('5C2996AB-54AD-4999-92D2-89245682D534', 'DE1287C0-4B15-4A7B-9D8A-DD21B3CAFEC3', 'White', 'Option Desc')";
            createOptionCommand = new SqliteCommand(insertCommand, connection);
            createOptionCommand.ExecuteNonQuery();

            insertCommand = "Insert into ProductOptions Values('4BDEAB22-A655-4020-B431-624BB331E9A1', 'AE1287C0-4B15-4A7B-9D8A-DD21B3CAFEC2', 'Gold', 'Gold Samsung')";
            createOptionCommand = new SqliteCommand(insertCommand, connection);
            createOptionCommand.ExecuteNonQuery();


        }
        

        internal static void DropTables(SqliteConnection connection)
        {
            string dropProductsTable = "DROP TABLE Products";
            SqliteCommand dropProductsTableCommand = new SqliteCommand(dropProductsTable, connection);
            dropProductsTableCommand.ExecuteNonQuery();

            string dropOptionsTable = "DROP TABLE ProductOptions";
            SqliteCommand dropOptionsTableCommand = new SqliteCommand(dropOptionsTable, connection);
            dropOptionsTableCommand.ExecuteNonQuery();
        }
    }
}
