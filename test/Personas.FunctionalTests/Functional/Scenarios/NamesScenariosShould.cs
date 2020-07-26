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
    public class NamesScenariosShould
    {
        private readonly ServerFixture Given;
        private readonly NamesEndpoint endpoint = Endpoints.Names;

        public NamesScenariosShould(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        [Fact]
        public async Task Obtain_100_names()
        {
            int requestedQuantity = 100;

            var response = await Given
                .Server
                .CreateRequest(endpoint.Get(requestedQuantity))
                .WithIdentity(Identities.OneUser)
                .GetAsync();
            await response.ShouldBe(StatusCodes.Status200OK);

            var result = await response.ReadJsonResponse<IEnumerable<NameViewModel>>();
            result.Count().Should().Be(requestedQuantity);
        }

        [Fact]
        public async Task Obtain_120_female_names()
        {
            int requestedQuantity = 120;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetMujeres(requestedQuantity))
                .WithIdentity(Identities.OneUser)
                .GetAsync();
            await response.ShouldBe(StatusCodes.Status200OK);

            var result = await response.ReadJsonResponse<IEnumerable<NameViewModel>>();
            result.Count().Should().BeInRange(requestedQuantity - 10, requestedQuantity + 10);
            result.All(x => x.Gender.Equals(Gender.Female.ToString())).Should().BeTrue();
        }

        [Fact]
        public async Task Obtain_114_male_names()
        {
            int requestedQuantity = 114;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetHombres(requestedQuantity))
                .WithIdentity(Identities.OneUser)
                .GetAsync();
            await response.ShouldBe(StatusCodes.Status200OK);

            var result = await response.ReadJsonResponse<IEnumerable<NameViewModel>>();
            result.Count().Should().BeInRange(requestedQuantity - 10, requestedQuantity + 10);
            result.All(x => x.Gender.Equals(Gender.Male.ToString())).Should().BeTrue();
        }
    }
}
