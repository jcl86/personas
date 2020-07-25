using FluentAssertions;
using Microsoft.AspNetCore.Http;
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
                .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<PlaceViewModel>>(json);

            result.Count().Should().Be(requestedQuantity);
        }

        [Fact]
        public async Task Obtain_40_places_from_Murcia()
        {
            int requestedQuantity = 40;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetFromProvincia("murcia", requestedQuantity))
                .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<PlaceViewModel>>(json);

            result.Count().Should().BeInRange(requestedQuantity - 10, requestedQuantity + 10);
            result.All(x => x.Province.Equals("Murcia")).Should().BeTrue();
        }

        [Fact]
        public async Task Obtain_81_lugares_from_La_Mancha()
        {
            int requestedQuantity = 81;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetFromRegion("castillaLaMancha", requestedQuantity))
                .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<PlaceViewModel>>(json);

            result.Count().Should().BeInRange(requestedQuantity - 20, requestedQuantity + 20);
            result.All(x => x.Region.Name.Equals("Castilla - La Mancha")).Should().BeTrue();
        }
    }
}
