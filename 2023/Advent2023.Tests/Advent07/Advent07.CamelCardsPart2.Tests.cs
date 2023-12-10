using Advent2023.Advent07;
using AdventShared;

namespace Advent2023.Tests.Advent07;

public class Advent07_CamelCardsTests_Part2
{

    private CamelCards SUT;

    [Fact]
    public void JokerHandWinnings_Practice()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new CamelCards(fileData, true);
        Assert.Equal(5905, SUT.CalculateWinnings());
    }

    [Fact]
    public void JokerHandWinningsDebug_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new CamelCards(fileData, true);
        SUT.PrintSortedHands();
    }

    [Fact]
    public void JokerHandWinnings_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new CamelCards(fileData, true);
        Assert.NotEqual(249781859, SUT.CalculateWinnings());
        Assert.NotEqual(249822710, SUT.CalculateWinnings());
        Assert.Equal(249781879, SUT.CalculateWinnings());
    }
}
