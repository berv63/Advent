using Advent2022.Enums;
using Advent2022.Interfaces;

namespace Advent2022.Models.Advent02
{
    public class RockPaperScissorsRound: IRockPaperScissorsRound
    {
        private int CharIntOffset = 65;
        
        public RockPaperScissorsThrowEnum TheirThrow { get; set; }
        public RockPaperScissorsThrowEnum MyThrow { get; set; }
        
        public RockPaperScissorsOutcomeEnum Outcome => CalculateResult();

        public RockPaperScissorsRound(char theirThrowChar, char myThrowChar)
        {
            TheirThrow = (RockPaperScissorsThrowEnum)(theirThrowChar - CharIntOffset);
            MyThrow = (RockPaperScissorsThrowEnum)(ReduceThrow(myThrowChar) - CharIntOffset);
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
            return ((int)MyThrow + 1) % 3 == (int)TheirThrow;
        }

        private bool DidIWin()
        {
            return ((int)TheirThrow + 1) % 3 == (int)MyThrow;
        }
    }
}