namespace Advent2025.Advent05;

public class Cafeteria
{
    public int GetFreshItemCount(List<string> input)
    {
        var ranges = new List<Range>();
        var i = BuildRanges(input, ref ranges);

        i++;

        return GetFreshCount(input, i, ranges);
    }

    public long GetFreshItemIdCount(List<string> input)
    {
        var ranges = new List<Range>();
        var index = BuildRanges(input, ref ranges);

        bool hasMerged;
        do
        {
            hasMerged = false;
            
            foreach (var range1 in ranges)
            {
                foreach (var range2 in ranges)
                {
                    if (range1.Index == range2.Index) continue;

                    if ((range2.Start <= range1.End && range2.End >= range1.End) || (range1.Start >= range2.Start && range1.Start <= range2.End))
                    {
                        var mergedRange = new Range(index++, range1, range2);
                        ranges.Remove(range1);
                        ranges.Remove(range2);
                        ranges.Add(mergedRange);
                        
                        hasMerged = true;
                        break;
                    }
                }
                
                if (hasMerged) break;
            }
            
        } while (hasMerged);

        return ranges.Select(x => (long)x.Difference).Sum(x => x);
    }
    
    private int BuildRanges(List<string> input, ref List<Range> ranges)
    {
        var i = 0;
        while (input[i] != "")
        {
            ranges.Add(new Range(i, input[i]));
            i++;
        }

        return i;
    }
    
    private static int GetFreshCount(List<string> input, int i, List<Range> ranges)
    {
        var freshCount = 0;
        while (i < input.Count)
        {
            var item = ulong.Parse(input[i]);
            foreach (var range in ranges)
            {
                if (range.ContainsItem(item))
                {
                    freshCount++;
                    break;
                }
            }
            
            i++;
        }

        return freshCount;
    }
}