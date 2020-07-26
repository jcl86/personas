using System;

namespace Personas.Domain
{
    public class ConversionException : DomainException
    {
        private readonly string textToConvert;
        private readonly string enumName;

        public ConversionException(string textToConvert, string enumName) : base()
        {
            this.textToConvert = textToConvert;
            this.enumName = enumName;
        }

        public override string Message => $"Could not convert {textToConvert} to {enumName}";
    }
}
