namespace Advent2023.Advent05;

public class FoodProduction
{
    private List<long> Seeds => GetSeedList();

    private Map SeedMap { get; set; }

    private List<string> _input { get; set; }
    public FoodProduction(List<string> input)
    {
        _input = input;
        PopulateMaps();
    }

    public long GetClosestInitialSeedLocation()
    {
        var closestLocation = long.MaxValue;

        foreach (var seed in Seeds)
        {
            var location = SeedMap.GetDestination(seed);

            if (location < closestLocation)
                closestLocation = location;
        }

        return closestLocation;
    }

    public long GetClosestInitialSeedLocationRanged()
    {
        var closestLocation = long.MaxValue;

        foreach (var seed in GetSeedRanged())
        {
            for (var currentSeed = seed.SourceRangeStart; currentSeed < seed.SourceRangeEnd; currentSeed++)
            {
                var destination = SeedMap.GetDestination(currentSeed);
                closestLocation = closestLocation < destination ? closestLocation : destination;
            }
        }

        return closestLocation;
    }

    private List<long> GetSeedList()
    {
        return _input.Single(x => x.StartsWith("seeds")).Split(":").Last().Split(" ")
            .Where(x => !string.IsNullOrWhiteSpace(x)).Select(long.Parse).ToList();
    }

    private List<MapValues> GetSeedRanged()
    {
        var result = new List<MapValues>();
        var seedList = _input.Single(x => x.StartsWith("seeds")).Split(":").Last().Split(" ")
            .Where(x => !string.IsNullOrWhiteSpace(x)).Select(long.Parse).ToList();

        for (var i = 0; i < seedList.Count; i+=2)
        {
            var seedStart = seedList[i];
            var seedEnd = seedStart + seedList[i + 1] - 1;

            var mapValues = new MapValues($"{seedStart} {seedStart} {seedEnd - seedStart - 1}");
            mapValues.PopulateChildMapValuesBase(SeedMap);
            result.Add(mapValues);
        }

        return result;
    }

    private void PopulateMaps()
    {
        var mapStartIndex = _input.IndexOf("seed-to-soil map:");
        SeedMap = new Map();
        SeedMap.PopulateMapHierarchy(_input, mapStartIndex);
        SeedMap.PopulateChildMapValues();
    }
}
