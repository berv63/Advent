using System.Linq;
using Advent2022.Models;
using Advent2022.Models.Advent10;
using AdventShared;
using NUnit.Framework;

namespace Advent2022.Tests
{
    [TestFixture]
    public class Advent11_MonkeyMiddleTests
    {
        [Test]
        public void MonkeyMiddle_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var monkeys = Advent2022.MonkeyMiddle.BuildMonkeyModels(fileData);
            Advent2022.MonkeyMiddle.ProcessMonkeyMiddle(monkeys, 20, true);
            var activeMonkeyResult = Advent2022.MonkeyMiddle.GetActiveMonkeyResult(monkeys);
            Assert.AreEqual(10605, activeMonkeyResult);
        }
        
        [Test]
        public void MonkeyMiddle_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var monkeys = Advent2022.MonkeyMiddle.BuildMonkeyModels(fileData);
            Advent2022.MonkeyMiddle.ProcessMonkeyMiddle(monkeys, 20, true);
            var activeMonkeyResult = Advent2022.MonkeyMiddle.GetActiveMonkeyResult(monkeys);
            Assert.AreEqual(55216, activeMonkeyResult);
        }
        
        [Test]
        public void MonkeyMiddleNoRelief01_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var monkeys = Advent2022.MonkeyMiddle.BuildMonkeyModels(fileData);
            Advent2022.MonkeyMiddle.ProcessMonkeyMiddle(monkeys, 1, false);
            var activeMonkeyResult = Advent2022.MonkeyMiddle.GetActiveMonkeyResult(monkeys);
            Assert.AreEqual((long)24, activeMonkeyResult);
        }
        
        [Test]
        public void MonkeyMiddleNoRelief20_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var monkeys = Advent2022.MonkeyMiddle.BuildMonkeyModels(fileData);
            Advent2022.MonkeyMiddle.ProcessMonkeyMiddle(monkeys, 20, false);
            var activeMonkeyResult = Advent2022.MonkeyMiddle.GetActiveMonkeyResult(monkeys);
            Assert.AreEqual((long)10197, activeMonkeyResult);
        }
        
        [Test]
        public void MonkeyMiddleNoRelief1000_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var monkeys = Advent2022.MonkeyMiddle.BuildMonkeyModels(fileData);
            Advent2022.MonkeyMiddle.ProcessMonkeyMiddle(monkeys, 1000, false);
            var activeMonkeyResult = Advent2022.MonkeyMiddle.GetActiveMonkeyResult(monkeys);
            Assert.AreEqual((long)27019168, activeMonkeyResult);
        }
        
        [Test]
        public void MonkeyMiddleNoRelief_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var monkeys = Advent2022.MonkeyMiddle.BuildMonkeyModels(fileData);
            Advent2022.MonkeyMiddle.ProcessMonkeyMiddle(monkeys, 10000, false);
            var activeMonkeyResult = Advent2022.MonkeyMiddle.GetActiveMonkeyResult(monkeys);
            Assert.AreEqual((long)2713310158, activeMonkeyResult);
        }
        
        [Test]
        public void MonkeyMiddleNoRelief_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");
            
            var monkeys = Advent2022.MonkeyMiddle.BuildMonkeyModels(fileData);
            Advent2022.MonkeyMiddle.ProcessMonkeyMiddle(monkeys, 10000, false);
            var activeMonkeyResult = Advent2022.MonkeyMiddle.GetActiveMonkeyResult(monkeys);
            Assert.AreNotEqual(13394044960, activeMonkeyResult);
            Assert.AreNotEqual(13446482318, activeMonkeyResult);
            Assert.AreEqual(12848882750, activeMonkeyResult);
        }
    }
}