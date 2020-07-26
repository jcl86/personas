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
    public class PlacesScenariosShould
    {
        private readonly ServerFixture Given;
        private readonly PlacesEndpoint endpoint = Endpoints.Places;

        public PlacesScenariosShould(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        [Fact]
        public async Task Obtain_500_places()
        {
            int requestedQuantity = 500;

            var response = await Given
                .Server
                .CreateRequest(endpoint.Get(requestedQuantity))
                .WithIdentity(Identities.OneUser)
                .GetAsync();

            await response.ShouldBe(StatusCodes.Status200OK);

            var result = await response.ReadJsonResponse<IEnumerable<PlaceViewModel>>();
            result.Count().Should().Be(requestedQuantity);
        }

        [Fact]
        public async Task Obtain_40_places_from_Murcia()
        {
            int requestedQuantity = 40;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetFromProvincia("murcia", requestedQuantity))
                .WithIdentity(Identities.OneUser)
                .GetAsync();

            await response.ShouldBe(StatusCodes.Status200OK);

            var result = await response.ReadJsonResponse<IEnumerable<PlaceViewModel>>();
            result.Count().Should().BeCloseTo(requestedQuantity, 5);
            result.All(x => x.Province.Equals("Murcia")).Should().BeTrue();
        }

        [Fact]
        public async Task Obtain_81_lugares_from_La_Mancha()
        {
            int requestedQuantity = 81;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetFromRegion("castillaLaMancha", requestedQuantity))
                .WithIdentity(Identities.OneUser)
                .GetAsync();

            await response.ShouldBe(StatusCodes.Status200OK);

            var result = await response.ReadJsonResponse<IEnumerable<PlaceViewModel>>();
            result.Count().Should().BeCloseTo(requestedQuantity, 10);
            result.All(x => x.Region.Name.Equals("Castilla - La Mancha")).Should().BeTrue();
        }
    }
}
