using Advent2023.Advent08;
using AdventShared;

namespace Advent2023.Tests.Advent08;

public class Advent08_HauntedWastelandTests_Part2
{

    private HauntedWasteland SUT;

    [Fact]
    public void NavigateMultipleGhostSteps_Practice3()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new HauntedWasteland(fileData);
        Assert.Equal((ulong)6, SUT.DoLonger());
    }

    [Fact]
    public void NavigateMultipleGhostSteps_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new HauntedWasteland(fileData);
        var result = SUT.DoLonger();
        Assert.NotEqual((ulong)1067680175, result);
        Assert.NotEqual((ulong)53715412391, result);
        Assert.Equal((ulong)14449445933179, result);
    }
}
