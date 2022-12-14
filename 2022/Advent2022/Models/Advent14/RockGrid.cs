using System.Runtime.CompilerServices;
using AdventShared;

namespace Advent2022.Models.Advent14;

public class RockGrid
{
    public List<List<char>> Grid { get; set; } = new();
    
    public RockCoordinates Source { get; set; }
    
    public int MinX { get; set; }
    private int MinY { get; set; }
    
    private int MaxX { get; set; }
    private int MaxY { get; set; }
    
    public bool HasFloor { get; set; }
    private int FloorY { get; set; }

    private const char source = 'S';
    private const char rock = '#';
    private const char sand = 'o';
    private const char air = '.';
    private const char disappear = '~';

    public RockGrid(List<List<RockCoordinates>> coordinates, bool hasFloor = false)
    {
        MinX = coordinates.Min(x => x.Min(y => y.XCoord));
        MinY = 0;
        
        MaxX = coordinates.Max(x => x.Max(y => y.XCoord));
        MaxY = coordinates.Max(x => x.Max(y => y.YCoord));

        HasFloor = hasFloor;
        FloorY = MaxY + 2;
        
        Source = new RockCoordinates($"{500 - MinX},0");
        
        InitGrid();
        SeedRocks(coordinates);
        
        PrintGrid();
    }

    private void InitGrid()
    {
        for (var i = MinY; i <= MaxY; i++)
        {
            Grid.Add(new List<char>());
            for (var j = MinX; j <= MaxX; j++)
            {
                Grid.Last().Add(air);
            }
        }
        
        if (HasFloor)
        {
            Grid.Add(new List<char>());
            for (var j = MinX; j <= MaxX; j++)
            {
                Grid.Last().Add(air);
            }
            Grid.Add(new List<char>());
            for (var j = MinX; j <= MaxX; j++)
            {
                Grid.Last().Add(air);
            }
        }
    }

    private void SeedRocks(List<List<RockCoordinates>> coordinates)
    {
        foreach (var group in coordinates)
        {
            for (var i = 0; i < group.Count - 1; i++)
            {
                if (group[i].XCoord == group[i + 1].XCoord)
                    FillAlongY(group[i], group[i + 1]);
                else if (group[i].YCoord == group[i + 1].YCoord)
                    FillAlongX(group[i], group[i + 1]);
                else
                    throw new InvalidOperationException("No Line Found");
            }
        }

        if (HasFloor)
        {
            for (int i = 0; i <= MaxX - MinX; i++)
            {
                Grid[FloorY][i] = rock;
            }
        }

        Grid[Source.YCoord][Source.XCoord] = source;
    }

    private void FillAlongX(RockCoordinates first, RockCoordinates second)
    {
        var start = first.XCoord > second.XCoord ? second.XCoord : first.XCoord;
        var end = first.XCoord > second.XCoord ? first.XCoord : second.XCoord;

        for (var i = start; i <= end; i++)
        {
            Grid[first.YCoord - MinY][i - MinX] = rock;
        }
    }

    private void FillAlongY(RockCoordinates first, RockCoordinates second)
    {
        var start = first.YCoord > second.YCoord ? second.YCoord : first.YCoord;
        var end = first.YCoord > second.YCoord ? first.YCoord : second.YCoord;

        for (var i = start; i <= end; i++)
        {
            Grid[i - MinY][first.XCoord - MinX] = rock;
        }
    }

    public void PrintGrid()
    {
        var list = Grid.Select(x => string.Join("", x.Select(y => y.ToString()))).ToList();
        FileExtensions.WriteFile($@"..\..\..\..\{FileExtensions.GetFileOutputLocation("Advent14", $"RockOutput")}", list);
    }

    public bool RunSand()
    {
        var result = DropSand(Source.YCoord, Source.XCoord);
        return result;
    }

    private bool DropSand(int currentY, int currentX)
    {
        if (HasFloor && IsSource(currentY, currentX) && IsSourceBlocked())
        {
            Grid[currentY][currentX] = sand;
            return false;
        }
        
        if (!HasFloor && (currentY == MaxY || DoesFallOffLeftEdge(currentY, currentX) || DoesFallOffRightEdge(currentY, currentX)))
        {
            Grid[currentY][currentX] = disappear;
            return false;
        }
        else if (HasFloor)
        {
            if (DoesFallOffLeftEdge(currentY, currentX))
            {
                for (int i = 0; i <= FloorY; i++)
                {
                    Grid[i].Add(i == FloorY ? '#' : '.');
                    Grid[i].ShiftRight();
                }

                MaxX++;
                Source.XCoord++;
            }
            else if (DoesFallOffRightEdge(currentY, currentX))
            {
                for (int i = 0; i <= FloorY; i++)
                {
                    Grid[i].Add(i == FloorY ? '#' : '.');
                }
                
                MaxX++;
            }
        }

        var nextRowDown = currentY + 1;
        if (Grid[nextRowDown][currentX] == air)
        {
            Grid[currentY][currentX] = air;
            Grid[nextRowDown][currentX] = sand;
            return DropSand(nextRowDown, currentX);
        }
        
        if (currentX > 0 && Grid[nextRowDown][currentX - 1] == air)
        {
            Grid[currentY][currentX] = air;
            Grid[nextRowDown][currentX - 1] = sand;
            return DropSand(nextRowDown, currentX - 1);
        }
        
        if (currentX < MaxX - MinX && Grid[nextRowDown][currentX + 1] == air)
        {
            Grid[currentY][currentX] = air;
            Grid[nextRowDown][currentX + 1] = sand;
            return DropSand(nextRowDown, currentX + 1);
        }

        return true;
    }

    private bool IsSource(int currentY, int currentX)
    {
        return currentX == Source.XCoord && currentY == Source.YCoord;
    }
    
    private bool IsSourceBlocked()
    {
        var nextRowDown = Source.YCoord + 1;
        return IsRockOrSand(Grid[nextRowDown][Source.XCoord - 1]) && IsRockOrSand(Grid[nextRowDown][Source.XCoord]) && IsRockOrSand(Grid[nextRowDown][Source.XCoord + 1]);

    }

    private bool DoesFallOffLeftEdge(int currentY, int currentX)
    {
        var nextRowDown = currentY + 1;
        return currentX == 0 && IsRockOrSand(Grid[nextRowDown][0]) && IsRockOrSand(Grid[nextRowDown][1]);
    }

    private bool DoesFallOffRightEdge(int currentY, int currentX)
    {
        var nextRowDown = currentY + 1;
        return currentX == MaxX - MinX && IsRockOrSand(Grid[nextRowDown][MaxX - MinX]) && IsRockOrSand(Grid[nextRowDown][MaxX - MinX - 1]);
    }

    private bool IsRockOrSand(char item)
    {
        return item == rock || item == sand;
    }

    public int GetCountSand()
    {
        return Grid.Sum(x => x.Count(y => y == 'o'));
    }
}