using System.Runtime.CompilerServices;
using AdventShared;

namespace Advent2022.Models.Advent14;

public class RockGrid
{
    private List<List<char>> Grid { get; set; } = new();
    
    private RockCoordinates Source { get; set; }
    
    private int MinX { get; set; }
    private int MinY { get; set; }
    
    private int MaxX { get; set; }
    private int MaxY { get; set; }
    
    private bool HasFloor { get; set; }
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
        return HasFloor ? DropSandWithFloor(Source.YCoord, Source.XCoord) : DropSand(Source.YCoord, Source.XCoord);
    }

    private bool DropSandWithFloor(int currentY, int currentX)
    {
        if (IsSource(currentY, currentX) && IsSourceBlocked())
        {
            Grid[currentY][currentX] = sand;
            return false;
        }
        
        if (DoesFallOffLeftEdge(currentY, currentX))
            AddNewColumnToTheLeft();
        else if (DoesFallOffRightEdge(currentY, currentX))
            AddNewColumnToTheRight();

        var nextRowDown = currentY + 1;
        var (isAir, targetY, targetX) = IsTargetAirWithCoordinates(currentY, currentX, nextRowDown, currentX);
        if (isAir)
            return DropSandWithFloor(targetY, targetX);
        
        (isAir, targetY, targetX) = IsTargetAirWithCoordinates(currentY, currentX, nextRowDown, currentX - 1);
        if (isAir)
            return DropSandWithFloor(targetY, targetX);
        
        (isAir, targetY, targetX) = IsTargetAirWithCoordinates(currentY, currentX, nextRowDown, currentX + 1);
        if (isAir)
            return DropSandWithFloor(targetY, targetX);

        return true;
    }

    private bool DropSand(int currentY, int currentX)
    {
        if ((currentY == MaxY || DoesFallOffLeftEdge(currentY, currentX) || DoesFallOffRightEdge(currentY, currentX)))
        {
            Grid[currentY][currentX] = disappear;
            return false;
        }

        var nextRowDown = currentY + 1;
        var (isAir, targetY, targetX) = IsTargetAirWithCoordinates(currentY, currentX, nextRowDown, currentX);
        if (isAir)
            return DropSand(targetY, targetX);
        
        (isAir, targetY, targetX) = IsTargetAirWithCoordinates(currentY, currentX, nextRowDown, currentX - 1);
        if (isAir)
            return DropSand(targetY, targetX);
        
        (isAir, targetY, targetX) = IsTargetAirWithCoordinates(currentY, currentX, nextRowDown, currentX + 1);
        if (isAir)
            return DropSand(targetY, targetX);

        return true;
    }

    private void AddNewColumnToTheLeft()
    {
        for (var i = 0; i <= FloorY; i++)
        {
            Grid[i].Add(i == FloorY ? '#' : '.');
            Grid[i].ShiftRight();
        }

        MaxX++;
        Source.XCoord++;
    }
    
    private void AddNewColumnToTheRight()
    {
        for (var i = 0; i <= FloorY; i++)
        {
            Grid[i].Add(i == FloorY ? '#' : '.');
        }
            
        MaxX++;
    }
    
    private (bool, int, int) IsTargetAirWithCoordinates(int currentY, int currentX, int targetY, int targetX)
    {
        if(IsTargetOutOfGridBounds(targetY, targetX) || IsRockOrSand(Grid[targetY][targetX]))
            return (false, currentY, currentX); 
    
        Grid[currentY][currentX] = air;
        Grid[targetY][targetX] = sand;

        return (true, targetY, targetX);
    }

    private bool IsTargetOutOfGridBounds(int targetY, int targetX)
    {
        return targetX < 0 || targetX > MaxX - MinX || targetY > FloorY;
    }

    private bool IsSource(int currentY, int currentX)
    {
        return currentX == Source.XCoord && currentY == Source.YCoord;
    }
    
    private bool IsSourceBlocked()
    {
        var nextRowDown = Source.YCoord + 1;
        return IsRockOrSand(Grid[nextRowDown][Source.XCoord - 1]) && 
               IsRockOrSand(Grid[nextRowDown][Source.XCoord]) && 
               IsRockOrSand(Grid[nextRowDown][Source.XCoord + 1]);

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
        return item is rock or sand;
    }

    public int GetCountSand()
    {
        return Grid.Sum(x => x.Count(y => y == 'o'));
    }
}