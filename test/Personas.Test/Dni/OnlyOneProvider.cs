using Personas.Core;

namespace Personas.Test
{
    public class OnlyOneProvider : IRandomProvider
    {
        public int GetNumber(int minimun, int maximun)
        {
            return 1;
        }
    }
}
