namespace Advent2023.Advent05;

public class Map
{
    public MapType Type { get; set; }
    public List<MapValues> MapValues { get; set; } = new();

    public Map? ChildMap { get; set; }

    private MapType GetMapType(string type)
    {
        return type switch
        {
            "seed-to-soil" => MapType.SeedToSoil,
            "soil-to-fertilizer" => MapType.SoilToFertilizer,
            "fertilizer-to-water" => MapType.FertilizerToWater,
            "water-to-light" => MapType.WaterToLight,
            "light-to-temperature" => MapType.LightToTemperature,
            "temperature-to-humidity" => MapType.TemperatureToHumidity,
            "humidity-to-location" => MapType.HumidityToLocation,
            _ => throw new Exception("Invalid type")
        };
    }

    public void PopulateMapHierarchy(List<string> input, int index)
    {
        do
        {
            if (input[index] == "" && index < input.Count)
            {
                PopulateChildMap(input, ++index);
                continue;
            }

            Type = GetMapType(input[index++].Split(" ").First());
            PopulateMapValues(input, ref index);
        } while (ChildMap == null && index < input.Count);
    }

    private void PopulateMapValues(List<string> input, ref int index)
    {
        var mapValues = new List<MapValues>();
        while (index < input.Count && input[index] != "")
        {
            var mapValue = new MapValues(input[index++], Type);
            mapValues.Add(mapValue);
        }

        MapValues = mapValues.OrderBy(x => x.SourceRangeStart).ToList();

        PopulateGapMapValues();

    }

    private void PopulateGapMapValues()
    {
        if (MapValues.First().SourceRangeStart != 0)
        {
            PopulateGapMapValue(0, MapValues[0].SourceRangeStart - 1);
        }

        for (var i = 0; i < MapValues.Count - 1; i++)
        {
            if (AreMapValuesAdjacent(i)) continue;
            PopulateGapMapValue(MapValues[i].SourceRangeEnd + 1, MapValues[i+1].SourceRangeStart - 1);
        }

        if (MapValues.Last().SourceRangeEnd != long.MaxValue)
        {
            PopulateGapMapValue(MapValues.Last().SourceRangeEnd + 1, long.MaxValue);
        }
    }

    private void PopulateGapMapValue(long startValue, long endValue)
    {
        var range = endValue - startValue + 1;
        MapValues.Add(new MapValues($"{startValue} {startValue} {range}", Type));
        MapValues = MapValues.OrderBy(x => x.SourceRangeStart).ToList();
    }

    private bool AreMapValuesAdjacent(int index)
    {
        return MapValues[index].SourceRangeEnd == MapValues[index + 1].SourceRangeStart - 1;
    }

    private void PopulateChildMap(List<string> input, int index)
    {
        ChildMap = new Map();
        ChildMap.PopulateMapHierarchy(input, index);
    }

    public long GetDestination(long sourceValue)
    {
        var mapValues = MapValues.FirstOrDefault(x => x.ContainsSource(sourceValue));
        var destination = mapValues?.GetDestination(sourceValue) ?? sourceValue;
        return ChildMap?.GetDestination(destination) ?? destination;
    }

    public void SplitMapValues(ref bool hasSplit)
    {
        if (ChildMap == null) return;
        SplitMe(ref hasSplit);
        SplitChildren(ref hasSplit);
        ChildMap.SplitMapValues(ref hasSplit);
    }

    private void SplitMe(ref bool hasSplit)
    {
        var newMapValues = new List<MapValues>();
        foreach (var mapValue in MapValues)
        {
            var children = mapValue.GetIncludedChildMapValuesSorted(ChildMap!.MapValues);
            foreach (var child in children)
            {
                var newDestinationStart = mapValue.DestinationRangeStart;
                if (child.SourceRangeStart > mapValue.DestinationRangeStart)
                {
                    newDestinationStart = child.SourceRangeStart;
                }

                var newDestinationEnd = mapValue.DestinationRangeEnd;
                if (child.SourceRangeEnd < mapValue.DestinationRangeEnd)
                {
                    newDestinationEnd = child.SourceRangeEnd;
                }

                BuildSplitMapValue(mapValue, newDestinationStart, newDestinationEnd, newMapValues, ref hasSplit);
            }
        }
        MapValues = newMapValues;
    }

    private void BuildSplitMapValue(MapValues currentMapValue, long newDestinationStart, long newDestinationEnd, List<MapValues> newMapValues, ref bool hasSplit)
    {
        if (currentMapValue.DestinationEquals(newDestinationStart, newDestinationEnd))
        {
             newMapValues.Add(currentMapValue);
             return;
        }

        hasSplit = true;

        var destinationStartDifference = newDestinationStart - currentMapValue.DestinationRangeStart;
        var newSourceStart = currentMapValue.SourceRangeStart + destinationStartDifference;

        var destinationEndDifference = newDestinationEnd - currentMapValue.DestinationRangeEnd;
        var newSourceEnd = currentMapValue.SourceRangeEnd + destinationEndDifference;

        newMapValues.Add(new MapValues(newSourceStart, newSourceEnd, newDestinationStart, newDestinationEnd, currentMapValue.Type));
    }

    private void SplitChildren(ref bool hasSplit)
    {
        var newMapValues = new List<MapValues>();
        foreach (var mapValue in ChildMap!.MapValues)
        {
            var parentMap = mapValue.GetIncludedParentMapValuesSorted(MapValues);
            foreach (var parent in parentMap)
            {
                var newSourceStart = mapValue.SourceRangeStart;
                if (parent.DestinationRangeStart > mapValue.SourceRangeStart)
                {
                    newSourceStart = parent.DestinationRangeStart;
                }

                var newSourceEnd = mapValue.SourceRangeEnd;
                if (parent.DestinationRangeEnd < mapValue.SourceRangeEnd)
                {
                    newSourceEnd = parent.DestinationRangeEnd;
                }

                BuildSplitChildMapValue(mapValue, newSourceStart, newSourceEnd, newMapValues, ref hasSplit);
            }
        }
        ChildMap.MapValues = newMapValues;
    }

    private void BuildSplitChildMapValue(MapValues currentMapValue, long newSourceStart, long newSourceEnd, List<MapValues> newMapValues, ref bool hasSplit)
    {
        if (currentMapValue.SourceEquals(newSourceStart, newSourceEnd))
        {
            newMapValues.Add(currentMapValue);
            return;
        }

        hasSplit = true;

        var sourceStartDifference = newSourceStart - currentMapValue.SourceRangeStart;
        var newDestinationStart = currentMapValue.DestinationRangeStart + sourceStartDifference;

        var sourceEndDifference = newSourceEnd - currentMapValue.SourceRangeEnd;
        var newDestinationEnd = currentMapValue.DestinationRangeEnd + sourceEndDifference;

        newMapValues.Add(new MapValues(newSourceStart, newSourceEnd, newDestinationStart, newDestinationEnd, currentMapValue.Type));
    }
}
