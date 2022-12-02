using Advent2022.Enums;
using Advent2022.Interfaces;

namespace Advent2022.Models
{
    public class RockPaperScissorsOutcomeRound : IRockPaperScissorsRound
    {
        private int CharIntOffset = 65;
        
        public RockPaperScissorsThrowEnum TheirThrow { get; set; }
        public RockPaperScissorsOutcomeEnum Outcome { get; set; }
        
        public RockPaperScissorsThrowEnum MyThrow => CalculateThrow();

        public RockPaperScissorsOutcomeRound(char theirThrowChar, char outcome)
        {
            TheirThrow = (RockPaperScissorsThrowEnum)(theirThrowChar - CharIntOffset);
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
        
        private RockPaperScissorsThrowEnum CalculateThrow()
        {
            return Outcome switch
            {
                RockPaperScissorsOutcomeEnum.Draw => TheirThrow,
                RockPaperScissorsOutcomeEnum.Loss => GetLoserToTheirThrow(),
                RockPaperScissorsOutcomeEnum.Win => GetWinnerToTheirThrow(),
                _ => throw new InvalidOperationException("no winner?!")
            };
        }

        private RockPaperScissorsThrowEnum GetLoserToTheirThrow()
        {
            var loserInt = ((int)TheirThrow + 2) % 3;
            return (RockPaperScissorsThrowEnum)loserInt;
        }

        private RockPaperScissorsThrowEnum GetWinnerToTheirThrow()
        {
            var winnerInt = ((int)TheirThrow + 1) % 3;
            return (RockPaperScissorsThrowEnum)winnerInt;
        }
    }
}