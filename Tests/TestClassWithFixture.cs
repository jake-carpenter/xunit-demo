using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class TestClassWithFixture : IDisposable
    {
        private readonly Fixture _fixture;

        public TestClassWithFixture()
        {
            // This gets hit first with every run, including each theory
            _fixture = new Fixture();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task DirectFixture(int value)
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
