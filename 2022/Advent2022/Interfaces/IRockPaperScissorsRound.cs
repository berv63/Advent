using Advent2022.Enums;

namespace Advent2022.Interfaces;

public interface IRockPaperScissorsRound
{
    public int TheirThrow { get; }
    public int MyThrow { get;  }
    public RockPaperScissorsOutcomeEnum Outcome { get; }
}