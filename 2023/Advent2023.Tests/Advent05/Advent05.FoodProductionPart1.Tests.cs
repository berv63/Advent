using Advent2023.Advent03;
using Advent2023.Advent04;
using Advent2023.Advent05;
using AdventShared;

namespace Advent2023.Tests.Advent05;

public class Advent05_FertilizerTests_Part1
{
    private FoodProduction SUT;

    [Fact]
    public void ClosestLocation_Practice()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new FoodProduction(fileData);
        Assert.Equal(35, SUT.GetClosestInitialSeedLocation());
    }


    [Fact]
    public void ClosestLocation_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new FoodProduction(fileData);
        Assert.Equal(84470622, SUT.GetClosestInitialSeedLocation());
    }
}
