using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Personas.FunctionalTests
{
    public class ApellidosScenarios
    {
        private readonly ServerFixture Given;

        public ApellidosScenarios(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        [Fact]
        public async Task prueba()
        {
            var response = await Given
                .Server
                .CreateRequest("api/lugares/hola")
                .GetAsync();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<string>(json);

            response.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}
