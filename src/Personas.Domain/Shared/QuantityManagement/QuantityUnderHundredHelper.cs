namespace Personas.Domain
{
    public static class QuantityUnderHundredHelper
    {
        public static void EnsureQuantityIsInValidRange(this int quantity)
        {
            if (quantity < 100)
            {
                throw new QuantityUnderHundredException(quantity);
            }

            if (quantity > QuantityOverMaximunLimitException.MaximunLimit)
            {
                throw new QuantityOverMaximunLimitException(quantity);
            }
        }
    }
}
