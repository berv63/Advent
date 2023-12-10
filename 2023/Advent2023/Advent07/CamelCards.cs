using AdventShared;

namespace Advent2023.Advent07;

public class CamelCards
{
    private HandGrouping Hands { get; set; }

    public CamelCards(List<string> input, bool hasJokers = false)
    {
        Hands = new HandGrouping(input, hasJokers);
        Hands.BreakDownGroupings(-1, hasJokers);
    }

    public int CalculateWinnings()
    {
        var handsSorted = Hands.GetHandsSorted();
        var rank = 1;
        return handsSorted.Sum(hand => hand.GetPayout(rank++));
    }

    public void PrintSortedHands()
    {
        var handsSorted = Hands.GetHandsSorted();
        var rank = 1;
        foreach (var hand in handsSorted)
        {
            hand.GetPayout(rank++);
        }
        FileExtensions.WriteFile($@"..\..\..\..\{FileExtensions.GetFileOutputLocation("Advent07", $"HandOutput")}", handsSorted.Select(x => x.HandOutput));
    }
}
