using AdventShared;
using NUnit.Framework;

namespace Advent2022.Tests
{
    [TestFixture]
    public class Advent02_RockPaperScissorsTests
    {
        [Test]
        public void RockPaperScissors_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var gameRoundsSplit = Advent2022.RockPaperScissors.BuildRounds(fileData); 
            var result = Advent2022.RockPaperScissors.GameResults(gameRoundsSplit);
            Assert.AreEqual(15, result);
        }
        
        [Test]
        public void RockPaperScissors_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var gameRoundsSplit = Advent2022.RockPaperScissors.BuildRounds(fileData); 
            var result = Advent2022.RockPaperScissors.GameResults(gameRoundsSplit);
            Assert.AreEqual(12156, result);
        }
        
        [Test]
        public void RockPaperScissorsOutcome_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

            var gameRoundsSplit = Advent2022.RockPaperScissors.BuildOutcomeRounds(fileData); 
            var result = Advent2022.RockPaperScissors.GameResults(gameRoundsSplit);
            Assert.AreEqual(12, result);
        }
        
        [Test]
        public void RockPaperScissorsOutcome_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

            var gameRoundsSplit = Advent2022.RockPaperScissors.BuildOutcomeRounds(fileData); 
            var result = Advent2022.RockPaperScissors.GameResults(gameRoundsSplit);
            Assert.AreEqual(10835, result);
        }
    }
}