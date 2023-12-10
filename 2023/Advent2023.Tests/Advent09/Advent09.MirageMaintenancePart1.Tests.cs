using Advent2023.Advent09;
using AdventShared;

namespace Advent2023.Tests.Advent09;

public class Advent09_MirageMaintenanceTests_Part1
{
    private MirageMaintenance SUT;

    [Theory]
    [InlineData("0 3 6 9 12 15", 18)]
    [InlineData("1 3 6 10 15 21", 28)]
    [InlineData("10 13 16 21 30 45", 68)]
    public void GetNextSequenceValue(string input, int output)
    {
        SUT = new MirageMaintenance(new List<string> {input});
        Assert.Equal(output, SUT.ExtrapolateFutureValue());
    }

    [Fact]
    public void GetFutureSequenceSum_Practice()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new MirageMaintenance(fileData);
        Assert.Equal(114, SUT.ExtrapolateFutureValue());
    }

    [Fact]
    public void GetFutureSequenceSum_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new MirageMaintenance(fileData);
        var result = SUT.ExtrapolateFutureValue();
        Assert.NotEqual(1819125967, result);
        Assert.Equal(1819125966, result);
    }
}
