using Advent2023.Advent06;
using AdventShared;

namespace Advent2023.Tests.Advent06;

public class Advent06_WaitForItTests_Part1
{
    private WaitForIt SUT;

    [Fact]
    public void WinningMultiplier_Practice()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new WaitForIt(fileData);
        Assert.Equal(288, SUT.Do());
    }


    [Fact]
    public void WinningMultiplier_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new WaitForIt(fileData);
        Assert.Equal(128700, SUT.Do());
    }
}
