using Advent2023.Advent09;
using AdventShared;

namespace Advent2023.Tests.Advent09;

public class Advent09_MirageMaintenanceTests_Part2
{
    private MirageMaintenance SUT;

    [Theory]
    [InlineData("0 3 6 9 12 15", -3)]
    [InlineData("1 3 6 10 15 21", 0)]
    [InlineData("10 13 16 21 30 45", 5)]
    public void GetPreviousSequenceValue(string input, int output)
    {
        SUT = new MirageMaintenance(new List<string> {input});
        Assert.Equal(output, SUT.ExtrapolatePastValue());
    }

    [Fact]
    public void GetPreviousSequenceSum_Practice()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new MirageMaintenance(fileData);
        Assert.Equal(2, SUT.ExtrapolatePastValue());
    }

    [Fact]
    public void GetPreviousSequenceSum_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new MirageMaintenance(fileData);
        Assert.Equal(1140, SUT.ExtrapolatePastValue());
    }
}
