namespace Advent2025.Advent09;

public class Tile
{
    public int Id { get; set; }
    public int XCoordinate { get; set; }
    public int YCoordinate { get; set; }
    
    public Dictionary<int, ulong> TileAreas { get; set; } = new();

    public Tile(string input, int id)
    {
        var stringParts = input.Split(',').ToList();
        XCoordinate = int.Parse(stringParts[0]);
        YCoordinate = int.Parse(stringParts[1]);
        Id = id;
    }
    
    public void CalculateTileAreas(List<Tile> tiles)
    {
        foreach (var tile in tiles)
        {
            if (tile.Id == Id || TileAreas.ContainsKey(tile.Id))
            {
                continue;
            }
            
            var area = ((ulong)Math.Abs(tile.XCoordinate - XCoordinate) + 1) * ((ulong)Math.Abs(tile.YCoordinate - YCoordinate) + 1);
            
            TileAreas[tile.Id] = area;
            tile.TileAreas[Id] = area;
        }
    }
}