namespace Advent2023.Advent03;

public class GearRatios
{
    private Schematic Schematic { get; set; }

    public GearRatios(List<string> engineMap)
    {
        Schematic = new Schematic(engineMap);
    }

    public int GetPartNumberSums()
    {
        Schematic.PopulateParts();
        return Schematic.Parts.Sum(x => x.Number);
    }

    public int GetGearRatioSums()
    {
        Schematic.PopulateParts();
        return Schematic.Gears.Sum(x => x.GearRatio);
    }
}
