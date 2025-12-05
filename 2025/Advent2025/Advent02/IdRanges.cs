using AdventShared;

namespace Advent2025.Advent02;

public class IdRanges
{
    public long Min { get; set; }
    public long Max { get; set; }
    
    public List<long> InvalidIds { get; set; } = new();

    public IdRanges(string range)
    {
        var parts = range.Split('-');
        Min = long.Parse(parts[0]);
        Max = long.Parse(parts[1]);
    }

    public void PopulateInvalidIds()
    {
        for (var i = Min; i <= Max; i++)
        {
            if(!IsValid(i.ToString()))
                InvalidIds.Add(i);
        }
    }

    private bool IsValid(string value)
    {
        return !value.IsEvenLength() || !IsRepeated(value);
    }

    private bool IsRepeated(string value)
    {
        var halfLength = value.Length / 2;
        var firstHalf = value.Substring(0, halfLength);
        var secondHalf = value.Substring(halfLength, halfLength);
        return firstHalf == secondHalf;
    }

    public void PopulateRepeatingInvalidIds()
    {
        for (var i = Min; i <= Max; i++)
        {
            if(!IsRepeatingValid(i.ToString()))
                InvalidIds.Add(i);
        }
    }

    private bool IsRepeatingValid(string value)
    {
        return !IsRepeating(value);
    }

    private bool IsRepeating(string value)
    {
        for (int i = 1; i < (value.Length / 2) + 1; i++)
        {
            var valueToCheck = value.Substring(0, i);
            var repeatedValue = string.Concat(Enumerable.Repeat(valueToCheck, value.Length / i));
            if (repeatedValue == value)
                return true;
        }

        return false;
    }
}