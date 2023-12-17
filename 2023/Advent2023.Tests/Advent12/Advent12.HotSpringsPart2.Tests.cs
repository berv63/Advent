using Advent2023.Advent12;
using AdventShared;

namespace Advent2023.Tests.Advent12;

public class Advent12_HotSpringsTests_Part2
{
    private HotSprings SUT;

    [Theory]
    [InlineData("???.### 1,1,3", 1)]
    [InlineData(".??..??...?##. 1,1,3", 16384)]
    [InlineData("?#?#?#?#?#?#?#? 1,3,1,6", 1)]
    [InlineData("????.#...#... 4,1,1", 16)]
    [InlineData("????.######..#####. 1,6,5", 2500)]
    [InlineData("?###???????? 3,2,1", 506250)]
    [InlineData("????.?#?????.# 2,1,3,1", 506250)]
    public void GetValidUnfoldedSpringPermutationIndividual(string input, int result)
    {
        SUT = new HotSprings(new List<string>{input});
        Assert.Equal(result, SUT.GetValidUnfoldedPermutations(5));
    }

    [Fact]
    public void GetPairDistanceSumExpanded_Practice()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new HotSprings(fileData);
        Assert.Equal(525152 , SUT.GetValidUnfoldedPermutations(5));
    }

    [Fact]
    public void GetPairDistanceSumExpanded_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
        var output = FileExtensions.ReadFile(@"..\..\..\..\Files\Advent12\Result.txt");

        SUT = new HotSprings(fileData, output);
        var result = SUT.GetValidUnfoldedPermutations(5);
        Assert.Equal(707505470642, result);
    }
}
