using System;
using System.ComponentModel;
using System.Reflection;

namespace Personas.Core
{
    public static class Extensions
    {
        public static string Descripcion<T>(this T source) where T : Enum
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }

        public static bool IsEmpty(this string text) => string.IsNullOrWhiteSpace(text);
        
    }
}
