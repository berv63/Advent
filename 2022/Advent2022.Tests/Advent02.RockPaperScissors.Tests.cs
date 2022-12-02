using System;
using System.Collections.Generic;
using System.Linq;
using Advent2022.Models;
using AdventShared;
using NUnit.Framework;

namespace Advent2022.Tests
{
    [TestFixture]
    public class Advent2RockPaperScissorsTests
    {
        [Test]
        public void RockPaperScissorsPractice()
        {
            var gameRounds = FileExtensions.ReadFile(@"..\..\..\..\Files\Advent2\Practice.txt");
            
            var gameRoundsSplit = Advent2022.RockPaperScissors.BuildRounds(gameRounds); 
            var result = Advent2022.RockPaperScissors.GameResults(gameRoundsSplit);
            Assert.AreEqual(15, result);
        }
        
        [Test]
        public void RockPaperScissors()
        {
            var gameRounds = FileExtensions.ReadFile(@"..\..\..\..\Files\Advent2\Actual.txt");
            
            var gameRoundsSplit = Advent2022.RockPaperScissors.BuildRounds(gameRounds); 
            var result = Advent2022.RockPaperScissors.GameResults(gameRoundsSplit);
            Assert.AreEqual(12156, result);
        }
        
        [Test]
        public void RockPaperScissorsOutcomePractice()
        {
            var gameRounds = FileExtensions.ReadFile(@"..\..\..\..\Files\Advent2\Practice.txt");

            var gameRoundsSplit = Advent2022.RockPaperScissors.BuildOutcomeRounds(gameRounds); 
            var result = Advent2022.RockPaperScissors.GameResults(gameRoundsSplit);
            Assert.AreEqual(12, result);
        }
        
        [Test]
        public void RockPaperScissorsOutcome()
        {
            var gameRounds = FileExtensions.ReadFile(@"..\..\..\..\Files\Advent2\Actual.txt");

            var gameRoundsSplit = Advent2022.RockPaperScissors.BuildOutcomeRounds(gameRounds); 
            var result = Advent2022.RockPaperScissors.GameResults(gameRoundsSplit);
            Assert.AreEqual(10835, result);
        }
    }
}