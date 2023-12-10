using Advent2023.Advent10;
using AdventShared;

namespace Advent2023.Tests.Advent10;

public class Advent10_PipeMazeTests_Part1
{
    private PipeMaze SUT;

    [Fact]
    public void GetFurthestMapDistance_Practice()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new PipeMaze(fileData);
        Assert.Equal(4, SUT.GetFurthestPoint());
    }

    [Fact]
    public void GetFurthestMapDistance_Practice2()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new PipeMaze(fileData);
        Assert.Equal(8, SUT.GetFurthestPoint());
    }

    [Fact]
    public void GetFurthestMapDistance_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new PipeMaze(fileData);
        var result = SUT.GetFurthestPoint();
        Assert.Equal(6773, result);
    }
}
