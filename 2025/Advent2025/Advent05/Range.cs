namespace Advent2025.Advent05;

public class Range
{
    public int Index { get; set; }
    public ulong Start { get; set; }
    public ulong End { get; set; }

    public ulong Difference => End - Start + 1;
    
    public Range(int index, string input)
    {
        Index = index;
        
        var parts = input.Split('-');
        Start = ulong.Parse(parts[0]);
        End = ulong.Parse(parts[1]);
    }

    public Range(int index, Range range1, Range range2)
    {
        Index = index;
        Start = Math.Min(range1.Start, range2.Start);
        End = Math.Max(range1.End, range2.End);
    }

    public bool ContainsItem(ulong item)
    {
        return Start <= item && item <= End;
    }
}