using Advent2023.Advent06;
using AdventShared;

namespace Advent2023.Tests.Advent06;

public class Advent06_WaitForItTests_Part2
{

    private WaitForIt SUT;

    [Fact]
    public void LongerRaceWinnings_Practice()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new WaitForIt(fileData, true);
        Assert.Equal(71503, SUT.DoLonger());
    }

    [Fact]
    public void LongerRaceWinnings_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new WaitForIt(fileData, true);
        Assert.Equal(39594072, SUT.DoLonger());
    }
}
