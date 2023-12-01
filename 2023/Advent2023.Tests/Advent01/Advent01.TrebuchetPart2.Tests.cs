using AdventShared;

namespace Advent2023.Tests.Advent01;

public class Advent01_TrebuchetTests_Part2
{
    private Trebuchet SUT = new();

    [Theory]
    [InlineData("nine", 99)]
    [InlineData("eight", 88)]
    [InlineData("seven", 77)]
    [InlineData("six", 66)]
    [InlineData("five", 55)]
    [InlineData("four", 44)]
    [InlineData("three", 33)]
    [InlineData("two", 22)]
    [InlineData("one", 11)]
    public void LettersAsNumbers(string input, int output)
    {
        SUT.CalibrateIncludingSpelledOutNumbers(new List<string>{ input });
        Assert.Equal(output, SUT.Sum);
    }

    [Theory]
    [InlineData("eightwothree", 83)]
    [InlineData("seveneightwo", 72)]
    public void LettersAsNumbersTiedTogether_FirstAndLastNumbersUsed(string input, int output)
    {
        SUT.CalibrateIncludingSpelledOutNumbers(new List<string>{ input });
        Assert.Equal(output, SUT.Sum);
    }

    [Theory]
    [InlineData("oneight", 18)]
    [InlineData("twone", 21)]
    [InlineData("threeight", 38)]
    [InlineData("fiveight", 58)]
    [InlineData("sevenine", 79)]
    [InlineData("eightwo", 82)]
    [InlineData("eighthree", 83)]
    [InlineData("nineight", 98)]
    //these are the case that have no clarification in the  instructions but doesnt appear to happen in the test data
    public void LettersAsNumbersTiedTogetherAsFirstAndLast_FirstAndLastNumbersUsed(string input, int output)
    {
        SUT.CalibrateIncludingSpelledOutNumbers(new List<string>{ input });
        Assert.Equal(output, SUT.Sum);
    }

    [Theory]
    [InlineData("two1nine", 29)]
    [InlineData("eightwothree", 83)]
    [InlineData("abcone2threexyz", 13)]
    [InlineData("xtwone3four", 24)]
    [InlineData("4nineeightseven2", 42)]
    [InlineData("zoneight234", 14)]
    [InlineData("7pqrstsixteen", 76)]
    public void LettersAsNumbers_Given(string input, int output)
    {
        SUT.CalibrateIncludingSpelledOutNumbers(new List<string>{ input });
        Assert.Equal(output, SUT.Sum);
    }

    [Fact]
    public void TrebuchetLettersAsNumbersSum_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT.CalibrateIncludingSpelledOutNumbers(fileData);
        Assert.NotEqual(52769, SUT.Sum);
        Assert.NotEqual(53255, SUT.Sum);
        Assert.Equal(53268, SUT.Sum);
    }
}
