using AdventShared;

namespace Advent2023.Advent11;

public class CosmicMap
{
    private List<List<char>> Map = new();
    private List<List<char>>? RotatedMap { get; set; }
    private List<Galaxy> Galaxies = new();

    public Dictionary<(int, int), long> DistancePairs => GetDistancePairs();
    public long SumShortestDistances => DistancePairs.Sum(x => x.Value);

    public CosmicMap(List<string> input)
    {
        Map = input.Select(x => x.Select(y => y).ToList()).ToList();
    }

    public void ExpandMap(int expandedCount)
    {
        ExpandRows(expandedCount);
        RotateMapClockwise();
        ExpandRows(expandedCount);
        RotateMapClockwise();
        RotateMapClockwise();
        RotateMapClockwise();
    }

    private void ExpandRows(int expandedCount)
    {
        var result = new List<List<char>>();
        foreach (var row in Map)
        {
            if (row.All(x => x == '.'))
            {
                for (int i = 1; i < expandedCount; i++)
                {
                    result.Add(row);
                }
            }

            result.Add(row);
        }
        Map = result;
    }

    private List<List<char>> RotateMapClockwise()
    {
        if (RotatedMap != null)
        {
            return RotatedMap;
        }

        var result = new List<List<char>>();
        for (var column = 0; column < Map[0].Count; column++)
        {
            var newRow = new List<char>();
            for (var row = Map.Count - 1; row >= 0; row--)
            {
                newRow.Add(Map[row][column]);
            }
            result.Add(newRow);
        }

        RotatedMap = result;
        return result;
    }

    public void ChartGalaxies()
    {
        var galaxyIndex = 1;
        
        for (var row = 0; row < Map.Count; row++)
        {
            for (var column = 0; column < Map[0].Count; column++)
            {
                if (Map[row][column] == '#')
                {
                    Galaxies.Add(new Galaxy(galaxyIndex++, row, column));
                }
            }
        }

        foreach (var galaxy in Galaxies)
        {
            galaxy.GalaxyPair = Galaxies.Where(x => x.Index != galaxy.Index).ToList();
        }
    }

    public void CalculateGalaxyDistances(int expansion)
    {
        foreach (var galaxy in Galaxies)
        {
            galaxy.CalculateShortestDistances(this, expansion);
        }
    }

    private Dictionary<(int,int), long> GetDistancePairs()
    {
        var result = new Dictionary<(int, int), long>();

        foreach (var galaxy in Galaxies)
        {
            foreach (var pairDistance in galaxy.GalaxyPairDistance)
            {
                var pair = galaxy.Index < pairDistance.Key
                    ? (galaxy.Index, pairDistance.Key)
                    : (pairDistance.Key, galaxy.Index);
                if (result.ContainsKey(pair))
                {
                    continue;
                }

                result.Add(pair, pairDistance.Value);
            }
        }

        return result;
    }


    public long GetEmptyRowCountBetween(int x1, int x2)
    {
        return Map.Where((row, index) => index > x1 && index < x2 && row.All(x => x == '.')).Count();
    }

    public long GetEmptyColumnCountBetween(int y1, int y2)
    {
        return RotateMapClockwise().Where((row, index) => index > y1 && index < y2 && row.All(x => x == '.')).Count();
    }
}
