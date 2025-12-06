using Advent2025.Advent03;

namespace Advent2025.Advent04;

public class Printing
{
    public int TotalAvailableRolls(List<string> input)
    {
        var paperRows = input.Select(x => new PaperRows(x)).ToList();
        
        var totalCount = paperRows.First().CountFree("", input[1]);
        for (int i = 1; i < input.Count - 1; i++)
        {
            totalCount += paperRows[i].CountFree(input[i - 1], input[i + 1]);
        }
        totalCount += paperRows.Last().CountFree(input[input.Count - 2], "");

        return totalCount;
    }
    
    public int OngoingAvailableRolls(List<string> input)
    {
        var paperRows = input.Select(x => new PaperRows(x)).ToList();
        var totalFree = 0;
        int lastFree;
        do
        {
            lastFree = GetRemovedPaperCount(paperRows);
            totalFree += lastFree;

            foreach (var row in paperRows)
            {
                row.CleanupOccupied();
            }
        } while(lastFree > 0);

        return totalFree;
    }

    private int GetRemovedPaperCount(List<PaperRows> paperRows)
    {
        var totalCount = paperRows.First().CountAndUpdateFree(null, paperRows[1]);
        for (int i = 1; i < paperRows.Count - 1; i++)
        {
            totalCount += paperRows[i].CountAndUpdateFree(paperRows[i - 1], paperRows[i + 1]);
        }
        totalCount += paperRows.Last().CountAndUpdateFree(paperRows[paperRows.Count - 2], null);
        
        return totalCount;
    }
}