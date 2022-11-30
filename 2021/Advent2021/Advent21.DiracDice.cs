using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using Advent2021.Models;

namespace Advent2021
{
    public static class DiracDice
    {
        public static (long, long) PlayUniversalGame(List<DiracGameModel> currentGames)
        {
            (long, long) playerWins = (0, 0);
            
            do
            {
                currentGames = RollPlayer(currentGames, ref playerWins, 1);
                if (!currentGames.Any()) break;
                currentGames = RollPlayer(currentGames, ref playerWins, 2);
            } while (currentGames.Any());
            return playerWins;
        }

        private static List<DiracGameModel> RollPlayer(List<DiracGameModel> currentGames, ref (long, long) playerWins, int playerNumber)
        {
            var newGames = new List<DiracGameModel>();
            foreach (var game in currentGames)
            {
                newGames.AddRange(game.RollUniversalDie(playerNumber));
            }
            
            var finishedGames = newGames.Where(x => x.HasWinner()).ToList();
            playerWins.Item1 += finishedGames.Sum(x => x.Player1Wins());
            playerWins.Item2 += finishedGames.Sum(x => x.Player2Wins());
            
            currentGames = newGames.Where(x => !x.HasWinner()).ToList();

            return currentGames;
        }
    }
}