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
        MazeMap.CalculateLoopDistances();
        return MazeMap.FurthestPoint;
    }

    //not right at all...
    public int GetEnclosedCount()
    {
        MazeMap.CalculateLoopDistances();
        return MazeMap.EnclosedCount;
    }
}
