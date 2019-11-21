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
    public class ApellidosScenarios
    {
        private readonly ServerFixture Given;
        private readonly ApellidosEndpoint endpoint;

        public ApellidosScenarios(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
            endpoint = Endpoint.Apellidos;
        }

        [Fact]
        public async Task Should_obtain_100_apellidos()
        {
            int cantidaSolicitada = 100;

            var response = await Given
                .Server
                .CreateRequest(endpoint.Get(cantidaSolicitada))
                .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<ApellidoViewModel>>(json);

            result.Count().Should().Be(cantidaSolicitada);
        }
    }
}
