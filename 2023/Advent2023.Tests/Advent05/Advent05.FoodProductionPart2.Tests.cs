using System.Diagnostics;
using Advent2023.Advent03;
using Advent2023.Advent04;
using Advent2023.Advent05;
using AdventShared;

namespace Advent2023.Tests.Advent05;

public class Advent05_FertilizerTests_Part2
{

    private FoodProduction SUT;

    [Fact]
    public void FertilizerSum_Practice()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new FoodProduction(fileData, true);
        Assert.Equal(46, SUT.GetClosestInitialSeedLocationRanged());
    }

    [Fact]
    public void FertilizerSum2_Practice()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new FoodProduction(fileData, true);
        Assert.Equal(46, SUT.GetClosestInitialSeedLocationRanged2());
    }

    [Fact]
    public void FertilizerSum_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new FoodProduction(fileData, true);
        Assert.Equal(26714516, SUT.GetClosestInitialSeedLocationRanged2());
    }
}
