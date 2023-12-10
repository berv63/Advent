namespace Advent2023.Advent05;

public class FoodProduction
{
    private List<long> Seeds => GetSeedList();

    private Map SeedSoilMap { get; set; } = new();
    private Map SeedMap { get; set; } = new();

    private List<string> _input { get; set; }
    public FoodProduction(List<string> input, bool ranged = false)
    {
        _input = input;

        if (ranged)
        {
            BuildSeedMap();
            PopulateMapsForRanged();
        }
        else
        {
            PopulateMaps();
        }
    }

    public long GetClosestInitialSeedLocation()
    {
        var closestLocation = long.MaxValue;

        foreach (var seed in Seeds)
        {
            var location = SeedSoilMap.GetDestination(seed);

            if (location < closestLocation)
                closestLocation = location;
        }

        return closestLocation;
    }

    public long GetClosestInitialSeedLocationRanged()
    {
        var closestLocation = long.MaxValue;

        foreach (var seed in SeedMap.MapValues)
        {
            for (var currentSeed = seed.SourceRangeStart; currentSeed < seed.SourceRangeEnd; currentSeed++)
            {
                var destination = SeedSoilMap.GetDestination(currentSeed);
                closestLocation = closestLocation < destination ? closestLocation : destination;
            }
        }

        return closestLocation;
    }

    public long GetClosestInitialSeedLocationRanged2()
    {
        var closestLocation = long.MaxValue;
        foreach (var seed in SeedMap.MapValues)
        {
            var destination = SeedSoilMap.GetDestination(seed.SourceRangeStart);
            closestLocation = closestLocation < destination ? closestLocation : destination;
        }

        return closestLocation;
    }

    private List<long> GetSeedList()
    {
        return _input.Single(x => x.StartsWith("seeds")).Split(":").Last().Split(" ")
            .Where(x => !string.IsNullOrWhiteSpace(x)).Select(long.Parse).ToList();
    }

    private void BuildSeedMap()
    {
        SeedMap = new Map
        {
            Type = MapType.Seed
        };
        var seedList = _input.Single(x => x.StartsWith("seeds")).Split(":").Last().Split(" ")
            .Where(x => !string.IsNullOrWhiteSpace(x)).Select(long.Parse).ToList();

        for (var i = 0; i < seedList.Count; i+=2)
        {
            var seedStart = seedList[i];
            var seedEnd = seedStart + seedList[i + 1] - 1;

            SeedMap.MapValues.Add(new MapValues($"{seedStart} {seedStart} {seedEnd - seedStart + 1}", MapType.Seed));
        }
    }

    private void PopulateMaps()
    {
        var mapStartIndex = _input.IndexOf("seed-to-soil map:");
        SeedSoilMap.PopulateMapHierarchy(_input, mapStartIndex);
    }

    private void PopulateMapsForRanged()
    {
        var mapStartIndex = _input.IndexOf("seed-to-soil map:");
        SeedSoilMap.PopulateMapHierarchy(_input, mapStartIndex);
        SeedMap.ChildMap = SeedSoilMap;
        bool hasSplit;
        do
        {
            hasSplit = false;
            SeedMap.SplitMapValues(ref hasSplit);
        } while (hasSplit);
    }

}
