using System.Linq;
using Advent2021.Models;
using AdventShared;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Advent2021.Tests
{
    [TestFixture]
    public class Advent2DiveTests
    {
        [Test]
        public void DivePractice()
        {
            var instructions = FileExtensions.ReadFile(@"..\..\..\Files\Advent2\Practice.txt");
            var instructionModels = instructions.Select(x => new DiveModel(x)).ToList();
            
            var deeperCount = Dive.GetFinalDestinationMultiplier(instructionModels);
            Assert.AreEqual(150, deeperCount);
        }
        
        [Test]
        public void Dive1()
        {
            var instructions = FileExtensions.ReadFile(@"..\..\..\Files\Advent2\Actual.txt");
            var instructionModels = instructions.Select(x => new DiveModel(x)).ToList();
            
            var deeperCount = Dive.GetFinalDestinationMultiplier(instructionModels);
            Assert.AreEqual(1762050, deeperCount);
        }
        
        [Test]
        public void AimDivePractice()
        {
            var instructions = FileExtensions.ReadFile(@"..\..\..\Files\Advent2\Practice.txt");
            var instructionModels = instructions.Select(x => new DiveModel(x)).ToList();
            
            var deeperCount = Dive.GetFinalAimDestinationMultiplier(instructionModels);
            Assert.AreEqual(900, deeperCount);
        }
        
        [Test]
        public void AimDive()
        {
            var instructions = FileExtensions.ReadFile(@"..\..\..\Files\Advent2\Actual.txt");
            var instructionModels = instructions.Select(x => new DiveModel(x)).ToList();
            
            var deeperCount = Dive.GetFinalAimDestinationMultiplier(instructionModels);
            Assert.AreNotEqual(1762050, deeperCount); //accidentally ran GetFinalDestinationMultiplier
            Assert.AreEqual(1855892637, deeperCount);
        }
    }
}