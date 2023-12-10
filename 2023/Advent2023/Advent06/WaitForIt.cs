using Advent2023.Advent05;

namespace Advent2023.Advent06;

public class WaitForIt
{
    private List<Race> ShortRaces { get; set; } = new();
    private Race LongRace { get; set; }

    public WaitForIt(List<string> input, bool isLonger = false)
    {
        if (isLonger)
        {
            BuildLongerRace(input);
        }
        else
        {
            BuildShorterRaces(input);
        }
    }

    private void BuildLongerRace(List<string> input)
    {
        var time = long.Parse(input[0].Split(":").Last().Replace(" ", string.Empty));
        var distance = long.Parse(input[1].Split(":").Last().Replace(" ", string.Empty));

        LongRace = new Race(time, distance);
    }

    private void BuildShorterRaces(List<string> input)
    {
        var times = input[0].Split(":").Last().Split(" ").Where(x => !string.IsNullOrEmpty(x)).Select(int.Parse).ToList();
        var distances = input[1].Split(":").Last().Split(" ").Where(x => !string.IsNullOrEmpty(x)).Select(int.Parse).ToList();

        for (int i = 0; i < times.Count(); i++)
        {
            ShortRaces.Add(new Race(times[i], distances[i]));
        }
    }

    public int Do()
    {
        var result = 1;
        foreach (var race in ShortRaces)
        {
            race.CalculateWinningButtonHoldLengths();
            result *= race.WinningButtonHoldLengths.Count;
        }

        return result;
    }

    public int DoLonger()
    {
        LongRace.CalculateWinningButtonHoldLengths();
        return LongRace.WinningButtonHoldLengths.Count;
    }
}
