using System.Collections.Generic;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public interface ISurnamesRepository
    {
        Task<List<IEnumerable<Surname>>> GetSurnamesCompleteList(Culture culture = Culture.Spanish);
    }
}
