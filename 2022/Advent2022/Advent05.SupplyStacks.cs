using Advent2022.Models;

namespace Advent2022;

public static class SupplyStacks
{
    public static Dictionary<int, Stack<char>> BuildSupplyStacks(List<string> stackStrings)
    {
        var stacks = new Dictionary<int, Stack<char>>();
        
        var stackCount = (stackStrings.First().Length + 1) / 4;
        stackStrings.Reverse();
        foreach (var stackString in stackStrings)
        {
            for (var i = 1; i <= stackCount; i++)
            {
                if(!stacks.ContainsKey(i))
                    stacks.Add(i, new Stack<char>());

                var value = stackString[(i - 1) * 4 + 1];
                if(value != ' ')
                    stacks[i].Push(stackString[(i-1) * 4 + 1]);
            }
        }

        return stacks;
    }

    public static CraneModel BuildCrane(List<string> instructionStrings)
    {
        return new CraneModel(instructionStrings);
    }

    public static string ExecuteInstructions(Dictionary<int, Stack<char>> stacks, CraneModel crane)
    {
        crane.ExecuteCrateMover9000(stacks);
        return GetTopItemsFromStacks(stacks);
    }

    public static string ExecuteMultiMoveInstructions(Dictionary<int, Stack<char>> stacks, CraneModel crane)
    {
        crane.ExecuteCrateMover9001(stacks);
        return GetTopItemsFromStacks(stacks);
    }
    
    private static string GetTopItemsFromStacks(Dictionary<int, Stack<char>> stacks)
    {
        return string.Join("", stacks.Select(x => x.Value.First()));
    }
}