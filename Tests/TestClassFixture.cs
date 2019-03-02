using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class TestClassFixture : IClassFixture<Fixture>, IDisposable
    {
        private readonly Fixture _fixture;

        // This constructor runs with each test, but the Fixture injected is always the same
        public TestClassFixture(Fixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task FixtureFromClassFixture(int value)
        {
            // Seed
            var id = _fixture.Seeder.Insert(value.ToString());

            // This is executed with a fresh instance of the class for each test
            var response = await _fixture.Client.GetAsync($"/api/values/{id}");
            response.EnsureSuccessStatusCode();
        }

        public void Dispose()
        {
            // This will be called after every test
            _fixture.Seeder.ClearData();
        }
    }
}
