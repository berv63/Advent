using Advent2023.Advent03;
using AdventShared;

namespace Advent2023.Tests.Advent03;

public class Advent03_GearRatiosTests_Part1
{
    private GearRatios SUT;

    [Fact]
    public void EmptyInput_ReturnsZero()
    {
        var input = new List<string>();
        SUT = new GearRatios(input);
        Assert.Equal(0, SUT.GetPartNumberSums());
    }


    [Fact]
    public void PartNumberSum_Practice()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new GearRatios(fileData);
        Assert.Equal(4361, SUT.GetPartNumberSums());
    }


    [Fact]
    public void PartNumberSum_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new GearRatios(fileData);
        Assert.NotEqual(494831, SUT.GetPartNumberSums());
        Assert.Equal(556367, SUT.GetPartNumberSums());
    }
}
