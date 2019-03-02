using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    [Collection("Tests")]
    public class CollectionTests1 : IDisposable
    {
        private readonly Fixture _fixture;

        public CollectionTests1(Fixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task FixtureFromCollection(int value)
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

    [Collection("Tests")]
    public class CollectionTests2 : IDisposable
    {
        private readonly Fixture _fixture;

        public CollectionTests2(Fixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task FixtureFromCollection(int value)
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
