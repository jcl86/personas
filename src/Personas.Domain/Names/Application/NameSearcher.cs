using Personas.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public class NameSearcher
    {
        private readonly INamesRepository repository;
        private readonly RandomProvider randomProvider;

        public NameSearcher(INamesRepository repository, RandomProvider randomProvider)
        {
            this.repository = repository;
            this.randomProvider = randomProvider;
        }

        public async Task<IEnumerable<Name>> Search(int quantity, Gender gender)
        {
            quantity.EnsureQuantityIsInValidRange();

            var nameList = await repository.GetNamesCompleteList(gender);

            double[] distribucion = { 0.33, 0.33, 0.18, 0.10, 0.04, 0.02 };

            var result = new List<Name>();
            for (int i = 0; i < distribucion.Length; i++)
            {
                for (int j = 0; j < quantity * distribucion[i]; j++)
                {
                    result.Add(nameList[i].RandomElement(randomProvider));
                }
            }
            return result;
        }
    }
}
