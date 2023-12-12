using Advent2023.Advent11;
using AdventShared;

namespace Advent2023.Tests.Advent11;

public class Advent11_CosmicExpansionTests_Part1
{
    private CosmicExpansion SUT;

    [Theory]
    [InlineData(1, 7, 15)]
    [InlineData(3, 6, 17)]
    [InlineData(5, 9, 9)]
    [InlineData(8, 9, 5)]
    public void GetPairDistance_Practice(int index1, int index2, int distance)
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new CosmicExpansion(fileData);
        Assert.Equal(distance, SUT.GetIndividualDistances(index1, index2));
    }

    [Fact]
    public void GetPairDistanceSum_Practice()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new CosmicExpansion(fileData);
        Assert.Equal(374, SUT.GetDistanceSum());
    }

    [Fact]
    public void GetPairDistanceSum_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new CosmicExpansion(fileData);
        var result = SUT.GetDistanceSum();
        Assert.Equal(10885634, result);
    }
}
