using System;
using System.Collections.Generic;

namespace Advent2021.Models
{
    public class DiracPlayerModel
    {
        public int Score { get; set; }
        public int CurrentLocation { get; set; }
        public long Wins { get; set; }

        public DiracPlayerModel() { }
        
        public DiracPlayerModel(int startingLocation)
        {
            CurrentLocation = startingLocation;
            Score = 0;
        }

        public DiracPlayerModel CopyPlayer(int dieRoll)
        {
            var landingLocation = GetLandingLocation(CurrentLocation, dieRoll, 10);
            var result = new DiracPlayerModel
            {
                Score = Score + landingLocation,
                CurrentLocation = landingLocation,
                Wins = Wins
            };
            return result;
        }

        public DiracPlayerModel CopyPlayer()
        {
            var result = new DiracPlayerModel
            {
                Score = Score,
                CurrentLocation = CurrentLocation,
                Wins = Wins
            };
            return result;
        }
        
        private int GetLandingLocation(int currentLocation, int dieRoll, int boardSpaces)
        {
            var landingLocation = (currentLocation + dieRoll) % boardSpaces;
            landingLocation = landingLocation == 0 ? boardSpaces : landingLocation;
            return landingLocation;
        }
    }

    public static class UniversalHelper
    {
        public static Dictionary<int, int> copyBell { get; set; } =
            new Dictionary<int, int>
            {
                {3, 1},
                {4, 3},
                {5, 6},
                {6, 7},
                {7, 6},
                {8, 3},
                {9, 1},
            };

    }

    public class DiracGameModel
    {
        public int MaxDieRoll { get; set; }
        public int DieRolledCount { get; set; }
        
        public DiracPlayerModel Player1 { get; set; }
        public DiracPlayerModel Player2 { get; set; }
        
        public int WinningScore { get; set; }
        public int DieIndex { get; set; }
        public long Copies { get; set; }

        public DiracGameModel()
        {
            DieRolledCount = 0;
            DieIndex = 1;
            Copies = 1;
        }
        
        public DiracGameModel(int maxDieRoll, int player1StartingLocation, int player2StartingLocation, int winningScore)
        {
            MaxDieRoll = maxDieRoll;
            DieRolledCount = 0;
            DieIndex = 1;
            WinningScore = winningScore;
            Player1 = new DiracPlayerModel(player1StartingLocation);
            Player2 = new DiracPlayerModel(player2StartingLocation);
            Copies = 1;
        }


        public List<DiracGameModel> RollUniversalDie(int player)
        {
            var result = new List<DiracGameModel>();

            for (var i = 3; i <= 9; i++)
            {
                result.Add(CopyGame(player, i, UniversalHelper.copyBell[i]));
            }
            
            return result;
        }

        private DiracGameModel CopyGame(int player, int dieResult, int copies)
        {
            var result = new DiracGameModel
            {
                MaxDieRoll = MaxDieRoll,
                Player1 = player == 1 ? Player1.CopyPlayer(dieResult) : Player1.CopyPlayer(),
                Player2 = player == 2 ? Player2.CopyPlayer(dieResult) : Player2.CopyPlayer(),
                WinningScore = WinningScore,
                Copies = Copies * copies
            };

            return result;
        }

        public bool HasWinner()
        {
            return Player1.Score >= WinningScore || Player2.Score >= WinningScore;
        }
        
        public long Player1Wins()
        {
            return Player1.Score >= WinningScore ? Copies : 0;
        }
        
        public long Player2Wins()
        {
            return Player2.Score >= WinningScore ? Copies : 0;
        }

        public void GetWinningPlayer(ref (long, long) playerWins)
        {
            if (Player1.Score >= WinningScore)
                playerWins.Item1 += Copies;
            
            if (Player2.Score >= WinningScore)
                playerWins.Item2 += Copies;
        }
        
        public void PlayGame()
        {
            do
            {
                RollDie(Player1);
                if (Player1.Score >= 1000) break;
                RollDie(Player2);
            } while (Player2.Score < 1000);
        }

        private void RollDie(DiracPlayerModel player)
        {
            var dieRoll = GetDeterministicDieRolls();
            DieRolledCount += 3;
            var landingLocation = GetLandingLocation(player.CurrentLocation, dieRoll, 10);

            player.Score += landingLocation;
            player.CurrentLocation = landingLocation;
        }
        
        private int GetDeterministicDieRolls()
        {
            return (DieIndex++ % MaxDieRoll) + (DieIndex++ % MaxDieRoll) + (DieIndex++ % MaxDieRoll);
        }
        
        private int GetLandingLocation(int currentLocation, int dieRoll, int boardSpaces)
        {
            var landingLocation = (currentLocation + dieRoll) % boardSpaces;
            landingLocation = landingLocation == 0 ? boardSpaces : landingLocation;
            return landingLocation;
        }

        public int GetLosingScore()
        {
            return Player1.Score < Player2.Score ? Player1.Score : Player2.Score;
        }
    }
}