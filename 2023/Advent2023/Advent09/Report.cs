using AdventShared;

namespace Advent2023.Advent09;

public class Report
{
    private List<List<int>> ValueHistorySequences { get; set; } = new();

    public Report(string input)
    {
        ValueHistorySequences.Add(input.Split(" ").Select(int.Parse).ToList());
    }

    public void BuildChildSequence()
    {
        while (true)
        {
            var previousSequence = ValueHistorySequences.Last();
            if (previousSequence.All(x => x == 0)) return;

            var newSequence = new List<int>();
            for (var i = 0; i < previousSequence.Count - 1; i++)
            {
                newSequence.Add(previousSequence[i + 1] - previousSequence[i]);
            }

            ValueHistorySequences.Add(newSequence);
        }
    }

    public int ExtrapolateFutureValue()
    {
        for (int i = ValueHistorySequences.Count - 1; i >= 0; i--)
        {
            if(ValueHistorySequences[i].All(x => x == 0))
                ValueHistorySequences[i].Add(0);
            else
                ValueHistorySequences[i].Add(ValueHistorySequences[i].Last() + ValueHistorySequences[i + 1].Last());
        }

        return ValueHistorySequences[0].Last();
    }

    public int ExtrapolatePastValue()
    {
        for (int i = ValueHistorySequences.Count - 1; i >= 0; i--)
        {
            if(ValueHistorySequences[i].All(x => x == 0))
                ValueHistorySequences[i] = ValueHistorySequences[i].Prepend(0).ToList();
            else
                ValueHistorySequences[i] = ValueHistorySequences[i].Prepend(ValueHistorySequences[i].First() - ValueHistorySequences[i + 1].First()).ToList();
        }

        return ValueHistorySequences[0].First();
    }

}
