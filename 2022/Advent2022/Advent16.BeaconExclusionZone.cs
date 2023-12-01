using Advent2022.Models.Advent16;

namespace Advent2022;

public static class ProboscideaVolcanium
{
    public static List<ValveTunnelModel>BuildValveTree(List<string> fileData)
    {
        var valves = new List<ValveTunnelModel>();
        var valveData = fileData.Select(x => x.Split(";").First()).ToList();
        foreach (var data in valveData)
        {
            valves.Add(new ValveTunnelModel(data));
        }
        
        var neighborData = fileData.Select(x => x.Split(";").Last()).ToList();
        for (int i = 0; i < valves.Count(); i++)
        {
            valves[i].MapNeighbors(neighborData[i], valves);
        }

        return valves;
    }
}