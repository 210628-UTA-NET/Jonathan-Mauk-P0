using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoreAppData.Entities;

namespace StoreAppData
{
    class DatabaseConnection
    {
        public static DbContextOptions<JMStoreAppContext> GetDatabaseOptions() 
        {
            //Get the configuration from our appsetting.json file
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //Grabs our connectionString from our appsetting.json
            string connectionString = configuration.GetConnectionString("Reference2DB");

            DbContextOptions<JMStoreAppContext> options = new DbContextOptionsBuilder<JMStoreAppContext>()
                .UseSqlServer(connectionString)
                .Options;

            return options;
        }
    }
}