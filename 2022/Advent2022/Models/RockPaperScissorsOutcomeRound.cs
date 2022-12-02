using Advent2022.Enums;
using Advent2022.Interfaces;

namespace Advent2022.Models
{
    public class RockPaperScissorsOutcomeRound : IRockPaperScissorsRound
    {
        private int CharIntOffset = 65;
        
        public int TheirThrow { get; set; }
        public RockPaperScissorsOutcomeEnum Outcome { get; set; }
        
        public int MyThrow => CalculateThrow();

        public RockPaperScissorsOutcomeRound(char theirThrowChar, char outcome)
        {
            TheirThrow = theirThrowChar - CharIntOffset;
            Outcome = GetOutcome(outcome);
        }

        private RockPaperScissorsOutcomeEnum GetOutcome(char outcome)
        {
            return outcome switch
            {
                'X' => RockPaperScissorsOutcomeEnum.Loss,
                'Y' => RockPaperScissorsOutcomeEnum.Draw,
                'Z' => RockPaperScissorsOutcomeEnum.Win,
                _ => throw new InvalidOperationException("no winner?!")
            };
        }
        
        private int CalculateThrow()
        {
            return Outcome switch
            {
                RockPaperScissorsOutcomeEnum.Draw => TheirThrow,
                RockPaperScissorsOutcomeEnum.Loss => GetLoserToTheirThrow(),
                RockPaperScissorsOutcomeEnum.Win => GetWinnerToTheirThrow(),
                _ => throw new InvalidOperationException("no winner?!")
            };
        }

        private int GetLoserToTheirThrow()
        {
            return (TheirThrow + 2) % 3;
        }

        private int GetWinnerToTheirThrow()
        {
            return (TheirThrow + 1) % 3;
        }
    }
}