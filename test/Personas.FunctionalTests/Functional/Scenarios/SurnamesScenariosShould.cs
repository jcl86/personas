using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Personas.Domain;
using Personas.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Personas.FunctionalTests
{
    [Collection(nameof(ServerFixtureCollection))]
    public class SurnamesScenariosShould
    {
        private readonly ServerFixture Given;
        private readonly SurnamesEndpoint endpoint;

        public SurnamesScenariosShould(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
            endpoint = Endpoints.Surnames;
        }

        [Fact]
        public async Task Obtain_100_apellidos()
        {
            int requestedQuantity = 100;

            var response = await Given
                .Server
                .CreateRequest(endpoint.Get(requestedQuantity))
                .WithIdentity(Identities.OneUser)
                .GetAsync();
            await response.ShouldBe(StatusCodes.Status200OK);

            var result = await response.ReadJsonResponse<IEnumerable<SurnameViewModel>>();
            result.Count().Should().Be(requestedQuantity);
        }

        [Fact]
        public async Task Fail_to_obtain_less_than_100()
        {
            int requestedQuantity = 90;

            var response = await Given
                .Server
                .CreateRequest(endpoint.Get(requestedQuantity))
                .WithIdentity(Identities.OneUser)
                .GetAsync();

            await response.ShouldBe(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task Fail_to_obtain_requests_if_user_is_not_authenticated()
        {
            int requestedQuantity = 100;

            var response = await Given
                .Server
                .CreateRequest(endpoint.Get(requestedQuantity))
                .GetAsync();

            await response.ShouldBe(StatusCodes.Status401Unauthorized);
        }
    }
}
