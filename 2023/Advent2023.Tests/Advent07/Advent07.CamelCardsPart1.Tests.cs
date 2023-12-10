using Advent2023.Advent07;
using AdventShared;

namespace Advent2023.Tests.Advent07;

public class Advent07_CamelCardsTests_Part1
{
    private CamelCards SUT;

    [Fact]
    public void HandWinnings_Practice()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new CamelCards(fileData);
        Assert.Equal(6440, SUT.CalculateWinnings());
    }


    [Fact]
    public void HandWinnings_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new CamelCards(fileData);
        Assert.Equal(251058093, SUT.CalculateWinnings());
    }
}
