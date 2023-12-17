using AdventShared;

namespace Advent2023.Advent13;

public class PointOfIncidence
{
    public List<MirrorMap> Maps = new();

    public PointOfIncidence(List<string> input)
    {
        var startIndex = 0;
        do
        {
            Maps.Add(new MirrorMap(input, ref startIndex));
        } while (startIndex < input.Count - 1);
    }

    public long GetMirrorSummary()
    {
        foreach (var map in Maps)
        {
            map.FindMirrorLocation();
        }

        return Maps.Sum(x => x.SummarizedValue);
    }

    public long GetSmudgyMirrorSummary()
    {
        foreach (var map in Maps)
        {
            map.FindMirrorLocationWithSmudge();
        }

        return Maps.Sum(x => x.SummarizedValue);
    }
}
