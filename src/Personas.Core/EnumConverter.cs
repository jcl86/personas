using System;
using System.Linq;

namespace Personas.Core
{
    public class EnumConverter<TEnum> where TEnum : struct
    {
        private readonly string nombre;

        public EnumConverter(string nombre)
        {
            this.nombre = nombre?.ToLower() ?? throw new ArgumentNullException(nameof(nombre));

            if (this.nombre.Trim().Length < 2)
                throw new ArgumentException($"{nombre} es demasiado corto para poder ser convertido a {typeof(TEnum)}");

            this.nombre = this.nombre
                .Replace("ñ", "n")
                .Replace("á", "a")
                .Replace("é", "e")
                .Replace("í", "i")
                .Replace("ó", "o")
                .Replace("ú", "u")
                .Replace(" ", "");

            this.nombre = $"{this.nombre.First().ToString().ToUpper()}{this.nombre.Substring(1)}";
        }

        public TEnum Convert()
        {
            if (Enum.TryParse(nombre, out TEnum result))
                return result;

            throw new ConversionException(nombre, nameof(TEnum));
        }
    }
}
