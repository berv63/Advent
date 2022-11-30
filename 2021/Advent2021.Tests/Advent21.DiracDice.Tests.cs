using System;
using System.Collections.Generic;
using System.Linq;
using Advent2021.Models;
using AdventShared;
using NUnit.Framework;

namespace Advent2021.Tests
{
    [TestFixture]
    public class Advent21DiracDiceTests
    {
        [Test]
        public void DeterministicPractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent21\Practice.txt");
            var player1Current = int.Parse(rows[0].Last().ToString());
            var player2Current = int.Parse(rows[1].Last().ToString());

            var game = new DiracGameModel(100, player1Current, player2Current, 1000);
            game.PlayGame();
            var result = game.GetLosingScore() * game.DieRolledCount;
            Assert.AreEqual(739785, result);
        }
        
        [Test]
        public void Deterministic()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent21\Actual.txt");
            var player1Current = int.Parse(rows[0].Last().ToString());
            var player2Current = int.Parse(rows[1].Last().ToString());

            var game = new DiracGameModel(100, player1Current, player2Current, 1000);
            game.PlayGame();
            var result = game.GetLosingScore() * game.DieRolledCount;
            Assert.AreEqual(675024, result);
        }
        
        [Test]
        public void UniversalPractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent21\Practice.txt");
            var player1Current = int.Parse(rows[0].Last().ToString());
            var player2Current = int.Parse(rows[1].Last().ToString());

            var game = new DiracGameModel(3, player1Current, player2Current, 21);
            var playerWins = DiracDice.PlayUniversalGame(game.IntoList());
            Assert.AreEqual(444356092776315 + 341960390180808, playerWins.Item1 + playerWins.Item2);
            Assert.AreEqual(444356092776315, playerWins.Item1);
            Assert.AreEqual(341960390180808, playerWins.Item2);
        }
        
        [Test]
        public void Universal()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent21\Actual.txt");
            var player1Current = int.Parse(rows[0].Last().ToString());
            var player2Current = int.Parse(rows[1].Last().ToString());

            var game = new DiracGameModel(3, player1Current, player2Current, 21);
            var playerWins = DiracDice.PlayUniversalGame(game.IntoList());
            var maxPlayerWins = playerWins.Item1 > playerWins.Item2 ? playerWins.Item1 : playerWins.Item2;
            Assert.AreEqual(570239341223618, maxPlayerWins);
        }
    }
}