using System.Collections.Generic;
using Advent2021.Models;

namespace Advent2021
{
    public static class GiantSquid
    {
        public static int GetLoserBoard(List<int> numbersCalled, List<BingoBoardModels> bingoBoards)
        {
            var score = 0;
            
            foreach (var number in numbersCalled)
            {
                for (int i = 0; i < bingoBoards.Count; i++)
                {
                    bingoBoards[i].MarkItem(number);
                    if (bingoBoards[i].CheckBingo() && bingoBoards.Count > 1)
                    {
                        bingoBoards.Remove(bingoBoards[i]);
                        i--;
                    }
                    else if(bingoBoards[i].CheckBingo() && bingoBoards.Count == 1)
                    {
                        score = bingoBoards[i].ScoreBoard(number);
                        break;
                    }
                }

                if (score != 0)
                    break;
            }

            return score;
        }
        
        public static int GetFinalBoard(List<int> numbersCalled, List<BingoBoardModels> bingoBoards)
        {
            var score = 0;
            
            foreach (var number in numbersCalled)
            {
                foreach (var board in bingoBoards)
                {
                    board.MarkItem(number);
                    if (board.CheckBingo())
                    {
                        score = board.ScoreBoard(number);
                        break;
                    }
                }

                if (score != 0)
                    break;
            }

            return score;
        }
    }
}