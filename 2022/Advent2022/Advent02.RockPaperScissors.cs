using Advent2022.Interfaces;
using Advent2022.Models;

namespace Advent2022;

public static class RockPaperScissors
{
    public static IEnumerable<RockPaperScissorsRound> BuildRounds(List<string> gameRounds)
    {
        return gameRounds.Select(x => new RockPaperScissorsRound(x[0], x[2]));
    }
    
    public static IEnumerable<RockPaperScissorsOutcomeRound> BuildOutcomeRounds(List<string> gameRounds)
    {
        return gameRounds.Select(x => new RockPaperScissorsOutcomeRound(x[0], x[2]));
    }

    public static int GameResults(IEnumerable<IRockPaperScissorsRound> gameRounds)
    {
        return SumOfMyOutcomes(gameRounds) + SumOfMyThrows(gameRounds);
    }

    private static int SumOfMyOutcomes(IEnumerable<IRockPaperScissorsRound> rounds)
    {
        return rounds.Sum(x => (int) x.Outcome);
    }

    private static int SumOfMyThrows(IEnumerable<IRockPaperScissorsRound> rounds)
    {
        return rounds.Sum(x => (int) x.MyThrow + 1);
    }
}