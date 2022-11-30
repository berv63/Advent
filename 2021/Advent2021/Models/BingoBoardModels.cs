using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2021.Models
{
    public class BingoBoardModels
    {
        public List<List<int>> Board { get; set; }
        public List<List<int>> Markings { get; set; }
        public bool HasBingo { get; set; }
        public int Score { get; set; }

        public BingoBoardModels(List<List<string>> rows)
        {
            Board = new List<List<int>>();
            foreach (var row in rows)
            {
                Board.Add(row.Select(x => int.Parse(x.ToString())).ToList());
            }
            
            Markings = new List<List<int>>
            {
                new List<int> {0, 0, 0, 0, 0},
                new List<int> {0, 0, 0, 0, 0},
                new List<int> {0, 0, 0, 0, 0},
                new List<int> {0, 0, 0, 0, 0},
                new List<int> {0, 0, 0, 0, 0}
            };
        }

        public void MarkItem(int number)
        {
            for (var i=0; i < Board.Count; i++)
            {
                for (var j=0; j < Board[i].Count; j++)
                {
                    if (Board[i][j] == number)
                    {
                        Markings[i][j] = 1;
                    }
                }
            }
        }

        public bool CheckBingo()
        {
            return CheckRows() || CheckColumns();
        }

        private bool CheckRows()
        {
            foreach (var row in Markings.Where(row => row.Sum() == 5))
            {
                HasBingo = true;
                break;
            }

            return HasBingo;
        }

        private bool CheckColumns()
        {
            for (var i = 0; i < Board[0].Count; i++)
            {
                var columnSum = Markings.Count(x => x[i] == 1);
                if (columnSum == 5)
                {
                    HasBingo = true;
                    break;
                }
            }

            return HasBingo;
        }

        public int ScoreBoard(int number)
        {
            for (var i=0; i < Board.Count; i++)
            {
                for (var j=0; j < Board[i].Count; j++)
                {
                    if (Markings[i][j] == 0)
                    {
                        Score += Board[i][j];
                    }
                }
            }

            Score *= number;
            return Score;
        }
    }
}