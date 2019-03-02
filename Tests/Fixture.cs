using Dapper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data.SqlClient;
using System.Net.Http;
using XunitCollectionTest;
using XunitCollectionTest.Controllers;

namespace Tests
{
    public class Fixture : WebApplicationFactory<Startup>, IDisposable
    {
        public HttpClient Client { get; }
        public Seeder Seeder { get; private set; }

        public Fixture()
        {
            // This is what kicks off the call to execute 
            // the contents of Fixture.ConfigureWebHost()
            Client = this.CreateClient();
            Seeder = new Seeder();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");
            builder.UseStartup<Startup>();
            builder.ConfigureAppConfiguration(SetupConfiguration);
            builder.ConfigureTestServices(SetupTestServices);
        }

        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder();
        }

        public new void Dispose()
        {
            // This is executed when the fixture is no longer used. Note the 'new' keyword.
            // In a ClassFixture scenario, all tests in the class run, then this method runs
            // In a CollectionFixture scenario, all tests from all classes run, then this method runs
            //Seeder.Dispose();
        }

        private void SetupTestServices(IServiceCollection services)
        {
            // Register overriding DI
        }

        private void SetupConfiguration(IConfigurationBuilder configBuilder)
        {
            // Add configuration
        }
    }

    public class Seeder : IDisposable
    {
        public void ClearData()
        {
            //using (var conn = new SqlConnection(Connection.String))
            //{
            //    conn.Execute("TRUNCATE TABLE dbo.Todo");
            //}
        }

        public int Insert(string value)
        {
            using (var conn = new SqlConnection(Connection.String))
            {
                return conn.ExecuteScalar<int>(
                        "INSERT INTO dbo.Todo OUTPUT inserted.Id VALUES(@value)",
                        new { value });
            }
        }

        public void Dispose()
        {
            ClearData();
        }
    }
}
