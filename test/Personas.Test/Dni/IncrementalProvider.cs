using Personas.Core;

namespace Personas.Test
{
    public class IncrementalProvider : IRandomProvider
    {
        int x = 0;
        public int GetNumber(int minimun, int maximun)
        {
            if (x == 9) x = 0; else x++;
            return x;
        }
    }
}
