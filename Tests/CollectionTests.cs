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
            // This is executed with a fresh instance of the class for each test
            var response = await _fixture.Client.GetAsync($"/api/values/{value}");
            response.EnsureSuccessStatusCode();
        }

        public void Dispose()
        {
            // This will be called after every test
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
            // This is executed with a fresh instance of the class for each test
            var response = await _fixture.Client.GetAsync($"/api/values/{value}");
            response.EnsureSuccessStatusCode();
        }

        public void Dispose()
        {
            // This will be called after every test
        }
    }

    [Collection("Tests")]
    public class CollectionTests3 : IDisposable
    {
        private readonly Fixture _fixture;

        public CollectionTests3(Fixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task FixtureFromCollection(int value)
        {
            // This is executed with a fresh instance of the class for each test
            var response = await _fixture.Client.GetAsync($"/api/values/{value}");
            response.EnsureSuccessStatusCode();
        }

        public void Dispose()
        {
            // This will be called after every test
        }
    }
}
