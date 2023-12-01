using Advent2022.Models.Advent14;
using Advent2022.Models.Advent17;
using AdventShared;

namespace Advent2022;

public static class PyroclasticFlow
{
    public static TetrisGridModel ProcessGame(List<string> fileData, int rounds)
    {
        var instructions = fileData.First().ToList(); 
        
        var grid = new TetrisGridModel();
        var instructionIndex = 0;
        for (var i = 0; i < rounds; i++)
        {
            grid.AddGapToGrid();
            var shape = GetNextShape(i);
            while (!shape.IsAtRest)
            {
                shape.DropShape(grid);

                if (!shape.IsAtRest)
                { 
                    shape.SlideShape(grid, GetNextInstruction(instructions, instructionIndex++));
                }
                else
                {
                    shape.CommitShape(grid);
                }
            }
            
        }

        grid.PrintGrid();
        return grid;
    }
    
    private static TetrisShapeModel GetNextShape(int index)
    {
        return (index % 5) switch
        {
            0 => new TetrisFlatShapeModel(),
            1 => new TetrisTeeShapeModel(),
            2 => new TetrisEllShapeModel(),
            3 => new TetrisVertShapeModel(),
            4 => new TetrisSquareShapeModel(),
            _ => throw new InvalidCastException("Error retrieving shape model")
        };
    }

    private static char GetNextInstruction(List<char> instructions, int index)
    {
        var length = instructions.Count;
        return instructions[index % length];
    }
    
    public static int GetTowerHeight(TetrisGridModel grid)
    {
        return grid.GetGridHeight();
    }
}