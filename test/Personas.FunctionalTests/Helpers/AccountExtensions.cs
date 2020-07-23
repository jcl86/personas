using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personas.Shared;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Personas.FunctionalTests
{
    public static class AccountExtensions
    {
        public static async Task<IEnumerable<Claim>> RegisterUser(this ServerFixture given, string password = null)
        {
            string username = $"{Guid.NewGuid()}@domain.com";
            var response = await given
              .Server
              .CreateRequest(AccountEndpoint.Register)
              .WithJsonBody(new RegisterModel()
              {
                  Username = username,
                  Password = password ?? Guid.NewGuid().ToString(),
              })
              .PostAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);
            var user = await response.ReadJsonResponse<UserViewModel>();
            user.Username.Should().Be(username);
            return Identities.CreateUser(user.Id, user.Username);
        }

        public static async Task SuccessToLogin(this ServerFixture given, string username, string password)
        {
            var response = await given
             .Server
             .CreateRequest(AccountEndpoint.Login)
             .WithJsonBody(new AuthenticateModel()
             {
                 Username = username,
                 Password = password,
             })
             .PostAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);
            var result = await response.ReadJsonResponse<AuthenticationSuccessResponse>();
            result.Username.Should().Be(username);
            result.Token.Should().NotBeNullOrWhiteSpace();
        }

        public static async Task FailToLogin(this ServerFixture given, string username, string password)
        {
            var response = await given
             .Server
             .CreateRequest(AccountEndpoint.Login)
             .WithJsonBody(new AuthenticateModel()
             {
                 Username = username,
                 Password = password,
             })
             .PostAsync();

            response.StatusCode.Should().Be(StatusCodes.Status401Unauthorized);
            var result = await response.ReadJsonResponse<ProblemDetails>();
            result.Status.Should().Be(StatusCodes.Status401Unauthorized);
        }
    }
}
