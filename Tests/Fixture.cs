using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using XunitCollectionTest;

namespace Tests
{
    public class Fixture : WebApplicationFactory<Startup>, IDisposable
    {
        public HttpClient Client { get; }

        public Fixture()
        {
            // This is what kicks off the call to execute 
            // the contents of Fixture.ConfigureWebHost()
            Client = this.CreateClient();
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
}
