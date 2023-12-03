using Advent2023.Advent03;
using AdventShared;

namespace Advent2023.Tests.Advent03;

public class Advent03_GearRatiosTests_Part2
{

    private GearRatios SUT;

    [Fact]
    public void EmptyInput_ReturnsZero()
    {
        var input = new List<string>();
        SUT = new GearRatios(input);
        Assert.Equal(0, SUT.GetGearRatioSums());
    }

    [Fact]
    public void GearRatioSum_Practice()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new GearRatios(fileData);
        Assert.Equal(467835, SUT.GetGearRatioSums());
    }


    [Fact]
    public void GearRatiosSum_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new GearRatios(fileData);
        Assert.Equal(89471771, SUT.GetGearRatioSums());
    }
}
