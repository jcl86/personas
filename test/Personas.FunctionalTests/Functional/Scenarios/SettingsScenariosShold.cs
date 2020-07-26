using Microsoft.Extensions.Configuration;
using System;
using Xunit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System.IO;
using Personas.Api;
using FluentAssertions;
using System.Linq;
using Personas.Domain;
using System.Collections.Generic;
using System.Diagnostics;

namespace Personas.FunctionalTests
{
    [Collection(nameof(ServerFixtureCollection))]
    public class SettingsScenariosShold
    {
        private readonly ServerFixture Given;

        public SettingsScenariosShold(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        [Fact]
        public void Should_check_settings()
        {
            var configuration = Given.Configuration;
            string apiKeyValue = configuration.GetValue<string>(TokenGenerator.ApiKeyConfigurationName);
            apiKeyValue.Should().Be("1234567890abcdefhijklmnopqrstuvwxyz12345");
        }

        [Fact(Skip ="Not neccesary")]
        public void Create_super_secure_password()
        {
            var randomProvider = new RandomProvider(new Random());

            var list = new List<string>()
            {
                "0123456789",
                "ABZDEFGHIJKLMNOPQRSTUVWXYZ",
                "abcdefghijklmnopqrstuvwxyz",
                "@#$%&*"
            };

            var password = Enumerable.Range(0, 3).SelectMany(i => Enumerable.Range(0, 40).Select(x => list[i].RandomElement(randomProvider))).RandomizeList(randomProvider);
            Debug.WriteLine(string.Concat(password));
        }
    }
}
