using System;
using System.Threading.Tasks;
using Xunit;

namespace Personas.FunctionalTests
{
    [Collection(nameof(ServerFixtureCollection))]
    public class UsersScenariosShould
    {
        private readonly ServerFixture Given;

        public UsersScenariosShould(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        [Fact]
        public async Task Obtain_all_users_in_app()
        {
            string password = Guid.NewGuid().ToString();
            await Given.RegisterUser(password);
        }
    }
}
