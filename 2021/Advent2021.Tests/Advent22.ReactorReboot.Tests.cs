using System;
using System.Collections.Generic;
using System.Linq;
using Advent2021.Models;
using AdventShared;
using NUnit.Framework;

namespace Advent2021.Tests
{
    [TestFixture]
    public class Advent22ReactorRebootTests
    {
        [Test]
        public void RebootPractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent22\Practice.txt");

            var instructions = rows.Select(x => new ReactorRebootInstructionModel(x)).ToList();
            var reactor = ReactorReboot.BuildReactor((-50, 50, -50, 50, -50, 50));

            var onCubes = ReactorReboot.Reboot(reactor, instructions);
            Assert.AreEqual(590784, onCubes);
        }
        
        [Test]
        public void Reboot()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent22\Actual.txt");

            var instructions = rows.Select(x => new ReactorRebootInstructionModel(x)).ToList();
            var reactor = ReactorReboot.BuildReactor((-50, 50, -50, 50, -50, 50));

            var onCubes = ReactorReboot.Reboot(reactor, instructions);
            Assert.AreEqual(596989, onCubes);
        }
        
        [Test]
        public void RebootMorePractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent22\Practice2.txt");

            var instructions = rows.Select(x => new ReactorRebootInstructionModel(x)).ToList();
            var instructionGroups = ReactorReboot.GroupInstructionModels(instructions);
            
            var reactor = new Dictionary<int, Dictionary<int, Dictionary<int, bool>>>();
            var onCubes = ReactorReboot.RebootMore(reactor, instructionGroups);
            Assert.AreEqual(2758514936282235, onCubes);
        }
        
        [Test]
        public void RebootMore()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent22\Actual.txt");

            var instructions = rows.Select(x => new ReactorRebootInstructionModel(x)).ToList();

            var reactor = new Dictionary<int, Dictionary<int, Dictionary<int, bool>>>();
            var onCubes = ReactorReboot.RebootMore(reactor, instructions);
            Assert.AreEqual(2758514936282235, onCubes);
        }
    }
}