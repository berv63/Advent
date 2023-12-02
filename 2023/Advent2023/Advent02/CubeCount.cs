namespace Advent2023.Advent02;

public class CubeCount
{
    public int RedCount { get; set; }
    public int GreenCount { get; set; }
    public int BlueCount { get; set; }

    public int Power => BlueCount * RedCount * GreenCount;
}
