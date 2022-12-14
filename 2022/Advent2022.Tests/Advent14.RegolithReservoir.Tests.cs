using AdventShared;
using NUnit.Framework;

namespace Advent2022.Tests
{
    [TestFixture]
    public class Advent14_RegolithReservoirTests
    {
        [Test]
        public void Reservoir_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var coordinates = Advent2022.RegolithReservoir.BuildRockCoordinates(fileData);
            var grid = Advent2022.RegolithReservoir.BuildRockGrid(coordinates);
            var countSettled = Advent2022.RegolithReservoir.GetCountSettled(grid);
            Assert.AreEqual(24, countSettled);
        }
        
        [Test]
        public void Reservoir_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var coordinates = Advent2022.RegolithReservoir.BuildRockCoordinates(fileData);
            var grid = Advent2022.RegolithReservoir.BuildRockGrid(coordinates);
            var countSettled = Advent2022.RegolithReservoir.GetCountSettled(grid);
            Assert.AreEqual(858, countSettled);
        }
        
        [Test]
        public void ReservoirFloor_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var coordinates = Advent2022.RegolithReservoir.BuildRockCoordinates(fileData);
            var grid = Advent2022.RegolithReservoir.BuildRockGrid(coordinates, true);
            var countSettled = Advent2022.RegolithReservoir.GetCountSettled(grid);
            Assert.AreEqual(93, countSettled);
        }
        
        [Test]
        public void ReservoirFloor_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var coordinates = Advent2022.RegolithReservoir.BuildRockCoordinates(fileData);
            var grid = Advent2022.RegolithReservoir.BuildRockGrid(coordinates, true);
            var countSettled = Advent2022.RegolithReservoir.GetCountSettled(grid);
            Assert.AreEqual(26845, countSettled);
        }
    }
}