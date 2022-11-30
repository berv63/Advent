using System.Linq;
using Advent2021.Models;
using AdventShared;
using NUnit.Framework;

namespace Advent2021.Tests
{
    [TestFixture]
    public class Advent8SevenSegmentSearchTests
    {
        [Test]
        public void SegmentSearchPractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent8\Practice.txt");
            var displays = rows.Select(x => new NumericDisplayModel(x.Split('|')[0].Split(' ').ToList(), x.Split('|')[1].Split(' ').ToList())).ToList();
            
            var endCount = SevenSegmentSearch.GetUniqueCount(displays);
            Assert.AreEqual(26, endCount);
        }
        
        [Test]
        public void SegmentSearch()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent8\Actual.txt");
            var displays = rows.Select(x => new NumericDisplayModel(x.Split('|')[0].Split(' ').ToList(), x.Split('|')[1].Split(' ').ToList())).ToList();
            
            var endCount = SevenSegmentSearch.GetUniqueCount(displays);
            Assert.AreEqual(318, endCount);
        }
        
        [Test]
        public void SegmentSearchSummationPractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent8\Practice.txt");
            var displays = rows.Select(x => new NumericDisplayModel(x.Split('|')[0].Split(' ').ToList(), x.Split('|')[1].Split(' ').ToList())).ToList();
            
            var endCount = SevenSegmentSearch.GetResultSummation(displays);
            Assert.AreEqual(61229, endCount);
        }
        
        [Test]
        public void SegmentSearchSummation()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent8\Actual.txt");
            var displays = rows.Select(x => new NumericDisplayModel(x.Split('|')[0].Split(' ').ToList(), x.Split('|')[1].Split(' ').ToList())).ToList();
            
            var endCount = SevenSegmentSearch.GetResultSummation(displays);
            Assert.AreEqual(996280, endCount);
        }
    }
}