using Personas.Core;

namespace Personas.Test
{
    public class TestRandomProvider : IRandomProvider
    {
        public int GetNumber(int minimun, int maximun)
        {
            return 1;
        }
    }
}
