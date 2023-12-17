using AdventShared;

namespace Advent2023.Advent12;

public class HotSprings
{
    private List<SpringRow> SpringRows { get; set; } = new();
    private Dictionary<int, int> Output { get; set; } = new();

    public HotSprings(List<string> input, List<string>? output = null)
    {
        foreach (var line in input)
        {
            SpringRows.Add(new SpringRow(line));
        }

        if (output != null)
        {
            for (var i = 0; i < output.Count; i++)
            {
                Output.Add(i, int.Parse(output[i]));
            }
        }
    }

    public long GetValidPermutations()
    {
        return SpringRows.Sum(row => row.Possibilities.Count);
    }

    public long GetValidUnfoldedPermutations(int copies)
    {
        var result = 0;
        for(var i = 0; i < SpringRows.Count; i ++)
        {
            if (Output.ContainsKey(i))
            {
                continue;
            }

            SpringRows[i].Unfold(copies);
            result += SpringRows[i].Possibilities.Count;

            FileExtensions.AppendFile(@"..\..\..\..\Files\Advent12\Result.txt", result.ToString());
        }
        return result;
    }
}
