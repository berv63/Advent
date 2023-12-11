using Advent2023.Advent08;
using AdventShared;

namespace Advent2023.Advent10;

public class MazeNode
{
    public char Value { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }

    public int? MinDistance => Distance1 < Distance2 ? Distance1 : Distance2;
    public int? Distance1 { get; set; }
    public int? Distance2 { get; set; }

    public bool IsPartOfLoop => MinDistance != null;

    public bool IsInsideLoopVertically { get; set; } = false;
    public bool IsInsideLoopHorizontally { get; set; } = false;
    public bool IsInsideLoop => IsInsideLoopHorizontally && IsInsideLoopVertically;

    public bool IsOutsideLoopVertically { get; set; } = false;
    public bool IsOutsideLoopHorizontally { get; set; } = false;
    public bool IsOutsideLoop => IsOutsideLoopHorizontally && IsOutsideLoopVertically;

    public bool PointsNorth => Value is '|' or 'L' or 'J' or 'S';
    public bool ConnectsNorth => PointsNorth && (NorthNode?.PointsSouth ?? false);
    public MazeNode? NorthNode { get; set; }

    public bool PointsSouth => Value is '|' or 'F' or '7' or 'S';
    public bool ConnectsSouth => PointsSouth && (SouthNode?.PointsNorth ?? false);
    public MazeNode? SouthNode { get; set; }

    public bool PointsEast => Value is '-' or 'L' or 'F' or 'S';
    public bool ConnectsEast => PointsEast && (EastNode?.PointsWest ?? false);
    public MazeNode? EastNode { get; set; }

    public bool PointsWest => Value is '-' or 'J' or '7' or 'S';
    public bool ConnectsWest => PointsWest && (WestNode?.PointsEast ?? false);
    public MazeNode? WestNode { get; set; }

    public MazeNode(char value, int row, int column)
    {
        Value = value;
        Row = row;
        Column = column;
    }

    public void PopulateConnectedValues()
    {
        return;
    }

    public Direction GetStartDirection1()
    {
        if (ConnectsNorth)
            return Direction.North;
        if (ConnectsSouth)
            return Direction.South;
        if (ConnectsEast)
            return Direction.East;

        return Direction.West;
    }

    public Direction GetStartDirection2()
    {
        if (ConnectsWest)
            return Direction.West;
        if (ConnectsEast)
            return Direction.East;
        if (ConnectsSouth)
            return Direction.South;

        return Direction.North;
    }

    public MazeNode? GetNextNode(ref Direction entrance, int distance, int direction)
    {
        if(direction == 1)
            Distance1 = distance;
        else
            Distance2 = distance;

        if (entrance != Direction.North && ConnectsNorth)
        {
            entrance = Direction.South;
            return NorthNode!;
        }

        if(entrance != Direction.South && ConnectsSouth)
        {
            entrance = Direction.North;
            return SouthNode!;
        }

        if(entrance != Direction.West && ConnectsWest)
        {
            entrance = Direction.East;
            return WestNode!;
        }

        if(entrance != Direction.East && ConnectsEast)
        {
            entrance = Direction.West;
            return EastNode!;
        }

        return null;
    }
}
