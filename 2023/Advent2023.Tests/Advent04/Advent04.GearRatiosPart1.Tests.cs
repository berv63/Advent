using Advent2023.Advent03;
using Advent2023.Advent04;
using AdventShared;

namespace Advent2023.Tests.Advent04;

public class Advent04_ScratchCardsTests_Part1
{
    private ScratchCards SUT;

    [Fact]
    public void EmptyInput_ReturnsZero()
    {
        var input = new List<string>();
        SUT = new ScratchCards(input);
        Assert.Equal(0, SUT.GetPointsTotal());
    }


    [Theory]
    [InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 8)]
    [InlineData("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2)]
    [InlineData("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", 2)]
    [InlineData("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", 1)]
    [InlineData("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", 0)]
    [InlineData("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", 0)]
    public void PartNumber_GivesOutput(string input, int score)
    {
        SUT = new ScratchCards(new List<string>{input});
        Assert.Equal(score, SUT.GetPointsTotal());
    }


    [Fact]
    public void PartNumberSum_Practice()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new ScratchCards(fileData);
        Assert.Equal(13, SUT.GetPointsTotal());
    }


    [Fact]
    public void PartNumberSum_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new ScratchCards(fileData);
        Assert.Equal(22674, SUT.GetPointsTotal());
    }
}
