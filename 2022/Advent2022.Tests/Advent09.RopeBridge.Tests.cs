using System.Linq;
using AdventShared;
using NUnit.Framework;

namespace Advent2022.Tests
{
    [TestFixture]
    public class Advent09_RopeBridgeTests
    {
        [Test]
        public void RopeBridge_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var commands = Advent2022.RopeBridge.BuildCommands(fileData);
            var grid = Advent2022.RopeBridge.GetGrid(commands, 1);
            var visitedCount = Advent2022.RopeBridge.RunCommands(commands, grid, 1);
            Assert.AreEqual(13, visitedCount);
        }
        
        [Test]
        public void RopeBridge_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var commands = Advent2022.RopeBridge.BuildCommands(fileData);
            var grid = Advent2022.RopeBridge.GetGrid(commands, 1);
            var visitedCount = Advent2022.RopeBridge.RunCommands(commands, grid, 1);
            Assert.AreEqual(6470, visitedCount);
        }
        
        /*
        [Test]
        public void ScenicScore_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var forrest = Advent2022.TreeTopTreeHouse.BuildForrest(fileData);
            var scenicScore = Advent2022.TreeTopTreeHouse.GetScenicScore(forrest);
            Assert.AreEqual(8, scenicScore);
        }
        
        [Test]
        public void ScenicScore_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var forrest = Advent2022.TreeTopTreeHouse.BuildForrest(fileData);
            var scenicScore = Advent2022.TreeTopTreeHouse.GetScenicScore(forrest);
            Assert.AreNotEqual(31248, scenicScore);
            Assert.AreEqual(313200, scenicScore);
        }*/
    }
}