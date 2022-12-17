using Advent2022.Models.Advent14;

namespace Advent2022;

public static class RegolithReservoir
{
    public static List<List<RockCoordinates>> BuildRockCoordinates(List<string> fileData)
    {
        var result = new List<List<RockCoordinates>>();
        foreach (var row in fileData)
        {
            result.Add(row.Split("->").Select(x => new RockCoordinates(x)).ToList());
        }

        return result;
    }
    
    public static RockGrid BuildRockGrid(List<List<RockCoordinates>> coordinates, bool hasFloor = false)
    {
        return new RockGrid(coordinates, hasFloor);
    }

    public static int GetCountSettled(RockGrid grid)
    {
        bool settled;
        var countSand = 0;
        do
        {
            settled = grid.RunSand();
        } while (settled);

        grid.PrintGrid();
        return grid.GetCountSand();
    }
}