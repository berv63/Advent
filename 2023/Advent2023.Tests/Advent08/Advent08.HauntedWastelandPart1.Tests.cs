using Advent2023.Advent08;
using AdventShared;

namespace Advent2023.Tests.Advent08;

public class Advent08_HauntedWastelandTests_Part1
{
    private HauntedWasteland SUT;

    [Fact]
    public void NavigateCamelSteps_Practice()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new HauntedWasteland(fileData);
        Assert.Equal(2, SUT.Do());
    }

    [Fact]
    public void NavigateCamelSteps_Practice2()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new HauntedWasteland(fileData);
        Assert.Equal(6, SUT.Do());
    }

    [Fact]
    public void NavigateCamelSteps_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new HauntedWasteland(fileData);
        Assert.Equal(18023, SUT.Do());
    }
}
