using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluraLeecher
{
    public static class StringExtensions
    {
        public static string DeleteIllegalCharacters(this string value)
        {
            return value.Replace(":", " ").Replace("?", "").Replace(",", "");
        }
    }
}
