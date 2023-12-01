using AdventShared;

namespace Advent2022.Models.Advent17;

public class TetrisGridModel
{
    public List<List<char>> Grid { get; set; } = new();
    
    public int Round { get; set; }

    public char air = '.';
    public char inMotion = '@';
    public char atRest = '#';
    
    public TetrisGridModel()
    {
        
    }

    public void AddGapToGrid()
    {
        var airOnlyTopCount = AirOnlyTopCount();
        for (int i = 0; i <= 3 - airOnlyTopCount; i++)
        {
            Grid.Add(new List<char>{air, air, air, air, air, air, air});
            Grid.ShiftRight();
        }
    }

    private int AirOnlyTopCount()
    {
        var result = 0;
        for (int i = 0; i <= 2; i++)
        {
            if (i >= Grid.Count)
                break;
            
            if (Grid[i].All(x => x == air))
                result++;
        }

        return result;
    }

    public bool IsTargetLocationAir(int targetY, int targetX)
    {
        return targetY < 0 || !IsTargetYOutOfBounds(targetY) && !IsTargetXOutOfBounds(targetX) && Grid[targetY][targetX] == air;
    }

    private bool IsTargetYOutOfBounds(int targetY)
    {
        return targetY >= Grid.Count;
    }

    private bool IsTargetXOutOfBounds(int targetX)
    {
        return targetX is < 0 or >= 7;
    }

    public void PrintGrid(TetrisShapeModel? shape = null)
    {
        var gridToPrint = Grid.CopyValues();
        shape?.SetShapeOnGrid(gridToPrint);
        var list = gridToPrint.Select(x => string.Join("", x.Select(y => y.ToString()))).ToList();
        FileExtensions.WriteFile($@"..\..\..\..\{FileExtensions.GetFileOutputLocation("Advent17", $"TetrisOutput")}", list);
    }

    public int GetGridHeight()
    {
        for (var i = 0; i < Grid.Count; i++)
        {
            for (var j = 0; j < Grid[i].Count(); j++)
            {
                if (!IsTargetLocationAir(i, j))
                    return Grid.Count - (i + 1);
            }
        }

        throw new InvalidOperationException("No blocks in tower");
    }
}