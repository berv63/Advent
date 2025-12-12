using System.Collections.Generic;
using System.Linq;

namespace AdventShared;

public static class DictionaryExtenstions
{
    public static Dictionary<T, TT> Merge<T, TT>(this Dictionary<T, TT> dictionary1, Dictionary<T, TT> dictionary2)
    {
        return dictionary1.Concat(dictionary2)
            .GroupBy(kvp => kvp.Key)
            .ToDictionary(g => g.Key, g => g.First().Value);
    }
}
