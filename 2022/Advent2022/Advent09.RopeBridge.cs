using System.Data;
using System.Runtime.CompilerServices;
using Advent2022.Models;
using AdventShared;

namespace Advent2022;

public static class RopeBridge
{
    public static List<HeadTailCommandModel> BuildCommands(List<string> fileData)
    {
        return fileData.Select(x => new HeadTailCommandModel(x)).ToList();
    }

    public static HeadTailGridModel GetGrid(List<HeadTailCommandModel> commands, int indices)
    {
        var grid = new HeadTailGridModel(indices);
        foreach (var command in commands)
        {
            grid.MoveHead(command);
        }
        
        grid.PrintGrid();

        return grid;
    }

    public static int RunCommands(List<HeadTailCommandModel> commands, HeadTailGridModel grid, int indices)
    {
        grid.HeadTailIndex = new HeadTailIndexModel(grid.Grid, indices);
        foreach (var command in commands)
        {
            grid.RunCommand(command);
        }
        
        grid.PrintGrid();
        return grid.GetTailVisitCount();
    }
}