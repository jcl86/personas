using Xunit;

namespace Personas.FunctionalTests
{
    [CollectionDefinition(nameof(ServerFixtureCollection))]
    public class ServerFixtureCollection
      : ICollectionFixture<ServerFixture>
    {
    }
}
