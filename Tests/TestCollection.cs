using Xunit;

namespace Tests
{
    [CollectionDefinition("Tests")]
    public class TestCollection : ICollectionFixture<Fixture>
    {
    }
}
