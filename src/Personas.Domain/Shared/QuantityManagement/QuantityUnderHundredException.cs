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
}
