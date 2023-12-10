namespace Advent2023.Advent05;

public class MapValues
{
    public MapType Type { get; set; }
    public long DestinationRangeStart { get; set; }
    public long DestinationRangeEnd { get; set; }
    public long SourceRangeStart { get; set; }
    public long SourceRangeEnd { get; set; }

    public MapValues? ChildMapValue { get; set; }


    public MapValues(string map, MapType type)
    {
        Type = type;
        SourceRangeStart = GetSourceRangeStart(map);
        DestinationRangeStart = GetDestinationRangeStart(map);

        var range = GetRangeLength(map);

        SourceRangeEnd = SourceRangeStart + range - 1;
        DestinationRangeEnd = DestinationRangeStart + range - 1;
    }

    public MapValues(long sourceStart, long sourceEnd, long destinationStart, long destinationEnd, MapType type)
    {
        SourceRangeStart = sourceStart;
        SourceRangeEnd = sourceEnd;

        DestinationRangeStart = destinationStart;
        DestinationRangeEnd = destinationEnd;

        Type = type;
    }

    private long GetDestinationRangeStart(string map)
    {
        return long.Parse(map.Split(" ").First());
    }

    private long GetSourceRangeStart(string map)
    {
        return long.Parse(map.Split(" ")[1]);
    }

    private long GetRangeLength(string map)
    {
        return long.Parse(map.Split(" ").Last());
    }

    public bool DestinationEquals(long destinationStart, long destinationEnd)
    {
        return destinationStart == DestinationRangeStart && destinationEnd == DestinationRangeEnd;
    }

    public bool SourceEquals(long sourceStart, long sourceEnd)
    {
        return sourceStart == SourceRangeStart && sourceEnd == SourceRangeEnd;
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

    public List<MapValues> GetIncludedChildMapValuesSorted(List<MapValues> childMapValues)
    {
        var result = new List<MapValues>();
        foreach (var childMapValue in childMapValues)
        {
            if(childMapValue.SourceRangeStart <= DestinationRangeEnd && childMapValue.SourceRangeEnd >= DestinationRangeStart)
                result.Add(childMapValue);
        }

        return result.OrderBy(x => x.SourceRangeStart).ToList();
    }

    public List<MapValues> GetIncludedParentMapValuesSorted(List<MapValues> parentMapValues)
    {
        var result = new List<MapValues>();
        foreach (var parentMapValue in parentMapValues)
        {
            if(parentMapValue.DestinationRangeStart <= SourceRangeEnd && parentMapValue.DestinationRangeEnd >= SourceRangeStart)
                result.Add(parentMapValue);
        }

        return result.OrderBy(x => x.DestinationRangeStart).ToList();
    }
}
