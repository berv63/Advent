using Advent2022.Interfaces;
using Advent2022.Models;

namespace Advent2022;

public static class RucksackReorg
{
    public static IEnumerable<RucksackModel> BuildRucksacks(List<string> rucksacks)
    {
        return rucksacks.Select(x => new RucksackModel(x));
    }
    
    public static List<RucksackGroup> GroupRucksacks(List<RucksackModel> rucksacks)
    {
        var rucksackGroups = new List<RucksackGroup>();
        var index = 0;
        do
        {
            var group = new RucksackGroup(rucksacks.ToList().GetRange(index, 3).ToArray());
            rucksackGroups.Add(group);
            index += 3;
        } while (index < rucksacks.Count());

        return rucksackGroups;
    }

    public static int PriorityTotal(IEnumerable<RucksackModel> rucksacks)
    {
        return rucksacks.Sum(x => x.DuplicatePriorityTotal);
    }

    public static int GetGroupBadgePriorityTotal(List<RucksackGroup> rucksackGroups)
    {
        return rucksackGroups.Sum(x => x.BadgePriority);
    }
}