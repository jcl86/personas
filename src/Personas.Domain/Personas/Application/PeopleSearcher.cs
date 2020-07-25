using Personas.Application;
using Personas.Domain;
using Personas.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public class PeopleSearcher
    {
        private readonly NameSearcher nameSearcher;
        private readonly SurnameSearcher surnameSearcher;
        private readonly PlaceSearcher placeSearcher;
        private readonly RandomProvider randomProvider;
        private readonly IDateProvider dateProvider;

        public PeopleSearcher(NameSearcher nameSearcher, SurnameSearcher surnameSearcher, PlaceSearcher placeSearcher,
            RandomProvider randomProvider, IDateProvider dateProvider)
        {
            this.nameSearcher = nameSearcher;
            this.surnameSearcher = surnameSearcher;
            this.placeSearcher = placeSearcher;
            this.randomProvider = randomProvider;
            this.dateProvider = dateProvider;
        }

        public async Task<IEnumerable<Person>> SearchPeople(int quantity, Province? province = null, AutonomousCommunity? region = null, Gender gender = null)
        {
            quantity.EnsureQuantityIsEqualOrHigerThan100();

            var names = (await nameSearcher.Search(quantity, gender)).ToList();
            var surnames = (await surnameSearcher.Search(quantity)).ToList();
            var places = (await placeSearcher.Search(quantity, province, region)).ToList();

            var people = new List<Person>();
            foreach (var _ in Enumerable.Range(0, quantity))
            {
                var firstName = names.RandomElement(randomProvider);
                names.Remove(firstName);

                var middleName = surnames.RandomElement(randomProvider);
                surnames.Remove(middleName);

                var lastName = surnames.RandomElement(randomProvider);
                surnames.Remove(lastName);

                var place = places.RandomElement(randomProvider);
                places.Remove(place);

                var birthDate = dateProvider.GetRandomBirthDate(randomProvider);

                var idCardNumber = new IdCard(randomProvider).ToString();

                people.Add(new Person(firstName, middleName, lastName, gender,
                    place, birthDate, idCardNumber));
            }
            return people;
        }
    }
}
