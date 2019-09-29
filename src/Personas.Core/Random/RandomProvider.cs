using System;

namespace Personas.Core
{
    public class RandomProvider : IRandomProvider
    {
        private readonly Random random;

        public RandomProvider(Random random)
        {
            this.random = random;
        }

        public int GetNumber(int minimun, int maximun) => random.Next(minimun, maximun + 1);
    }
}
