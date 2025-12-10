namespace Advent2025.Advent09;

public class Rectangle
{
    public int Id { get; set; }
    
    public Tile Tile1 { get; set; }
    public Tile Tile2 { get; set; }
    
    public ulong Area =>
        ((ulong)Math.Abs(Tile2.XCoordinate - Tile1.XCoordinate) + 1) *
        ((ulong)Math.Abs(Tile2.YCoordinate - Tile1.YCoordinate) + 1);

    public Rectangle(Tile tile1, Tile tile2, int id)
    {
        Id = id;
        Tile1 = tile1;
        Tile2 = tile2;
    }
}