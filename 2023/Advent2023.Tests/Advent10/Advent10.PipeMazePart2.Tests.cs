using Advent2023.Advent10;
using AdventShared;

namespace Advent2023.Tests.Advent10;

public class Advent10_PipeMazeTests_Part2
{
    private PipeMaze SUT;

    [Fact]
    public void GetEnclosedTileCount_Practice2a()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new PipeMaze(fileData);
        Assert.Equal(9, SUT.GetEnclosedCount());
    }

    [Fact]
    public void GetEnclosedTileCount_Practice3()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new PipeMaze(fileData);
        Assert.Equal(4, SUT.GetEnclosedCount());
    }

    [Fact]
    public void GetEnclosedTileCount_Practice4()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new PipeMaze(fileData);
        Assert.Equal(8, SUT.GetEnclosedCount());
    }

    [Fact]
    public void GetEnclosedTileCount_Practice5()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new PipeMaze(fileData);
        Assert.Equal(10, SUT.GetEnclosedCount());
    }

    [Fact]
    public void GetEnclosedTileCount_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new PipeMaze(fileData);
        var result = SUT.GetEnclosedCount();
        Assert.NotEqual(1425, result);
        Assert.Equal(493, result);
    }
}
