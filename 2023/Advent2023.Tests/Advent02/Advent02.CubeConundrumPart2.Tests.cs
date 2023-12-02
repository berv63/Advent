using Advent2023.Advent02;
using AdventShared;

namespace Advent2023.Tests.Advent02;

public class Advent02_CubeConundrumTests_Part2
{
    private CubeConundrum SUT = new();

    [Fact]
    public void EmptyInput_ReturnsZero()
    {
        var input = new List<string>();
        SUT.PlayGames(input);
        Assert.Equal(0, SUT.GetMinimumDrawPowerSum());
    }

    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 4*2*6)]
    [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 1*3*4)]
    [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 20*13*6)]
    [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 14*3*15)]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 6*3*2)]
    public void TestGame_ReturnsResult(string input, int result)
    {
        SUT.PlayGames(new List<string> {input});
        Assert.Equal(result, SUT.GetMinimumDrawPowerSum());
    }

    [Fact]
    public void TestGames_ReturnsSum()
    {
        var input = new List<string>
        {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
        };
        SUT.PlayGames(input);
        Assert.Equal(2286, SUT.GetMinimumDrawPowerSum());
    }


    [Fact]
    public void CubeConundrumSum_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT.PlayGames(fileData);
        Assert.Equal(65371, SUT.GetMinimumDrawPowerSum());
    }
}
