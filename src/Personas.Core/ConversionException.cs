using System;

namespace Personas.Core
{
    public class ConversionException : Exception
    {
        public ConversionException(string textToConvert, string enumName) : base($"Could not convert {textToConvert} to {enumName}")
        {
        }
    }
}
