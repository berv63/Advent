using Advent2022.Models;
using AdventShared;

namespace Advent2022;

public static class TuningTrouble
{
    public static int FindUnique(string buffer, int length)
    {
        var index = 0;
        for (int i = 0; i < buffer.Length - length + 1; i++)
        {
            if (IsUnique(buffer, i, length))
            {
                index = i + length;
                break;
            }
        }

        return index;
    }

    private static bool IsUnique(string buffer, int startIndex, int length)
    {
        var digitGroupings = buffer.Substring(startIndex, length).GroupBy(x => x); 
        return digitGroupings.All(x => x.Count() == 1);
    }
}