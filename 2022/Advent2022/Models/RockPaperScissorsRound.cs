using Advent2022.Enums;
using Advent2022.Interfaces;

namespace Advent2022.Models
{
    public class RockPaperScissorsRound: IRockPaperScissorsRound
    {
        private int CharIntOffset = 65;
        
        public int TheirThrow { get; set; }
        public int MyThrow { get; set; }
        
        public RockPaperScissorsOutcomeEnum Outcome => CalculateResult();

        public RockPaperScissorsRound(char theirThrowChar, char myThrowChar)
        {
            TheirThrow = theirThrowChar - CharIntOffset;
            MyThrow = ReduceThrow(myThrowChar) - CharIntOffset;
        }
        
        private int ReduceThrow(char myThrow)
        {
            return myThrow - 23;
        }
        
        private RockPaperScissorsOutcomeEnum CalculateResult()
        {
            if (TheirThrow == MyThrow)
                return RockPaperScissorsOutcomeEnum.Draw;

            if (DidIWin())
                return RockPaperScissorsOutcomeEnum.Win;

            if (DidTheyWin())
                return RockPaperScissorsOutcomeEnum.Loss;

            throw new InvalidOperationException("no winner?!");
        }

        private bool DidTheyWin()
        {
            return (MyThrow + 1) % 3 == TheirThrow;
        }

        private bool DidIWin()
        {
            return (TheirThrow + 1) % 3 == MyThrow;
        }
    }
}