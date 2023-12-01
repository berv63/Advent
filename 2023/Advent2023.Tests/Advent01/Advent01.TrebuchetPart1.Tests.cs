using AdventShared;

namespace Advent2023.Tests.Advent01;

public class Advent01_TrebuchetTests_Part1
{
    private Trebuchet SUT = new();

    [Fact]
    public void EmptyInput_ReturnsZero()
    {
        var input = new List<string>();
        SUT.Calibrate(input);
        Assert.Equal(0, SUT.Sum);
    }

    [Fact]
    public void TwoNumbersSeparatedByLetters_Combination()
    {
        var input = new List<string>{ "1abc2" };
        SUT.Calibrate(input);
        Assert.Equal(12, SUT.Sum);
    }

    [Fact]
    public void TwoNumbersLettersInFront_Combination()
    {
        var input = new List<string>{ "pqr3stu8vwx" };
        SUT.Calibrate(input);
        Assert.Equal(38, SUT.Sum);
    }

    [Fact]
    public void FourNumbers_FirstAndLastOnly()
    {
        var input = new List<string>{ "a1b2c3d4e5f" };
        SUT.Calibrate(input);
        Assert.Equal(15, SUT.Sum);
    }

    [Fact]
    public void OneNumber_DoubleUp()
    {
        var input = new List<string>{ "treb7uchet" };
        SUT.Calibrate(input);
        Assert.Equal(77, SUT.Sum);
    }

    [Fact]
    public void AddEmAllUp()
    {
        var input = new List<string>
        {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"
        };
        SUT.Calibrate(input);
        Assert.Equal(142, SUT.Sum);
    }

    [Fact]
    public void TrebuchetSum_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT.Calibrate(fileData);
        Assert.Equal(53080, SUT.Sum);
    }
}
