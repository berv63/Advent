using AdventShared;

namespace Advent2023.Advent09;

public class MirageMaintenance
{
    private List<Report> Reports = new();
    public MirageMaintenance(List<string> input)
    {
        Reports = input.Select(x => new Report(x)).ToList();
        foreach (var report in Reports)
        {
            report.BuildChildSequence();
        }
    }

    public int ExtrapolateFutureValue()
    {
        var resultValues = new List<int>();
        foreach (var report in Reports)
        {
            var reportResult = report.ExtrapolateFutureValue();
            resultValues.Add(reportResult);
        }

        return resultValues.Sum();
    }

    public int ExtrapolatePastValue()
    {
        var resultValues = new List<int>();
        foreach (var report in Reports)
        {
            var reportResult = report.ExtrapolatePastValue();
            resultValues.Add(reportResult);
        }

        return resultValues.Sum();
    }

}
