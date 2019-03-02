using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    [Collection("Tests")]
    public abstract class BaseCollectionTest : IDisposable
    {
        protected BaseCollectionTest(Fixture fixture)
        {
            Fixture = fixture;
        }

        public Fixture Fixture { get; }

        public void Dispose()
        {
            // This will be called after every test
        }
    }

    public class CollectionTestFromBase1 : BaseCollectionTest
    {
        public CollectionTestFromBase1(Fixture fixture) : base(fixture)
        {
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task FixtureFromCollection(int value)
        {
            // This is executed with a fresh instance of the class for each test
            var response = await Fixture.Client.GetAsync($"/api/values/{value}");
            response.EnsureSuccessStatusCode();
        }
    }

    public class CollectionTestFromBase2 : BaseCollectionTest
    {
        public CollectionTestFromBase2(Fixture fixture) : base(fixture)
        {
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task FixtureFromCollection(int value)
        {
            // This is executed with a fresh instance of the class for each test
            var response = await Fixture.Client.GetAsync($"/api/values/{value}");
            response.EnsureSuccessStatusCode();
        }
    }
}
