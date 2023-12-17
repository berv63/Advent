using AdventShared;

namespace Advent2023.Advent13;

public class MirrorMap
{
    private List<string> Map = new();
    private int MirrorIndex { get; set; } = -1;
    private ReflectionType ReflectionType { get; set; }

    public long SummarizedValue => ReflectionType == ReflectionType.Horizontal ? 100 * (MirrorIndex+1) : MirrorIndex+1;

    public MirrorMap(List<string> input, ref int startIndex)
    {
        for (var i = startIndex; i <= input.Count; i++)
        {
            if (i == input.Count || input[i] == "")
            {
                startIndex = i + 1;
                break;
            }

            Map.Add(input[i]);
        }

    }

    public void FindMirrorLocation()
    {
        var horizCheck = Map.Select(x => x.ToList()).ToList();
        RowMirrorLocation(horizCheck);

        if (MirrorIndex != -1)
        {
            ReflectionType = ReflectionType.Horizontal;
            return;
        }

        var vertCheck = Map.Select(x => x.ToList()).ToList().RotateMap();
        RowMirrorLocation(vertCheck);

        ReflectionType = ReflectionType.Vertical;
    }

    private void RowMirrorLocation(List<List<char>> map)
    {
        for (var i = 0; i < map.Count - 1; i++)
        {
            if (IsValidRowMirror(map, i, i + 1))
            {
                MirrorIndex = i;
                break;
            }
        }
    }

    private bool IsValidRowMirror(List<List<char>> map, int mirrorIndex1, int mirrorIndex2)
    {
        var isValidMirror = true;
        do
        {
            isValidMirror = isValidMirror && string.Join("", map[mirrorIndex1]) == string.Join("", map[mirrorIndex2]);
            mirrorIndex1--;
            mirrorIndex2++;
        } while (isValidMirror && mirrorIndex1 >= 0 && mirrorIndex2 < map.Count);

        return isValidMirror;
    }


    public void FindMirrorLocationWithSmudge()
    {
        var horizCheck = Map.Select(x => x.ToList()).ToList();
        RowMirrorLocationWithSmudge(horizCheck);

        if (MirrorIndex != -1)
        {
            ReflectionType = ReflectionType.Horizontal;
            return;
        }

        var vertCheck = Map.Select(x => x.ToList()).ToList().RotateMap();
        RowMirrorLocationWithSmudge(vertCheck);

        ReflectionType = ReflectionType.Vertical;
    }

    private void RowMirrorLocationWithSmudge(List<List<char>> map)
    {
        for (var i = 0; i < map.Count - 1; i++)
        {
            if (IsValidRowMirrorWithSmudge(map, i, i + 1))
            {
                MirrorIndex = i;
                break;
            }
        }
    }

    private bool IsValidRowMirrorWithSmudge(List<List<char>> map, int mirrorIndex1, int mirrorIndex2)
    {
        var isValidSmudgyMirror = true;
        var differences = 0;
        do
        {
            differences += GetRowDifferenceCount(map[mirrorIndex1], map[mirrorIndex2]);

            isValidSmudgyMirror = isValidSmudgyMirror && differences <= 1;
            mirrorIndex1--;
            mirrorIndex2++;
        } while (isValidSmudgyMirror && mirrorIndex1 >= 0 && mirrorIndex2 < map.Count);

        return isValidSmudgyMirror && differences == 1;
    }

    private int GetRowDifferenceCount(List<char> row1, List<char> row2)
    {
        var differences = 0;
        for (var i = 0; i < row1.Count; i++)
        {
            if (row1[i] != row2[i])
            {
                differences++;
            }

            if (differences > 1)
                break;
        }

        return differences;
    }
}
