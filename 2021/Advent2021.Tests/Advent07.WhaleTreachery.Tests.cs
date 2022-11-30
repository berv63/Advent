using System.Linq;
using Advent2021.Models;
using AdventShared;
using NUnit.Framework;

namespace Advent2021.Tests
{
    [TestFixture]
    public class Advent7WhaleTreacheryTests
    {
        [Test]
        public void SubFuelPractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent7\Practice.txt");
            var crabSubmarines = rows[0].Split(',').Select(x => new CrabSubmarineModel(int.Parse(x), 1)).ToList();
            var mergedCrabSubmarines = WhaleTreachery.MergeCrabSubmarines(crabSubmarines); 
            
            var endCount = WhaleTreachery.GetFuelCount(mergedCrabSubmarines);
            Assert.AreEqual(37, endCount);
        }
        
        [Test]
        public void SubFuel()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent7\Actual.txt");
            var crabSubmarines = rows[0].Split(',').Select(x => new CrabSubmarineModel(int.Parse(x), 1)).ToList();
            var mergedCrabSubmarines = WhaleTreachery.MergeCrabSubmarines(crabSubmarines); 
            
            var endCount = WhaleTreachery.GetFuelCount(mergedCrabSubmarines);
            Assert.AreEqual(364898, endCount);
        }
        
        [Test]
        public void SubFuelIncreasePractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent7\Practice.txt");
            var crabSubmarines = rows[0].Split(',').Select(x => new CrabSubmarineModel(int.Parse(x), 1)).ToList();
            var mergedCrabSubmarines = WhaleTreachery.MergeCrabSubmarines(crabSubmarines); 
            
            var endCount = WhaleTreachery.GetIncreasingFuelCount(mergedCrabSubmarines);
            Assert.AreEqual(168, endCount);
        }
        
        [Test]
        public void SubFuelIncrease()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent7\Actual.txt");
            var crabSubmarines = rows[0].Split(',').Select(x => new CrabSubmarineModel(int.Parse(x), 1)).ToList();
            var mergedCrabSubmarines = WhaleTreachery.MergeCrabSubmarines(crabSubmarines); 
            
            var endCount = WhaleTreachery.GetIncreasingFuelCount(mergedCrabSubmarines);
            Assert.AreEqual(104149091, endCount);
        }
    }
}