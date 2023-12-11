using AdventShared;

namespace Advent2023.Advent10;

public class PipeMaze
{
    private Maze MazeMap { get; set; }

    public PipeMaze(List<string> input)
    {
        MazeMap = new Maze(input);
    }

    public int GetFurthestPoint()
    {
        MazeMap.CalculateLoopDistances(false);
        return MazeMap.FurthestPoint;
    }

    public int GetEnclosedCount()
    {
        MazeMap.CalculateLoopDistances(true);
        MazeMap.CalculateEnclosedCount();
        return MazeMap.EnclosedCount;
    }
}
