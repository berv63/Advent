using Advent2023.Advent03;
using Advent2023.Advent04;
using AdventShared;

namespace Advent2023.Tests.Advent04;

public class Advent04_ScratchCardsTests_Part2
{

    private ScratchCards SUT;

    [Fact]
    public void EmptyInput_ReturnsZero()
    {
        var input = new List<string>();
        SUT = new ScratchCards(input);
        Assert.Equal(0, SUT.GetCardCount());
    }

    [Fact]
    public void ScratchCardsum_Practice()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new ScratchCards(fileData);
        Assert.Equal(30, SUT.GetCardCount());
    }


    [Fact]
    public void ScratchCardsSum_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new ScratchCards(fileData);
        Assert.Equal(5747443, SUT.GetCardCount());
    }
}
