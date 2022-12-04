using AdventShared;
using NUnit.Framework;

namespace Advent2022.Tests
{
    [TestFixture]
    public class Advent01_CalorieCountingTests
    {
        [Test]
        public void MaxCalorie_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

            var elfList = Advent2022.CalorieCounting.BuildElfList(fileData);
            var result = Advent2022.CalorieCounting.MaxCalorieCount(elfList);
            Assert.AreEqual(24000, result);
        }
        
        [Test]
        public void MaxCalorie_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

            var elfList = Advent2022.CalorieCounting.BuildElfList(fileData);
            var result = Advent2022.CalorieCounting.MaxCalorieCount(elfList);
            Assert.AreEqual(72240, result);
        }
        
        [Test]
        public void Top3CalorieTotal_Practice()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

            var elfList = Advent2022.CalorieCounting.BuildElfList(fileData);
            var result = Advent2022.CalorieCounting.Top3CalorieTotal(elfList);
            Assert.AreEqual(45000, result);
        }
        
        [Test]
        public void Top3CalorieTotal_Actual()
        {
            var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

            var elfList = Advent2022.CalorieCounting.BuildElfList(fileData);
            var result = Advent2022.CalorieCounting.Top3CalorieTotal(elfList);
            Assert.AreEqual(210957, result);
        }
    }
}