﻿using FluentAssertions;
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
    public class NombresScenarios
    {
        private readonly ServerFixture Given;
        private readonly NombresEndpoint endpoint;

        public NombresScenarios(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
            endpoint = Endpoint.Nombres;
        }

        [Fact]
        public async Task Should_obtain_100_nombres()
        {
            int cantidadSolicitada = 100;

            var response = await Given
                .Server
                .CreateRequest(endpoint.Get(cantidadSolicitada))
                .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<NombreViewModel>>(json);

            result.Count().Should().Be(cantidadSolicitada);
        }

        [Fact]
        public async Task Should_obtain_120_nombres_femeninos()
        {
            int cantidadSolicitada = 120;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetMujeres(cantidadSolicitada))
                .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<NombreViewModel>>(json);

            result.Count().Should().Be(cantidadSolicitada);
            result.All(x => x.Genero.Equals(Genero.Female.ToString())).Should().BeTrue();
        }

        [Fact]
        public async Task Should_obtain_114_nombres_masculinos()
        {
            int cantidadSolicitada = 114;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetHombres(cantidadSolicitada))
                .GetAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<NombreViewModel>>(json);

            result.Count().Should().Be(cantidadSolicitada);
            result.All(x => x.Genero.Equals(Genero.Male.ToString())).Should().BeTrue();
        }
    }
}