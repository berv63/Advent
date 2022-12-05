using Advent2022.Models;
using AdventShared;

namespace Advent2022;

public static class SupplyStacks
{
    public static Dictionary<int, List<char>> BuildSupplyStacks(List<string> stackStrings)
    {
        var stacks = new Dictionary<int, List<char>>();
        
        var stackCount = (stackStrings.First().Length + 1) / 4;
        foreach (var stackString in stackStrings)
        {
            for (var i = 1; i <= stackCount; i++)
            {
                if(!stacks.ContainsKey(i))
                    stacks.Add(i, new List<char>());

                var value = stackString[(i - 1) * 4 + 1];
                if(value != ' ')
                    stacks[i].Add(stackString[(i-1) * 4 + 1]);
            }
        }

        foreach (var stack in stacks)
        {
            stack.Value.Reverse();
        }

        return stacks;
    }

    public static CraneModel BuildCrane(List<string> instructionStrings)
    {
        return new CraneModel(instructionStrings);
    }

    public static string ExecuteInstructions(Dictionary<int, List<char>> stacks, CraneModel crane)
    {
        crane.ExecuteCrateMover9000(stacks);
        return GetTopItemsFromStacks(stacks);
    }

    public static string ExecuteMultiMoveInstructions(Dictionary<int, List<char>> stacks, CraneModel crane)
    {
        crane.ExecuteCrateMover9001(stacks);
        return GetTopItemsFromStacks(stacks);
    }
    
    private static string GetTopItemsFromStacks(Dictionary<int, List<char>> stacks)
    {
        return string.Join("", stacks.Select(x => x.Value.Last()));
    }
}