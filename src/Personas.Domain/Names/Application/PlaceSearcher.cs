using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public class PlaceSearcher
    {
        private readonly IPlacesRepository placesRepository;
        private readonly RandomProvider randomProvider;

        public PlaceSearcher(IPlacesRepository placesRepository, RandomProvider randomProvider)
        {
            this.placesRepository = placesRepository;
            this.randomProvider = randomProvider;
        }

        public async Task<IEnumerable<Place>> Search(int quantity, Province? province, AutonomousCommunity? region)
        {
            var placeList = await placesRepository.GetPlaces(province, region);
            var distribution = new List<double>() { 0.45, 0.20, 0.20, 0.10, 0.05 };
            distribution = distribution.Where(x => placeList[distribution.IndexOf(x)].Any()).ToList();
            placeList.RemoveAll(x => !x.Any());

            var result = new List<Place>();
            for (int i = 0; i < distribution.Count; i++)
            {
                for (int j = 0; j < quantity * distribution[i]; j++)
                {
                    var place = placeList[i].RandomElement(randomProvider);
                    result.Add(place);
                }
            }
            return result;
        }


        public async Task<IEnumerable<Place>> Search(int quantity)
        {
            var placeList = (await placesRepository.GetAllPlaces()).ToList();

            var result = new List<Place>();
            for (int i = 0; i < quantity; i++)
            {
                var place = placeList.RandomElement(randomProvider);
                placeList.Remove(place);
                result.Add(place);
            }
            return result;
        }
    }
}
