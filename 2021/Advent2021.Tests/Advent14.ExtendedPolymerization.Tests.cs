using System.Linq;
using Advent2021.Models;
using AdventShared;
using NUnit.Framework;

namespace Advent2021.Tests
{
    [TestFixture]
    public class Advent14ExtendedPolymerizationTests
    {
        [Test]
        public void PolymerizePractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent14\Practice.txt");
            var initialString = rows[0];

            var second = rows.Where(x => x.Contains("->")).ToList();
            var rules = second.ToDictionary(x => x.Split(' ')[0], x => x.Split(' ')[2]);
            
            var difference = ExtendedPolymerization.GetFinalString(initialString, rules, 10);
            Assert.AreEqual(1588, difference);
        }
        
        [Test]
        public void Polymerize()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent14\Actual.txt");
            var initialString = rows[0];

            var second = rows.Where(x => x.Contains("->")).ToList();
            var rules = second.ToDictionary(x => x.Split(' ')[0], x => x.Split(' ')[2]);
            
            var difference = ExtendedPolymerization.GetFinalString(initialString, rules, 10);
            Assert.AreEqual(2947, difference);
        }
        
        [Test]
        public void PolymerizePractice2()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent14\Practice.txt");
            var initialString = rows[0];

            var second = rows.Where(x => x.Contains("->")).ToList();
            var rules = second.Select(x => new PolymerizationTreeModel(x)).ToList();
            ExtendedPolymerization.BuildPolymerizationTrees(rules);
            
            var difference = ExtendedPolymerization.GetMostLestCommonDifference(initialString, rules, 10);
            Assert.AreEqual(1588, difference);
        }
        
        [Test]
        public void Polymerize2()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent14\Actual.txt");
            var initialString = rows[0];

            var second = rows.Where(x => x.Contains("->")).ToList();
            var rules = second.Select(x => new PolymerizationTreeModel(x)).ToList();
            ExtendedPolymerization.BuildPolymerizationTrees(rules);
            
            var difference = ExtendedPolymerization.GetMostLestCommonDifference(initialString, rules, 10);
            Assert.AreEqual(2947, difference);
        }
        
        
        [Test]
        public void PolymerizeMorePractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent14\Practice.txt");
            var initialString = rows[0];

            var second = rows.Where(x => x.Contains("->")).ToList();
            var rules = second.Select(x => new PolymerizationTreeModel(x)).ToList();
            ExtendedPolymerization.BuildPolymerizationTrees(rules);
            
            var difference = ExtendedPolymerization.GetMostLestCommonDifference(initialString, rules, 40);
            Assert.AreEqual(2188189693529, difference);
        }
        
        [Test]
        public void PolymerizeMore()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent14\Actual.txt");
            var initialString = rows[0];

            var second = rows.Where(x => x.Contains("->")).ToList();
            var rules = second.Select(x => new PolymerizationTreeModel(x)).ToList();
            ExtendedPolymerization.BuildPolymerizationTrees(rules);
            
            var difference = ExtendedPolymerization.GetMostLestCommonDifference(initialString, rules, 40);
            Assert.AreEqual(3232426226464, difference);
        }
    }
}