using System;

namespace Personas.Domain
{
    public class QuantityUnderHundredException : DomainException
    {
        private readonly int quantity;

        public QuantityUnderHundredException(int quantity)
        {
            this.quantity = quantity;
        }

        public override string Message => $"Requested quantity {quantity} is lower than required minimun quantity (100)";
    }

    public static class QuantityUnderHundredHelper
    {
        public static void EnsureQuantityIsEqualOrHigerThan100(this int quantity)
        {
            if (quantity < 100)
                throw new QuantityUnderHundredException(quantity);
        }
    }
}
