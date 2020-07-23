namespace Personas.Shared
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string text) => string.IsNullOrWhiteSpace(text);

        public static bool IsValidEmailAddress(this string email)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(email);
        }
    }
}
