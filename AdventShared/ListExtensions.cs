﻿using System.Collections.Generic;
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
        
        public static List<T> CopyValues<T>(this List<T> values)
        {
            var result = new List<T>();
            for (var i = 0; i < values.Count; i++)
            {
                result.Add(values[i]);
            }

            return result;
        }
        
        public static List<List<T>> CopyValues<T>(this List<List<T>> values)
        {
            var result = new List<List<T>>();
            for (var i = 0; i < values.Count; i++)
            {
                result.Add(values[i].CopyValues());
            }

            return result;
        }
        
        public static void ShiftRight<T>(this List<T> list)
        {
            var lastItem = list.Last();
            for (var i = list.Count - 1; i > 0; i--)
            {
                list[i] = list[i - 1];
            }

            list[0] = lastItem;
        }
        
        public static int GetCommonProduct(this List<int> list)
        {
            return list.Aggregate(1, (current, item) => current * item);
        }

        public static bool IsWithinMap(this List<string> map, int targetRow, int targetColumn)
        {
            return targetRow >= 0 ||
                   targetColumn >= 0 ||
                   targetRow < map.Count ||
                   targetColumn < map[targetRow].Length;
        }
    }
}
