using System.Collections.Generic;
using System.Linq;
using Advent2022.Models;
using AdventShared;
using NUnit.Framework;

namespace Advent2022.Tests
{
    [TestFixture]
    public class Advent1CalorieCountingTests
    {
        [Test]
        public void MaxCaloriePractice()
        {
            var elfFoods = FileExtensions.ReadFile(@"..\..\..\..\Files\Advent1\Practice.txt");

            var elfList = Advent2022.CalorieCounting.BuildElfList(elfFoods);
            var result = Advent2022.CalorieCounting.MaxCalorieCount(elfList);
            Assert.AreEqual(24000, result);
        }
        
        [Test]
        public void MaxCalorie()
        {
            var elfFoods = FileExtensions.ReadFile(@"..\..\..\..\Files\Advent1\Practice.txt");

            var elfList = Advent2022.CalorieCounting.BuildElfList(elfFoods);
            var result = Advent2022.CalorieCounting.MaxCalorieCount(elfList);
            Assert.AreEqual(24000, result);
        }
        
        [Test]
        public void Top3CalorieTotalPractice()
        {
            var elfFoods = FileExtensions.ReadFile(@"..\..\..\..\Files\Advent1\Practice.txt");

            var elfList = Advent2022.CalorieCounting.BuildElfList(elfFoods);
            var result = Advent2022.CalorieCounting.Top3CalorieTotal(elfList);
            Assert.AreEqual(45000, result);
        }
        
        [Test]
        public void Top3CalorieTotal()
        {
            var elfFoods = FileExtensions.ReadFile(@"..\..\..\..\Files\Advent1\Actual.txt");

            var elfList = Advent2022.CalorieCounting.BuildElfList(elfFoods);
            var result = Advent2022.CalorieCounting.Top3CalorieTotal(elfList);
            Assert.AreEqual(210957, result);
        }
    }
}