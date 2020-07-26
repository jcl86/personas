using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
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
    public class PeopleScenariosShould
    {
        private readonly ServerFixture Given;
        private readonly PeopleEndpoint endpoint = Endpoints.People;

        public PeopleScenariosShould(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        [Fact]
        public async Task Obtain_253_people()
        {
            int requestedQuantity = 253;

            var response = await Given
                .Server
                .CreateRequest(endpoint.Get(requestedQuantity))
                .WithIdentity(Identities.OneUser)
                .GetAsync();
            await response.ShouldBe(StatusCodes.Status200OK);

            var result = await response.ReadJsonResponse<IEnumerable<PersonViewModel>>();
            result.Count().Should().Be(requestedQuantity);
        }

        [Fact]
        public async Task Obtain_3000_people()
        {
            int requestedQuantity = 3000;

            var response = await Given
                .Server
                .CreateRequest(endpoint.Get(requestedQuantity))
                .WithIdentity(Identities.OneUser)
                .GetAsync();
            await response.ShouldBe(StatusCodes.Status200OK);

            var result = await response.ReadJsonResponse<IEnumerable<PersonViewModel>>();
            result.Count().Should().Be(requestedQuantity);
        }

        [Fact]
        public async Task Obtain_140_women()
        {
            int requestedQuantity = 140;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetWomen(requestedQuantity))
                .WithIdentity(Identities.OneUser)
                .GetAsync();

            await response.ShouldBe(StatusCodes.Status200OK);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<PersonViewModel>>(json);

            result.Count().Should().Be(requestedQuantity);
            result.Select(x => x.Gender.Should().Be(Gender.Female.ToString()));
        }

        [Fact]
        public async Task Obtain_210_men()
        {
            int requestedQuantity = 210;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetMen(requestedQuantity))
                .WithIdentity(Identities.OneUser)
                .GetAsync();
            await response.ShouldBe(StatusCodes.Status200OK);

            var result = await response.ReadJsonResponse<IEnumerable<PersonViewModel>>();
            result.Count().Should().Be(requestedQuantity);
            result.Select(x => x.Gender.Should().Be(Gender.Male.ToString()));
        }

        [Fact]
        public async Task Obtain_100_people_from_Tarragona()
        {
            int requestedQuantity = 100;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetFromProvince(Province.Tarragona.ToString(), requestedQuantity))
                .WithIdentity(Identities.OneUser)
                .GetAsync();
            await response.ShouldBe(StatusCodes.Status200OK);

            var result = await response.ReadJsonResponse<IEnumerable<PersonViewModel>>();
            result.Count().Should().Be(requestedQuantity);
            result.Select(x => x.Place.Province.Should().Be("Tarragona"));
        }

        [Fact]
        public async Task Obtain_340_women_from_Gipuzkoa()
        {
            int requestedQuantity = 340;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetWomenFromProvince(Province.Gipuzkoa.ToString(), requestedQuantity))
                .WithIdentity(Identities.OneUser)
                .GetAsync();
            await response.ShouldBe(StatusCodes.Status200OK);

            var result = await response.ReadJsonResponse<IEnumerable<PersonViewModel>>();
            result.Count().Should().Be(requestedQuantity);
            result.Select(x => x.Gender.Should().Be(Gender.Female.ToString()));
            result.Select(x => x.Place.Province.Should().Be("Gipuzkoa"));
        }


        [Fact]
        public async Task Obtain_100_men_from_La_rioja()
        {
            int requestedQuantity = 100;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetMen(requestedQuantity))
                .WithIdentity(Identities.OneUser)
                .GetAsync();
            await response.ShouldBe(StatusCodes.Status200OK);

            var result = await response.ReadJsonResponse<IEnumerable<PersonViewModel>>();
            result.Count().Should().Be(requestedQuantity);
            result.Select(x => x.Gender.Should().Be(Gender.Male.ToString()));
            result.Select(x => x.Place.Province.Should().Be("La Rioja"));
        }

        [Fact]
        public async Task Obtain_150_people_from_Aragon()
        {
            int requestedQuantity = 150;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetFromRegion(AutonomousCommunity.Aragon.ToString(), requestedQuantity))
                .WithIdentity(Identities.OneUser)
                .GetAsync();
            await response.ShouldBe(StatusCodes.Status200OK);

            var result = await response.ReadJsonResponse<IEnumerable<PersonViewModel>>();
            result.Count().Should().Be(requestedQuantity);
            result.Select(x => x.Place.Region.Name.Should().Be("Aragón"));
        }

        [Fact]
        public async Task Obtain_220_women_from_La_Mancha()
        {
            int requestedQuantity = 220;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetWomenFromRegion(AutonomousCommunity.Castillalamancha.ToString(), requestedQuantity))
                .WithIdentity(Identities.OneUser)
                .GetAsync();
            await response.ShouldBe(StatusCodes.Status200OK);

            var result = await response.ReadJsonResponse<IEnumerable<PersonViewModel>>();
            result.Count().Should().Be(requestedQuantity);
            result.Select(x => x.Gender.Should().Be(Gender.Female.ToString()));
            result.Select(x => x.Place.Province.Should().Be("Castilla - La Mancha"));
        }

        [Fact]
        public async Task Obtain_400_men_from_Galicia()
        {
            int requestedQuantity = 400;

            var response = await Given
                .Server
                .CreateRequest(endpoint.GetMenFromRegion(AutonomousCommunity.Galicia.ToString(), requestedQuantity))
                .WithIdentity(Identities.OneUser)
                .GetAsync();
            await response.ShouldBe(StatusCodes.Status200OK);

            var result = await response.ReadJsonResponse<IEnumerable<PersonViewModel>>();
            result.Count().Should().Be(requestedQuantity);
            result.Select(x => x.Gender.Should().Be(Gender.Male.ToString()));
            result.Select(x => x.Place.Region.Name.Should().Be("Galicia"));
        }


        [Fact]
        public async Task Not_find_province()
        {
            var response = await Given
                .Server
                .CreateRequest(endpoint.GetFromProvince(AutonomousCommunity.Galicia.ToString(), 100))
                .WithIdentity(Identities.OneUser)
                .GetAsync();
            await response.ShouldBe(StatusCodes.Status400BadRequest);

            response = await Given
                .Server
                .CreateRequest(endpoint.GetFromProvince("wrongProvince", 100))
                .WithIdentity(Identities.OneUser)
                .GetAsync();
            await response.ShouldBe(StatusCodes.Status400BadRequest);
        }


        [Fact]
        public async Task Not_find_region()
        {
            var response = await Given
                .Server
                .CreateRequest(endpoint.GetFromRegion(Province.Lugo.ToString(), 100))
                .WithIdentity(Identities.OneUser)
                .GetAsync();
            await response.ShouldBe(StatusCodes.Status400BadRequest);

            response = await Given
                .Server
                .CreateRequest(endpoint.GetFromRegion("wrongRegion", 100))
                .WithIdentity(Identities.OneUser)
                .GetAsync();
            await response.ShouldBe(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task Fail_to_obtain_people_when_user_is_not_authenticated()
        {
            var response = await Given
                .Server
                .CreateRequest(endpoint.Get(100))
                .GetAsync();
            await response.ShouldBe(StatusCodes.Status401Unauthorized);
        }
    }
}
