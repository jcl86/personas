using System;

namespace Personas.Core
{
    public class EnumConverter<TEnum> where TEnum : struct
    {
        private readonly string nombre;

        public EnumConverter(string nombre)
        {
            this.nombre = nombre?.ToLower() ?? throw new ArgumentNullException(nameof(nombre));

            this.nombre = this.nombre
                .Replace("ñ", "n")
                .Replace("á", "a")
                .Replace("é", "e")
                .Replace("í", "i")
                .Replace("ó", "o")
                .Replace("ú", "u")
                .Replace(" ", "");
        }

        public TEnum Convert()
        {
            if (Enum.TryParse(nombre, out TEnum result))
                return result;

            throw new ArgumentOutOfRangeException($"{nombre} no se pudo convertir en {typeof(TEnum)}");
        }
    }
}
