namespace PluraLeecher
{
    public static class StringExtensions
    {
        public static string DeleteIllegalCharacters(this string value)
        {
            return value.Replace(":", " ").Replace("?", "").Replace(",", "");
        }
        public static string RemoveSlashAndBackSlash(this string value)
        {
            return value.Replace(@"\", "-").Replace(@"/", "-");
        }
    }
}
