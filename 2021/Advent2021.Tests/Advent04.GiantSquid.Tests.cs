using System.Collections.Generic;
using System.Linq;
using Advent2021.Models;
using AdventShared;
using NUnit.Framework;

namespace Advent2021.Tests
{
    [TestFixture]
    public class Advent4GiantSquidTests
    {
        private List<BingoBoardModels> BuildBingoBoards(IReadOnlyList<string> rows)
        {
            var bingoBoards = new List<BingoBoardModels>();
            for (var i = 2; i < rows.Count; i += 6)
            {
                var boardRows = new List<List<string>>();
                for (var j = 0; j < 5; j++)
                {
                    boardRows.Add(rows[i + j].Split(' ').Where(x => x != "").ToList());
                }
                bingoBoards.Add(new BingoBoardModels(boardRows));
            }

            return bingoBoards;
        }
        
        [Test]
        public void GiantSquidPractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent4\Practice.txt");
            var numbersCalled = rows[0].Split(',').Select(x => int.Parse(x.ToString())).ToList();
            var bingoBoards = BuildBingoBoards(rows);
            
            var bingoScore = GiantSquid.GetFinalBoard(numbersCalled, bingoBoards);
            Assert.AreEqual(4512, bingoScore);
        }
        
        [Test]
        public void Squid()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent4\Actual.txt");
            var numbersCalled = rows[0].Split(',').Select(x => int.Parse(x.ToString())).ToList();
            var bingoBoards = BuildBingoBoards(rows);
            
            var bingoScore = GiantSquid.GetFinalBoard(numbersCalled, bingoBoards);
            Assert.AreEqual(22680, bingoScore);
        }
        
        [Test]
        public void GiantSquidLoserPractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent4\Practice.txt");
            var numbersCalled = rows[0].Split(',').Select(x => int.Parse(x.ToString())).ToList();
            var bingoBoards = BuildBingoBoards(rows);
            
            var bingoScore = GiantSquid.GetLoserBoard(numbersCalled, bingoBoards);
            Assert.AreEqual(1924, bingoScore);
        }
        
        [Test]
        public void SquidLoser()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent4\Actual.txt");
            var numbersCalled = rows[0].Split(',').Select(x => int.Parse(x.ToString())).ToList();
            var bingoBoards = BuildBingoBoards(rows);
            
            var bingoScore = GiantSquid.GetLoserBoard(numbersCalled, bingoBoards);
            Assert.AreEqual(16168, bingoScore);
        }
    }
}