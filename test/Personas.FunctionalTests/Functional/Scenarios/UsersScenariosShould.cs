using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Personas.Shared;
using System;
using System.Collections.Generic;
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
            var created = await Given.RegisterUser();

            var response = await Given
              .Server
              .CreateRequest(UsersEndpoint.GetAll)
              .WithIdentity(Identities.Administrator)
              .GetAsync();

            await response.ShouldBe(StatusCodes.Status200OK);
            var users = await response.ReadJsonResponse<IEnumerable<UserViewModel>>();
            users.Should().Contain(x => x.Username.Equals(created.Username()));
            users.Should().Contain(x => x.Username.Equals(Identities.Administrator.Username()));
        }

        [Fact]
        public async Task Fail_to_obtain_all_users_because_is_not_admin()
        {
            var response = await Given
              .Server
              .CreateRequest(UsersEndpoint.GetAll)
              .WithIdentity(Identities.OneUser)
              .GetAsync();

            await response.ShouldBe(StatusCodes.Status403Forbidden);
        }

        [Fact]
        public async Task Fail_to_obtain_all_users_because_is_not_authorized()
        {
            var response = await Given
              .Server
              .CreateRequest(UsersEndpoint.GetAll)
              .GetAsync();

            await response.ShouldBe(StatusCodes.Status401Unauthorized);
        }

        [Fact]
        public async Task Obtain_one_user_from_app()
        {
            var response = await Given
             .Server
             .CreateRequest(AccountEndpoint.Register)
             .WithJsonBody(new RegisterModel()
             {
                 Username = $"{Guid.NewGuid()}@domain.com",
                 Password = Guid.NewGuid().ToString(),
             })
             .PostAsync();
            await response.ShouldBe(StatusCodes.Status200OK);
            var created = await response.ReadJsonResponse<UserViewModel>();

            response = await Given
              .Server
              .CreateRequest(UsersEndpoint.GetById(created.Id))
              .WithIdentity(Identities.Administrator)
              .GetAsync();

            await response.ShouldBe(StatusCodes.Status200OK);
            var searched = await response.ReadJsonResponse<UserViewModel>();

            searched.Should().BeEquivalentTo(created);
        }

        [Fact]
        public async Task Fail_to_obtain_one_user_when_does_not_exist()
        {
            var response = await Given
              .Server
              .CreateRequest(UsersEndpoint.GetById(Guid.NewGuid()))
              .WithIdentity(Identities.Administrator)
              .GetAsync();

            await response.ShouldBe(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Fail_to_obtain_one_user_because_is_not_authorized()
        {
            var response = await Given
              .Server
              .CreateRequest(UsersEndpoint.GetById(Guid.NewGuid()))
              .GetAsync();

            await response.ShouldBe(StatusCodes.Status401Unauthorized);
        }

        [Fact]
        public async Task Fail_to_obtain_one_user_because_is_not_admin()
        {
            var response = await Given
              .Server
              .CreateRequest(UsersEndpoint.GetById(Guid.NewGuid()))
              .WithIdentity(Identities.OneUser)
              .GetAsync();

            await response.ShouldBe(StatusCodes.Status403Forbidden);
        }

        [Fact]
        public async Task Delete_existing_user_from_app()
        {
            var response = await Given
             .Server
             .CreateRequest(AccountEndpoint.Register)
             .WithJsonBody(new RegisterModel()
             {
                 Username = $"{Guid.NewGuid()}@domain.com",
                 Password = Guid.NewGuid().ToString(),
             })
             .PostAsync();
            await response.ShouldBe(StatusCodes.Status200OK);
            var created = await response.ReadJsonResponse<UserViewModel>();

            response = await Given
              .Server
              .CreateRequest(UsersEndpoint.Delete(created.Id))
              .WithIdentity(Identities.Administrator)
              .DeleteAsync();
            await response.ShouldBe(StatusCodes.Status204NoContent);

            response = await Given
              .Server
              .CreateRequest(UsersEndpoint.GetById(created.Id))
              .WithIdentity(Identities.Administrator)
              .GetAsync();

            await response.ShouldBe(StatusCodes.Status404NotFound);
        }


        [Fact]
        public async Task Fail_to_delete_user_when_does_not_exist()
        {
            var response = await Given
              .Server
              .CreateRequest(UsersEndpoint.GetById(Guid.NewGuid()))
              .WithIdentity(Identities.Administrator)
              .DeleteAsync();

            await response.ShouldBe(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Fail_to_delete_one_user_because_is_not_admin()
        {
            var response = await Given
              .Server
              .CreateRequest(UsersEndpoint.Delete(Guid.NewGuid()))
              .WithIdentity(Identities.OneUser)
              .GetAsync();

            await response.ShouldBe(StatusCodes.Status403Forbidden);
        }

        [Fact]
        public async Task Fail_to_delete_one_user_because_is_not_authorized()
        {
            var response = await Given
              .Server
              .CreateRequest(UsersEndpoint.Delete(Guid.NewGuid()))
              .GetAsync();

            await response.ShouldBe(StatusCodes.Status401Unauthorized);
        }
    }
}
