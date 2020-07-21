﻿using FluentAssertions;
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
            var result = JsonConvert.DeserializeObject<IEnumerable<PlaceViewModel>>(json);

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
            var result = JsonConvert.DeserializeObject<IEnumerable<PlaceViewModel>>(json);

            result.Count().Should().BeInRange(cantidadSolicitada - 10, cantidadSolicitada + 10);
            result.All(x => x.Province.Equals("Murcia")).Should().BeTrue();
        }

        [Fact]
        public async Task Should_obtain_81_lugares_from_la_mancha()
        {
            int cantidadSolicitada = 81;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetFromRegion("castillaLaMancha", cantidadSolicitada))
                .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<PlaceViewModel>>(json);

            result.Count().Should().BeInRange(cantidadSolicitada - 20, cantidadSolicitada + 20);
            result.All(x => x.Region.Name.Equals("Castilla - La Mancha")).Should().BeTrue();
        }
    }
}
