using AdventShared;

namespace Advent2023.Advent11;

public class CosmicExpansion
{
    private CosmicMap Map { get; set; }

    public CosmicExpansion(List<string> input)
    {
        Map = new CosmicMap(input);
    }

    public long GetDistanceSum(int expansion = 2)
    {
        Map.ChartGalaxies();
        Map.CalculateGalaxyDistances(expansion);
        return Map.SumShortestDistances;
    }

    public long GetIndividualDistances(int index1, int index2)
    {
        Map.ChartGalaxies();
        Map.CalculateGalaxyDistances(2);
        return Map.DistancePairs[(index1, index2)];
    }
}
