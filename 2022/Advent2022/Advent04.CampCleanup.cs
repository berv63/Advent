using Advent2022.Interfaces;
using Advent2022.Models;

namespace Advent2022;

public static class CampCleanup
{
    public static IEnumerable<CleaningPairsModel> BuildCleaningPairs(List<string> rucksacks)
    {
        return rucksacks.Select(x => new CleaningPairsModel(x));
    }

    public static int FullyContainedPairs(IEnumerable<CleaningPairsModel> cleaningPairs)
    {
        return cleaningPairs.Count(x => x.IsFullyContainedPair);
    }

    public static int OverlappedPairs(IEnumerable<CleaningPairsModel> cleaningPairs)
    {
        return cleaningPairs.Count(x => x.IsOverlappedPair);
    }
}