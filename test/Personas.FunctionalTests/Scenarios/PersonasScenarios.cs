using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Personas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Personas.FunctionalTests
{
    [Collection(nameof(ServerFixtureCollection))]
    public class PersonasScenarios
    {
        private readonly ServerFixture Given;
        private readonly PersonasEndpoint endpoint;

        public PersonasScenarios(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
            endpoint = Endpoint.Personas;
        }

        [Fact]
        public async Task Should_obtain_253_personas()
        {
            int cantidadSolicitada = 253;

            var response = await Given
                .Server
                .CreateRequest(endpoint.Get(cantidadSolicitada))
                .WithApiKeyHeader()
                .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<PersonaViewModel>>(json);

            result.Count().Should().Be(cantidadSolicitada);
        }

        [Fact]
        public async Task Should_obtain_3000_personas()
        {
            int cantidadSolicitada = 3000;

            var response = await Given
                .Server
                .CreateRequest(endpoint.Get(cantidadSolicitada))
                .WithApiKeyHeader()
                .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<PersonaViewModel>>(json);

            result.Count().Should().Be(cantidadSolicitada);
        }

        [Fact]
        public async Task Should_obtain_140_mujeres()
        {
            int cantidadSolicitada = 140;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetMujeres(cantidadSolicitada))
                .WithApiKeyHeader()
                .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<PersonaViewModel>>(json);

            result.Count().Should().Be(cantidadSolicitada);
            result.Select(x => x.Sexo.Should().Be(Genero.Female.ToString()));
        }

        [Fact]
        public async Task Should_obtain_210_hombres()
        {
            int cantidadSolicitada = 210;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetHombres(cantidadSolicitada))
                .WithApiKeyHeader()
                .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<PersonaViewModel>>(json);

            result.Count().Should().Be(cantidadSolicitada);
            result.Select(x => x.Sexo.Should().Be(Genero.Male.ToString()));
        }

        [Fact]
        public async Task Should_obtain_100_tarraconenses()
        {
            int cantidadSolicitada = 100;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetFromProvincia(Provincia.Tarragona.ToString(), cantidadSolicitada))
                .WithApiKeyHeader()
                .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<PersonaViewModel>>(json);

            result.Count().Should().Be(cantidadSolicitada);
            result.Select(x => x.Origen.Provincia.Should().Be("Tarragona"));
        }

        [Fact]
        public async Task Should_obtain_340_mujeres_gipuzkoanas()
        {
            int cantidadSolicitada = 340;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetMujeresFromProvincia(Provincia.Gipuzkoa.ToString(), cantidadSolicitada))
                .WithApiKeyHeader()
                .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<PersonaViewModel>>(json);

            result.Count().Should().Be(cantidadSolicitada);
            result.Select(x => x.Sexo.Should().Be(Genero.Female.ToString()));
            result.Select(x => x.Origen.Provincia.Should().Be("Gipuzkoa"));
        }


        [Fact]
        public async Task Should_obtain_100_hombres_riojanos()
        {
            int cantidadSolicitada = 100;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetHombres(cantidadSolicitada))
                .WithApiKeyHeader()
                .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<PersonaViewModel>>(json);

            result.Count().Should().Be(cantidadSolicitada);
            result.Select(x => x.Sexo.Should().Be(Genero.Male.ToString()));
            result.Select(x => x.Origen.Provincia.Should().Be("La Rioja"));
        }

        [Fact]
        public async Task Should_obtain_150_aragoneses()
        {
            int cantidadSolicitada = 150;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetFromRegion(Comunidad.Aragon.ToString(), cantidadSolicitada))
                .WithApiKeyHeader()
                .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<PersonaViewModel>>(json);

            result.Count().Should().Be(cantidadSolicitada);
            result.Select(x => x.Origen.Region.Nombre.Should().Be("Aragón"));
        }

        [Fact]
        public async Task Should_obtain_220_mujeres_manchegas()
        {
            int cantidadSolicitada = 220;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetMujeresFromRegion(Comunidad.Castillalamancha.ToString(), cantidadSolicitada))
                .WithApiKeyHeader()
                .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<PersonaViewModel>>(json);

            result.Count().Should().Be(cantidadSolicitada);
            result.Select(x => x.Sexo.Should().Be(Genero.Female.ToString()));
            result.Select(x => x.Origen.Provincia.Should().Be("Castilla - La Mancha"));
        }


        [Fact]
        public async Task Should_obtain_400_hombres_gallegos()
        {
            int cantidadSolicitada = 400;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetHombresFromRegion(Comunidad.Galicia.ToString(), cantidadSolicitada))
                .WithApiKeyHeader()
                .GetAsync();
            var xxx = await response.Content.ReadAsStringAsync();
            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<PersonaViewModel>>(json);

            result.Count().Should().Be(cantidadSolicitada);
            result.Select(x => x.Sexo.Should().Be(Genero.Male.ToString()));
            result.Select(x => x.Origen.Region.Nombre.Should().Be("Galicia"));
        }


        [Fact]
        public async Task Should_not_find_provincia()
        {
            var response = await Given
                .Server
                .CreateRequest(endpoint.GetFromProvincia(Comunidad.Galicia.ToString(), 100))
                .WithApiKeyHeader()
                .GetAsync();

            var json = await response.Content.ReadAsStringAsync();
            response.StatusCode.Should().Be(StatusCodes.Status404NotFound);

            response = await Given
            .Server
            .CreateRequest(endpoint.GetFromProvincia("provinciaEquivocada", 100))
            .WithApiKeyHeader()
            .GetAsync();

            json = await response.Content.ReadAsStringAsync();
            response.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }


        [Fact]
        public async Task Should_not_find_region()
        {
            var response = await Given
                .Server
                .CreateRequest(endpoint.GetFromRegion(Provincia.Lugo.ToString(), 100))
                .WithApiKeyHeader()
                .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status404NotFound);

            var json = await response.Content.ReadAsStringAsync();

            response = await Given
            .Server
            .CreateRequest(endpoint.GetFromRegion("regionEquivocada", 100))
            .WithApiKeyHeader()
            .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status404NotFound);

            json = await response.Content.ReadAsStringAsync();

        }
    }
}
