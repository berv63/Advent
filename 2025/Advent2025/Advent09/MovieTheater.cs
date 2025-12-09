namespace Advent2025.Advent09;

public class MovieTheater
{
    public ulong LargestRectangleArea(List<string> input)
    {
        var id = 0;
        var tiles = input.Select(row => new Tile(row, id++)).ToList();
        
        foreach (var tile in tiles)
        {
            tile.CalculateTileAreas(tiles);
        }

        return tiles.SelectMany(x => x.TileAreas.Select(y => y.Value)).ToList().Max();
    }
}