using Personas.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public interface INamesRepository
    {
        Task<List<IEnumerable<Name>>> GetNamesCompleteList(Gender gender = null, Culture culture = Culture.Spanish);
    }
}
