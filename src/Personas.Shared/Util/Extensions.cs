using System.ComponentModel;
using System.Reflection;

namespace System
{
    public static class Extensions
    {
        public static bool IsEmpty(this string text) => string.IsNullOrWhiteSpace(text);

        public static bool IsValidEmailAddress(this string email)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(email);
        }

        public static string Description<T>(this T source) where T : Enum
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
    }
}
