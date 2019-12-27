using System;

namespace Personas.Core
{
    public class QuantityUnderHundredException : Exception
    {
        public QuantityUnderHundredException(int quantity) : base($"Requested quantity {quantity} is lower than required minimun quantity (100)")
        {
        }
    }

    public static class QuantityUnderHundredHelper
    {
        public static void ThrowWhenLowerThan100(this int quantity)
        {
            if (quantity < 100)
                throw new QuantityUnderHundredException(quantity);
        }
    }
}
