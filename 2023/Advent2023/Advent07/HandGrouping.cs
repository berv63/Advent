using AdventShared;

namespace Advent2023.Advent07;

public class HandGrouping
{
    private List<Hand> GroupedHands { get; set; } = new();
    private List<HandGrouping> ChildGroupings { get; set; } = new();

    private int Index { get; set; }//-1 means split by Hand Type, otherwise card index

    public HandGrouping(List<string> input, bool withJokers)
    {
        foreach (var row in input)
        {
            GroupedHands.Add(new Hand(row, withJokers));
        }
    }

    public HandGrouping(List<Hand> hands)
    {
        GroupedHands = hands;
    }

    public void BreakDownGroupings(int index, bool hasJokers)
    {
        var Index = index;
        if (GroupedHands.Count == 1)
        {
            return;
        }

        if (Index == -1)
        {
            var types = GroupedHands.Select(x => x.Type).Distinct().Order();
            if (types.Count() == 1)
            {
                BreakDownGroupings(Index + 1, hasJokers);
            }
            else
            {
                var levelRank = 1;
                foreach (var type in types)
                {
                    ChildGroupings.Add(new HandGrouping(GroupedHands.Where(x => x.Type == type).ToList()));
                }
            }
        }
        else
        {
            var cardStrengths = hasJokers ? PlayingCardStrengths.JokerCardStrengths : PlayingCardStrengths.CardStrengths;
            var values = GroupedHands.Select(x => x.HandValue[Index]).Distinct().OrderBy(x => cardStrengths.IndexOf(x));
            if (values.Count() == 1)
            {
                BreakDownGroupings(Index + 1, hasJokers);
            }
            else
            {
                var levelRank = 1;
                foreach (var value in values)
                {
                    ChildGroupings.Add(new HandGrouping(GroupedHands.Where(x => x.HandValue[Index] == value).ToList()));
                }
            }
        }

        foreach (var childGrouping in ChildGroupings)
        {
            childGrouping.BreakDownGroupings(Index + 1, hasJokers);
        }
    }

    public List<Hand> GetHandsSorted()
    {
        var result = new List<Hand>();
        if (GroupedHands.Count == 1)
            return GroupedHands;

        foreach (var childGrouping in ChildGroupings)
        {
            result.AddRange(childGrouping.GetHandsSorted());
        }

        return result;
    }
}
