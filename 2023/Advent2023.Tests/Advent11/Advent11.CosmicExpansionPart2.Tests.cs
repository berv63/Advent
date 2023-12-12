using Advent2023.Advent11;
using AdventShared;

namespace Advent2023.Tests.Advent11;

public class Advent11_CosmicExpansionTests_Part2
{
    private CosmicExpansion SUT;

    [Theory]
    [InlineData(10, 1030)]
    [InlineData(100, 8410)]
    public void GetPairDistanceSumExpanded_Practice(int expansion, int result)
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new CosmicExpansion(fileData);
        Assert.Equal(result, SUT.GetDistanceSum(expansion));
    }

    [Fact]
    public void GetPairDistanceSumExpanded_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new CosmicExpansion(fileData);
        var result = SUT.GetDistanceSum(1000000);
        Assert.Equal(707505470642, result);
    }
}
