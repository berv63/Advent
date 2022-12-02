using Advent2022.Enums;

namespace Advent2022.Interfaces;

public interface IRockPaperScissorsRound
{
    public RockPaperScissorsThrowEnum TheirThrow { get; }
    public RockPaperScissorsThrowEnum MyThrow { get;  }
    public RockPaperScissorsOutcomeEnum Outcome { get; }
}