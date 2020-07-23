using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Personas.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Personas.FunctionalTests
{
    [Collection(nameof(ServerFixtureCollection))]
    public class RegisterScenariosShould
    {
        private readonly ServerFixture Given;

        public RegisterScenariosShould(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        [Fact]
        public async Task Just_register_one_user()
        {
            string password = Guid.NewGuid().ToString();
            await Given.RegisterUser(password);
        }

        [Fact]
        public async Task Register_user_and_login()
        {
            string password = Guid.NewGuid().ToString();
            var user = await Given.RegisterUser(password);

            await Given.SuccessToLogin(user.Username(), password);
        }

        [Fact]
        public async Task Register_user_and_fail_to_login()
        {
            string goodPassword = Guid.NewGuid().ToString();
            string wrongPassword = Guid.NewGuid().ToString();
            var user = await Given.RegisterUser(goodPassword);

            await Given.SuccessToLogin(user.Username(), wrongPassword);
        }

        [Fact]
        public async Task Register_user_and_change_password()
        {
            string firstPassword = Guid.NewGuid().ToString();
            var user = await Given.RegisterUser(firstPassword);

            await Given.SuccessToLogin(user.Username(), firstPassword);

            string newPassword = Guid.NewGuid().ToString();
            var response = await Given
             .Server
             .CreateRequest(AccountEndpoint.ChangePassword)
             .WithIdentity(user)
             .WithJsonBody(new ChangePasswordModel()
             {
                 Email = user.Username(),
                 CurrentPassword = firstPassword,
                 NewPassword = newPassword
             })
             .PutAsync();
            response.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            await Given.SuccessToLogin(user.Username(), newPassword);

            await Given.FailToLogin(user.Username(), firstPassword);
        }

        [Fact]
        public async Task Fail_to_change_password_when_password_is_wrong()
        {
            string firstPassword = Guid.NewGuid().ToString();
            var user = await Given.RegisterUser(firstPassword);

            await Given.SuccessToLogin(user.Username(), firstPassword);

            string wrongPassword = Guid.NewGuid().ToString();
            string newPassword = Guid.NewGuid().ToString();
            var response = await Given
             .Server
             .CreateRequest(AccountEndpoint.ChangePassword)
             .WithIdentity(user)
             .WithJsonBody(new ChangePasswordModel()
             {
                 Email = user.Username(),
                 CurrentPassword = wrongPassword,
                 NewPassword = newPassword
             })
             .PutAsync();
            response.StatusCode.Should().Be(StatusCodes.Status401Unauthorized);

            await Given.SuccessToLogin(user.Username(), firstPassword);

            await Given.FailToLogin(user.Username(), newPassword);
            await Given.FailToLogin(user.Username(), wrongPassword);
        }

        [Fact]
        public async Task Fail_to_change_other_users_password()
        {
            string password = Guid.NewGuid().ToString();
            var user = await Given.RegisterUser(password);

            string newPassword = Guid.NewGuid().ToString();
            var response = await Given
             .Server
             .CreateRequest(AccountEndpoint.ChangePassword)
             .WithIdentity(Identities.CreateUser(Guid.NewGuid(), "other@user.com"))
             .WithJsonBody(new ChangePasswordModel()
             {
                 Email = user.Username(),
                 CurrentPassword = password,
                 NewPassword = newPassword
             })
             .PutAsync();
            response.StatusCode.Should().Be(StatusCodes.Status401Unauthorized);

            await Given.SuccessToLogin(user.Username(), password);
        }
    }
}
