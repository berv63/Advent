using AdventShared;

namespace Advent2023.Advent11;

public class Galaxy
{
    public List<Galaxy> GalaxyPair { get; set; } = new();
    public Dictionary<int, long> GalaxyPairDistance { get; set; } = new();

    public int Index { get; set; }

    private int Row { get; set; }
    private int Column { get; set; }

    public Galaxy(int index, int x, int y)
    {
        Index = index;
        Row = x;
        Column = y;
    }

    public void CalculateShortestDistances(CosmicMap map, int expansion)
    {
        foreach (var galaxy in GalaxyPair)
        {
            if (GalaxyPairDistance.Keys.Contains(galaxy.Index))
                continue;

            var x1 = Row < galaxy.Row ? Row : galaxy.Row;
            var x2 = Row > galaxy.Row ? Row : galaxy.Row;

            var y1 = Column < galaxy.Column ? Column : galaxy.Column;
            var y2 = Column > galaxy.Column ? Column : galaxy.Column;

            var rowExpansion = (map.GetEmptyRowCountBetween(x1, x2)) * (expansion - 1);
            var columnExpansion = (map.GetEmptyColumnCountBetween(y1, y2)) * (expansion - 1);

            var distance = (x2 - x1) + (y2 - y1) + rowExpansion + columnExpansion;
            GalaxyPairDistance.Add(galaxy.Index, distance);
            galaxy.GalaxyPairDistance.Add(Index, distance);
        }
    }
}
