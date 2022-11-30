using System.Collections.Generic;

namespace AdventShared
{
    public static class ListExtensions
    {
        public static List<T> Copy<T>(this List<T> original)
        {
            var result = new List<T>();
            foreach (var item in original)
            {
                result.Add(item);
            }

            return result;
        }

        public static List<T> IntoList<T>(this T original)
        {
            return new List<T> {original};
        }
    }
}