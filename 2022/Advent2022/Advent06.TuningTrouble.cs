using Advent2022.Models;
using AdventShared;

namespace Advent2022;

public static class TuningTrouble
{
    public static int FindUnique(string buffer, int length)
    {
        var index = 0;
        for (var i = 0; i < buffer.Length - length + 1; i++)
        {
            if (buffer.IsDistinctSubstringForLength(i, length))
            {
                index = i + length;
                break;
            }
        }

        return index;
    }
}