using System.Collections.Generic;
using System.Threading.Tasks;
using Personas.Domain;

namespace Personas.Domain
{
    public interface IPlacesRepository
    {
        Task<IEnumerable<Place>> GetAllPlaces();
        Task<List<IEnumerable<Place>>> GetPlaces(Province? provincia, AutonomousCommunity? region, int countryId = 1);
    }
}