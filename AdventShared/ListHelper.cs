using System.Collections.Generic;

namespace AdventShared;

public static class ListHelper
{
    public static List<(int row, int column)> GetAdjacentIndices(int i, int j)
    {
        return new List<(int row, int column)>
        {
            (i - 1, j - 1),
            (i - 1, j),
            (i - 1, j + 1),
            (i, j - 1),
            (i, j + 1),
            (i + 1, j - 1),
            (i + 1, j),
            (i + 1, j + 1)
        };
    }
}
