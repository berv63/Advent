using System.Linq;
using AdventShared;
using NUnit.Framework;

namespace Advent2022.Tests
{
    [TestFixture]
    public class Advent05_SupplyStacksTests
    {
        [Test]
        public void SupplyStacks_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var supplyStacks = Advent2022.SupplyStacks.BuildSupplyStacks(fileData.Where(x => x.Contains('[')).ToList()); 
            var crane = Advent2022.SupplyStacks.BuildCrane(fileData.Where(x => x.Contains("move")).ToList()); 
            var result = Advent2022.SupplyStacks.ExecuteInstructions(supplyStacks, crane);
            Assert.AreEqual("CMZ", result);
        }
        
        [Test]
        public void SupplyStacks_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var supplyStacks = Advent2022.SupplyStacks.BuildSupplyStacks(fileData.Where(x => x.Contains('[')).ToList()); 
            var crane = Advent2022.SupplyStacks.BuildCrane(fileData.Where(x => x.Contains("move")).ToList()); 
            var result = Advent2022.SupplyStacks.ExecuteInstructions(supplyStacks, crane);
            Assert.AreNotEqual("DNDTDGMTV", result);
            Assert.AreEqual("MQTPGLLDN", result);
        }
        
        [Test]
        public void SupplyStacksMultiMove_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

            var supplyStacks = Advent2022.SupplyStacks.BuildSupplyStacks(fileData.Where(x => x.Contains('[')).ToList()); 
            var crane = Advent2022.SupplyStacks.BuildCrane(fileData.Where(x => x.Contains("move")).ToList()); 
            var result = Advent2022.SupplyStacks.ExecuteMultiMoveInstructions(supplyStacks, crane);
            Assert.AreEqual("MCD", result);
        }
        
        [Test]
        public void SupplyStacksMultiMove_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

            var supplyStacks = Advent2022.SupplyStacks.BuildSupplyStacks(fileData.Where(x => x.Contains('[')).ToList()); 
            var crane = Advent2022.SupplyStacks.BuildCrane(fileData.Where(x => x.Contains("move")).ToList()); 
            var result = Advent2022.SupplyStacks.ExecuteMultiMoveInstructions(supplyStacks, crane);
            Assert.AreEqual("LVZPSTTCZ", result);
        }
    }
}