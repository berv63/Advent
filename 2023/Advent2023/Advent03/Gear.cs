namespace Advent2023.Advent03;

public class Gear {
    public int Number1 { get; set; }
    public int Number2 { get; set; }

    public int GearRatio => Number1 * Number2;
}
