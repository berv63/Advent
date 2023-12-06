namespace Advent2023.Advent05;

public class Map
{
    public MapType Type { get; set; }
    public List<MapValues> MapValues { get; set; }

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
            var mapValue = new MapValues(input[index++]);
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
        MapValues.Add(new MapValues($"{startValue} {startValue} {range}"));
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

    public void PopulateChildMapValues()
    {
        if (ChildMap == null)
            return;

        foreach (var mapValue in MapValues)
        {
            mapValue.ChildMapValues = mapValue.GetChildMapValues(ChildMap.MapValues);
        }

        ChildMap.PopulateChildMapValues();
    }

    public long GetDestination(long sourceValue)
    {
        var mapValues = MapValues.FirstOrDefault(x => x.ContainsSource(sourceValue));
        var destination = mapValues?.GetDestination(sourceValue) ?? sourceValue;
        return ChildMap?.GetDestination(destination) ?? destination;
    }
}
