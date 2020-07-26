namespace Personas.Domain
{
    public class QuantityOverMaximunLimitException : DomainException
    {
        public const int MaximunLimit = 10000;

        private readonly int quantity;

        public QuantityOverMaximunLimitException(int quantity)
        {
            this.quantity = quantity;
        }

        public override string Message => $"Requested quantity {quantity} is over maximun limit ({MaximunLimit})";
    }
}
