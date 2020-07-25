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
            int quantity = 100;

            var response = await Given
                .Server
                .CreateRequest(endpoint.Get(quantity))
                .GetAsync();

            await response.ShouldBe(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<SurnameViewModel>>(json);

            result.Count().Should().Be(quantity);
        }

        [Fact]
        public async Task Fail_to_obtain_less_than_100()
        {
            int cantidadSolicitada = 90;

            var response = await Given
                .Server
                .CreateRequest(endpoint.Get(cantidadSolicitada))
                .GetAsync();

            await response.ShouldBe(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task Fail_to_obtain_requests_without_api_key()
        {
            int cantidadSolicitada = 100;

            var response = await Given
                .Server
                .CreateRequest(endpoint.Get(cantidadSolicitada))
                .GetAsync();

            await response.ShouldBe(StatusCodes.Status401Unauthorized);
        }
    }
}
