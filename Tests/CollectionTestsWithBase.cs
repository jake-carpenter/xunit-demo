using Respawn;
using System;
using System.Threading.Tasks;
using Xunit;
using XunitCollectionTest.Controllers;

namespace Tests
{
    [Collection("Tests")]
    public abstract class BaseCollectionTest : IDisposable
    {
        protected BaseCollectionTest(Fixture fixture)
        {
            Fixture = fixture;
            Checkpoint = new Checkpoint();
            Checkpoint.Reset(Connection.String).Wait();
        }

        public Fixture Fixture { get; }
        public Checkpoint Checkpoint { get; private set; }

        public void Dispose()
        {
            Checkpoint.Reset(Connection.String).Wait();
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
            // Seed
            var id = Fixture.Seeder.Insert(value.ToString());

            // This is executed with a fresh instance of the class for each test
            var response = await Fixture.Client.GetAsync($"/api/values/{id}");
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
            // Seed
            var id = Fixture.Seeder.Insert(value.ToString());

            // This is executed with a fresh instance of the class for each test
            var response = await Fixture.Client.GetAsync($"/api/values/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
