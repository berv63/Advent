namespace Advent2022.Models.Advent15;

public class BeaconModel
{
    public int Index { get; set; }
    public int XCoordinate { get; set; }
    public int YCoordinate { get; set; }


    public BeaconModel(int index, int x, int y)
    {
        Index = index;
        
        XCoordinate = x;
        YCoordinate = y;
    }
}