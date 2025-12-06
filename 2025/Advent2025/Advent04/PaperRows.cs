namespace Advent2025.Advent04;

public class PaperRows
{
    public List<char> Row { get; set; }

    public PaperRows(string input)
    {
        Row = input.ToList();
    }

    public int CountFree(string previousRow, string nextRow)
    {
        var freeCount = 0;
        for (int i = 0; i < Row.Count; i++)
        {
            if (Row[i] != '@')
            {
                continue;
            }
            
            var adjacentPapers = 0;
            if (!string.IsNullOrWhiteSpace(previousRow))
            {
                if (i != 0)
                {
                    adjacentPapers += previousRow[i - 1] == '@' ? 1 : 0;
                }
                adjacentPapers += previousRow[i] == '@' ? 1 : 0;
                if (i != Row.Count - 1)
                {
                    adjacentPapers += previousRow[i + 1] == '@' ? 1 : 0;
                }
            }
            
            if (i != 0)
            {
                adjacentPapers += Row[i - 1] == '@' ? 1 : 0;
            }
            if (i != Row.Count - 1)
            {
                adjacentPapers += Row[i + 1] == '@' ? 1 : 0;
            }
            
            if (!string.IsNullOrWhiteSpace(nextRow))
            {
                if (i != 0)
                {
                    adjacentPapers += nextRow[i - 1] == '@' ? 1 : 0;
                }
                adjacentPapers += nextRow[i] == '@' ? 1 : 0;
                if (i != Row.Count - 1)
                {
                    adjacentPapers += nextRow[i + 1] == '@' ? 1 : 0;
                }
            }

            if (adjacentPapers < 4)
            {
                freeCount++;
            }
        }

        return freeCount;
    }
    
    public int CountAndUpdateFree(PaperRows? previousRow, PaperRows? nextRow)
    {
        var freeCount = 0;
        for (int i = 0; i < Row.Count; i++)
        {
            if (Row[i] != '@')
            {
                continue;
            }
            
            var adjacentPapers = 0;
            if (previousRow?.Row != null)
            {
                if (i != 0)
                {
                    adjacentPapers += IsCurrentlyOccupied(previousRow.Row[i - 1]) ? 1 : 0;
                }
                adjacentPapers += IsCurrentlyOccupied(previousRow.Row[i]) ? 1 : 0;
                if (i != Row.Count - 1)
                {
                    adjacentPapers += IsCurrentlyOccupied(previousRow.Row[i + 1]) ? 1 : 0;
                }
            }
            
            if (i != 0)
            {
                adjacentPapers += IsCurrentlyOccupied(Row[i - 1]) ? 1 : 0;
            }
            if (i != Row.Count - 1)
            {
                adjacentPapers += IsCurrentlyOccupied(Row[i + 1]) ? 1 : 0;
            }
            
            if (nextRow?.Row != null)
            {
                if (i != 0)
                {
                    adjacentPapers += IsCurrentlyOccupied(nextRow.Row[i - 1]) ? 1 : 0;
                }
                adjacentPapers += IsCurrentlyOccupied(nextRow.Row[i]) ? 1 : 0;
                if (i != Row.Count - 1)
                {
                    adjacentPapers += IsCurrentlyOccupied(nextRow.Row[i + 1]) ? 1 : 0;
                }
            }

            if (adjacentPapers < 4)
            {
                freeCount++;
                Row[i] = 'x';
            }
        }

        return freeCount;
    }
    
    public void CleanupOccupied()
    {
        for (int i = 0; i < Row.Count; i++)
        {
            if (Row[i] == 'x')
            {
                Row[i] = '.';
            }    
        }
    }

    private bool IsCurrentlyOccupied(char value)
    {
        return value == '@' || value == 'x';
    }
}