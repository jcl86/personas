using System.Collections.Generic;
using System.Threading.Tasks;
using Personas.Domain;

namespace Personas.Domain
{
    public interface IPlacesRepository
    {
        Task<IEnumerable<Place>> GetAllPlaces();
        Task<IEnumerable<Place>> GetPlaces(AutonomousCommunity region);
        Task<IEnumerable<Place>> GetPlaces(Province provincia);
    }
}