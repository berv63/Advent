using System.Linq;
using AdventShared;
using NUnit.Framework;

namespace Advent2022.Tests
{
    [TestFixture]
    public class Advent03_RucksackReorgTests
    {
        [Test]
        public void RucksackReorg_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var rucksacks = Advent2022.RucksackReorg.BuildRucksacks(fileData); 
            var result = Advent2022.RucksackReorg.PriorityTotal(rucksacks);
            Assert.AreEqual(157, result);
        }
        
        [Test]
        public void RucksackReorg_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var rucksacks = Advent2022.RucksackReorg.BuildRucksacks(fileData); 
            var result = Advent2022.RucksackReorg.PriorityTotal(rucksacks);
            Assert.AreEqual(7746, result);
        }
        
        [Test]
        public void RucksackReorgGroups_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

            var rucksacks = Advent2022.RucksackReorg.BuildRucksacks(fileData); 
            var rucksackGroups = Advent2022.RucksackReorg.GroupRucksacks(rucksacks.ToList()); 
            var result = Advent2022.RucksackReorg.GetGroupBadgePriorityTotal(rucksackGroups);
            Assert.AreEqual(70, result);
        }
        
        [Test]
        public void RucksackReorgGroups_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

            var rucksacks = Advent2022.RucksackReorg.BuildRucksacks(fileData); 
            var rucksackGroups = Advent2022.RucksackReorg.GroupRucksacks(rucksacks.ToList()); 
            var result = Advent2022.RucksackReorg.GetGroupBadgePriorityTotal(rucksackGroups);
            Assert.AreEqual(2604, result);
        }
    }
}