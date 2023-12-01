namespace Advent2022.Models.Advent17;

public class TetrisSquareShapeModel : TetrisShapeModel
{
    public TetrisSquareShapeModel()
    {
        Shape.Add(new List<char> {inMotion, inMotion});
        Shape.Add(new List<char> {inMotion, inMotion});
    }

    public override void DropShape(TetrisGridModel grid)
    {
        IsAtRest = !grid.IsTargetLocationAir(LowestPointYCoordinate + 1, LeftestPointXCoordinate) ||
                   !grid.IsTargetLocationAir(LowestPointYCoordinate + 1, LeftestPointXCoordinate + 1);

        if (!IsAtRest)
            LowestPointYCoordinate++;
    }

    public override void SlideShape(TetrisGridModel grid, char direction)
    {
        bool canSlide;
        if (direction == '<')
        {
            canSlide = grid.IsTargetLocationAir(LowestPointYCoordinate, LeftestPointXCoordinate - 1) &&
                       grid.IsTargetLocationAir(LowestPointYCoordinate - 1, LeftestPointXCoordinate - 1);
        }
        else
        {
            canSlide = grid.IsTargetLocationAir(LowestPointYCoordinate, LeftestPointXCoordinate + 2) &&
                       grid.IsTargetLocationAir(LowestPointYCoordinate - 1, LeftestPointXCoordinate + 2);
        }

        if (canSlide)
            LeftestPointXCoordinate = direction == '<' ? LeftestPointXCoordinate - 1 : LeftestPointXCoordinate + 1;
    }

    public override void CommitShape(TetrisGridModel grid)
    {
        grid.Grid[LowestPointYCoordinate][LeftestPointXCoordinate] = atRest;
        grid.Grid[LowestPointYCoordinate][LeftestPointXCoordinate+1] = atRest;
        grid.Grid[LowestPointYCoordinate-1][LeftestPointXCoordinate] = atRest;
        grid.Grid[LowestPointYCoordinate-1][LeftestPointXCoordinate+1] = atRest;
    }

    public override void SetShapeOnGrid(List<List<char>> grid)
    {
        grid[LowestPointYCoordinate][LeftestPointXCoordinate] = inMotion;
        grid[LowestPointYCoordinate][LeftestPointXCoordinate+1] = inMotion;

        if (LowestPointYCoordinate - 1 >= 0)
        {
            grid[LowestPointYCoordinate - 1][LeftestPointXCoordinate] = inMotion;
            grid[LowestPointYCoordinate - 1][LeftestPointXCoordinate + 1] = inMotion;
        }
    }
}