using System.Collections.Generic;
using System.Linq;

namespace AdventShared
{
    public static class StringExtensions
    {
        public static bool IsDistinctSubstringForLength(this string buffer, int index, int length)
        {
            return buffer.Substring(index, length).Distinct().Count() == length;
        }
    }
}