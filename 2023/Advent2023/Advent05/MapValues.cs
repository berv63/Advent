namespace Advent2023.Advent05;

public class MapValues
{
    public long DestinationRangeStart => GetDestinationRangeStart();
    public long DestinationRangeEnd => DestinationRangeStart + RangeLength - 1;
    public long SourceRangeStart { get; set; }
    public long SourceRangeEnd => SourceRangeStart + RangeLength - 1;
    private long RangeLength => GetRangeLength();

    public List<MapValues> ChildMapValues { get; set; } = new();

    private string _map { get; set; }

    public MapValues(string map)
    {
        _map = map;
        SourceRangeStart = GetSourceRangeStart();
    }

    private long GetDestinationRangeStart()
    {
        return long.Parse(_map.Split(" ").First());
    }

    private long GetSourceRangeStart()
    {
        return long.Parse(_map.Split(" ")[1]);
    }

    private long GetRangeLength()
    {
        return long.Parse(_map.Split(" ").Last());
    }

    public bool ContainsSource(long source)
    {
        return SourceRangeStart <= source && SourceRangeEnd >= source;
    }

    public long GetDestination(long source)
    {
        var sourceMapIndex = source - SourceRangeStart;
        return DestinationRangeStart + sourceMapIndex;
    }

    public void PopulateChildMapValuesBase(Map childMap)
    {
        ChildMapValues = childMap.MapValues.Where(x => x.SourceRangeStart < DestinationRangeEnd && x.SourceRangeEnd > DestinationRangeStart).ToList();
    }

    public List<MapValues> GetChildMapValues(List<MapValues> childMapValues)
    {
        return childMapValues.Where(x => x.SourceRangeStart < DestinationRangeEnd && x.SourceRangeEnd > DestinationRangeStart).ToList();
    }

    /*public void GetMinDestination(MapValues mapValues, out (long destination, long finalDestination) values)
    {
        if (!ChildMapValues.Any())
        {
            values = (long.MaxValue, long.MaxValue);
            return;
        }

        var minDestinationMapValue = ChildMapValues.Single(x => x.SourceRangeStart <= DestinationRangeStart && x.SourceRangeEnd >= DestinationRangeStart);
        var minDestination = minDestinationMapValue.GetDestination(DestinationRangeStart);

        foreach (var childMapValue in ChildMapValues)
        {
            minDestination = minDestination < childMapValue.DestinationRangeStart
                ? minDestination
                : childMapValue.DestinationRangeStart;
        }
    }*/
}
