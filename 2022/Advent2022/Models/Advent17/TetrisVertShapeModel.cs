namespace Advent2022.Models.Advent17;

public class TetrisVertShapeModel : TetrisShapeModel
{
    public TetrisVertShapeModel()
    {
        Shape.Add(new List<char> {inMotion});
        Shape.Add(new List<char> {inMotion});
        Shape.Add(new List<char> {inMotion});
        Shape.Add(new List<char> {inMotion});
    }

    public override void DropShape(TetrisGridModel grid)
    {
        IsAtRest = !grid.IsTargetLocationAir(LowestPointYCoordinate + 1, LeftestPointXCoordinate);

        if (!IsAtRest)
            LowestPointYCoordinate++;
    }

    public override void SlideShape(TetrisGridModel grid, char direction)
    {
        bool canSlide;
        if (direction == '<')
        {
            canSlide = grid.IsTargetLocationAir(LowestPointYCoordinate, LeftestPointXCoordinate - 1) &&
                       grid.IsTargetLocationAir(LowestPointYCoordinate - 1, LeftestPointXCoordinate - 1) &&
                       grid.IsTargetLocationAir(LowestPointYCoordinate - 2, LeftestPointXCoordinate - 1) &&
                       grid.IsTargetLocationAir(LowestPointYCoordinate - 3, LeftestPointXCoordinate - 1);
        }
        else
        {
            canSlide = grid.IsTargetLocationAir(LowestPointYCoordinate, LeftestPointXCoordinate + 1) &&
                       grid.IsTargetLocationAir(LowestPointYCoordinate - 1, LeftestPointXCoordinate + 1) &&
                       grid.IsTargetLocationAir(LowestPointYCoordinate - 2, LeftestPointXCoordinate + 1) &&
                       grid.IsTargetLocationAir(LowestPointYCoordinate - 3, LeftestPointXCoordinate + 1);
        }

        if (canSlide)
            LeftestPointXCoordinate = direction == '<' ? LeftestPointXCoordinate - 1 : LeftestPointXCoordinate + 1;
    }

    public override void CommitShape(TetrisGridModel grid)
    {
        grid.Grid[LowestPointYCoordinate][LeftestPointXCoordinate] = atRest;
        grid.Grid[LowestPointYCoordinate-1][LeftestPointXCoordinate] = atRest;
        grid.Grid[LowestPointYCoordinate-2][LeftestPointXCoordinate] = atRest;
        grid.Grid[LowestPointYCoordinate-3][LeftestPointXCoordinate] = atRest;
    }

    public override void SetShapeOnGrid(List<List<char>> grid)
    {
        grid[LowestPointYCoordinate][LeftestPointXCoordinate] = inMotion;
        
        if(LowestPointYCoordinate-1 >= 0)
            grid[LowestPointYCoordinate-1][LeftestPointXCoordinate] = inMotion;
        
        if(LowestPointYCoordinate-2 >= 0)
            grid[LowestPointYCoordinate-2][LeftestPointXCoordinate] = inMotion;
        
        if(LowestPointYCoordinate-3 >= 0)
            grid[LowestPointYCoordinate-3][LeftestPointXCoordinate] = inMotion;
    }
}