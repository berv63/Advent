using Advent2025.Advent01;

namespace Advent2025.Advent02;

public class GiftShop
{
    public long SumInvalid(List<string> input)
    {
        var ranges = input[0].Split(',').Select(x => new IdRanges(x)).ToList();
        foreach (var range in ranges)
        {
            range.PopulateInvalidIds();
        }

        return ranges.Select(x => x.InvalidIds.Sum()).Sum();
    }
    
    public long SumRepeatingInvalid(List<string> input)
    {
        var ranges = input[0].Split(',').Select(x => new IdRanges(x)).ToList();
        foreach (var range in ranges)
        {
            range.PopulateRepeatingInvalidIds();
        }

        return ranges.Select(x => x.InvalidIds.Sum()).Sum();
    }
}