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
            
            var indices = 1;
            var commands = Advent2022.RopeBridge.BuildCommands(fileData);
            var grid = Advent2022.RopeBridge.GetGrid(commands, indices);
            Advent2022.RopeBridge.RunCommands(commands, grid, indices);
            var visitedCount = Advent2022.RopeBridge.GetVisitCount(grid, indices);
            Assert.AreEqual(13, visitedCount);
        }
        
        [Test]
        public void RopeBridge_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var indices = 1;
            var commands = Advent2022.RopeBridge.BuildCommands(fileData);
            var grid = Advent2022.RopeBridge.GetGrid(commands, indices);
            Advent2022.RopeBridge.RunCommands(commands, grid, indices);
            var visitedCount = Advent2022.RopeBridge.GetVisitCount(grid, indices);
            Assert.AreEqual(6470, visitedCount);
        }
        
        [Test]
        public void RopeBridgeMulti_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

            var indices = 2;
            var commands = Advent2022.RopeBridge.BuildCommands(fileData);
            var grid = Advent2022.RopeBridge.GetGrid(commands, indices);
            Advent2022.RopeBridge.RunCommands(commands, grid, indices);
            var visitedCount = Advent2022.RopeBridge.GetVisitCount(grid, indices); 
            Assert.AreEqual(7, visitedCount);
        }
        
        [Test]
        public void RopeBridgeMulti_Practice2()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

            var indices = 9;
            var commands = Advent2022.RopeBridge.BuildCommands(fileData);
            var grid = Advent2022.RopeBridge.GetGrid(commands, indices);
            Advent2022.RopeBridge.RunCommands(commands, grid, indices);
            var visitedCount = Advent2022.RopeBridge.GetVisitCount(grid, indices); 
            Assert.AreEqual(36, visitedCount);
        }
        
        [Test]
        public void RopeBridgeMulti_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var indices = 9;
            var commands = Advent2022.RopeBridge.BuildCommands(fileData);
            var grid = Advent2022.RopeBridge.GetGrid(commands, indices);
            Advent2022.RopeBridge.RunCommands(commands, grid, indices);
            var visitedCount = Advent2022.RopeBridge.GetVisitCount(grid, indices); 
            Assert.AreEqual(725, visitedCount);
            Assert.AreEqual(1, visitedCount);
        }
    }
}