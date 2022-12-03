using System.Collections.Generic;
using System.Linq;

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

        public static List<T> FindDupes<T>(this List<T> list1, List<T> list2)
        {
            var dupeList = new List<T>();
            foreach (var item in list1.GroupBy(x => x))
            {
                if (list2.Contains(item.Key))
                {
                    dupeList.Add(item.Key);
                }
            }

            return dupeList;
        }
    }
}