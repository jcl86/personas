using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Personas.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Personas.FunctionalTests
{
    [Collection(nameof(ServerFixtureCollection))]
    public class LugaresScenarios
    {
        private readonly ServerFixture Given;
        private readonly LugaresEndpoint endpoint;

        public LugaresScenarios(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
            endpoint = Endpoint.Lugares;
        }

        [Fact]
        public async Task Should_obtain_500_lugares()
        {
            int cantidadSolicitada = 500;

            var response = await Given
                .Server
                .CreateRequest(endpoint.Get(cantidadSolicitada))
                .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<LugarViewModel>>(json);

            result.Count().Should().Be(cantidadSolicitada);
        }

        [Fact]
        public async Task Should_obtain_40_lugares_from_murcia()
        {
            int cantidadSolicitada = 40;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetFromProvincia("murcia", cantidadSolicitada))
                .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<LugarViewModel>>(json);

            result.Count().Should().Be(cantidadSolicitada);
            result.All(x => x.Provincia.Equals("Murcia")).Should().BeTrue();
        }

        [Fact]
        public async Task Should_obtain_142_lugares_from_la_mancha()
        {
            int cantidadSolicitada = 142;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetFromRegion("castillaLaMancha", cantidadSolicitada))
                .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<LugarViewModel>>(json);

            result.Count().Should().Be(cantidadSolicitada);
            result.All(x => x.Region.Nombre.Equals("Región de Murcia")).Should().BeTrue();
        }
    }
}
