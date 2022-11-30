using AdventShared;
using NUnit.Framework;

namespace Advent2021.Tests
{
    [TestFixture]
    public class Advent10SyntaxScoringTests
    {
        [Test]
        public void SyntaxScorePractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent10\Practice.txt");
            
            var endCount = SyntaxScoring.GetSyntaxScore(rows);
            Assert.AreEqual(26397, endCount);
        }
        
        [Test]
        public void SyntaxScore()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent10\Actual.txt");
            
            var endCount = SyntaxScoring.GetSyntaxScore(rows);
            Assert.AreEqual(344193, endCount);
        }
        
        [Test]
        public void AutoCompleteScorePractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent10\Practice.txt");
            
            var endCount = SyntaxScoring.GetAutoCompleteScore(rows);
            Assert.AreEqual(288957, endCount);
        }
        
        [Test]
        public void AutoCompleteScore()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent10\Actual.txt");
            
            var endCount = SyntaxScoring.GetAutoCompleteScore(rows);
            Assert.AreNotEqual(63614124, endCount); //values were larger than bigint. needed to use Long
            Assert.AreEqual(3241238967, endCount);
        }
    }
}