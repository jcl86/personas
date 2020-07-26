using Personas.Domain;
using Personas.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personas.Application
{
    public class SurnameSearcher
    {
        private readonly ISurnamesRepository repository;
        private readonly RandomProvider randomProvider;

        public SurnameSearcher(ISurnamesRepository repository, RandomProvider randomProvider)
        {
            this.repository = repository;
            this.randomProvider = randomProvider;
        }

        public async Task<IEnumerable<Surname>> Search(int quantity)
        {
            quantity.EnsureQuantityIsInValidRange();

            var surnameList = await repository.GetSurnamesCompleteList();

            double[] distribucion = { 0.37, 0.25, 0.17, 0.11, 0.05, 0.05 };

            var result = new List<Surname>();
            for (int i = 0; i < distribucion.Length; i++)
            {
                for (int j = 0; j < quantity * distribucion[i]; j++)
                {
                    result.Add(surnameList[i].RandomElement(randomProvider));
                }
            }
            return result;
        }
    }
}
