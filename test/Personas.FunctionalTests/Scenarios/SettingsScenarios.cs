using Microsoft.Extensions.Configuration;
using System;
using Xunit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System.IO;
using Personas.Api;
using FluentAssertions;

namespace Personas.FunctionalTests
{
    [Collection(nameof(ServerFixtureCollection))]
    public class SettingsScenarios
    {
        private readonly ServerFixture Given;

        public SettingsScenarios(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        [Fact]
        public void Should_check_settings()
        {
            var configuration = Given.Configuration;
            string apiKeyValue = configuration.GetValue<string>(key: ApiKeyAuthAttribute.ApiKeyConfigurationName);
            apiKeyValue.Should().Be("1234");
        }
    }
}
