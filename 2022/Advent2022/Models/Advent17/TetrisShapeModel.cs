namespace Advent2022.Models.Advent17;

public abstract class TetrisShapeModel
{
    public List<List<char>> Shape { get; set; } = new();
    
    public bool IsAtRest { get; set; }

    public int LowestPointYCoordinate { get; set; } = -1;
    public int LeftestPointXCoordinate { get; set; } = 2;

    public char air = '.';
    public char inMotion = '@';
    public char atRest = '#';
   
    public abstract void DropShape(TetrisGridModel grid);
    public abstract void SlideShape(TetrisGridModel grid, char direction);
    public abstract void CommitShape(TetrisGridModel grid);
    public abstract void SetShapeOnGrid(List<List<char>> grid);
}