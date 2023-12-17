using Advent2023.Advent12;
using AdventShared;

namespace Advent2023.Tests.Advent12;

public class Advent12_HotSpringsTests_Part1
{
    private HotSprings SUT;

    [Theory]
    [InlineData("???.### 1,1,3", 1)]
    [InlineData(".??..??...?##. 1,1,3", 4)]
    [InlineData("?#?#?#?#?#?#?#? 1,3,1,6", 1)]
    [InlineData("????.#...#... 4,1,1", 1)]
    [InlineData("????.######..#####. 1,6,5", 4)]
    [InlineData("?###???????? 3,2,1", 10)]
    public void GetValidSpringPermutationIndividual(string input, int result)
    {
        SUT = new HotSprings(new List<string> {input});
        Assert.Equal(result, SUT.GetValidPermutations());
    }

    [Fact]
    public void GetValidSpringPermutationSum_Practice()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new HotSprings(fileData);
        Assert.Equal(21, SUT.GetValidPermutations());
    }

    [Fact]
    public void GetValidSpringPermutationSum_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new HotSprings(fileData);
        var result = SUT.GetValidPermutations();
        Assert.Equal(6935, result);
    }
}
