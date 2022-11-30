using System.Linq;
using AdventShared;
using NUnit.Framework;

namespace Advent2021.Tests
{
    [TestFixture]
    public class Advent17TrickShotTests
    {
        private (int, int) GetMinMax(string row, char axis)
        {
            if (axis == 'x')
            {
                var xIndex = row.IndexOf('x');
                var commaIndex = row.IndexOf(',');
                var xValues = row.Substring(xIndex, commaIndex - xIndex).Split('=')[1];
                return GetMinMaxValue(xValues);
            }
            else
            {
                var yIndex = row.IndexOf('y');
                var yValues = row.Substring(yIndex).Split('=')[1];
                return GetMinMaxValue(yValues);
            }
        }

        private (int, int) GetMinMaxValue(string axisSubstring)
        {
            var axisSplit = axisSubstring.Split('.');
            return (int.Parse(axisSplit[0]), int.Parse(axisSplit[2]));
        }
        
        [Test]
        public void TrickShotPractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent17\Practice.txt");
            //target area: x=29..73, y=-248..-194
            var (minX, maxX) = GetMinMax(rows[0], 'x');
            var (minY, maxY) = GetMinMax(rows[0], 'y');
            
            var xVelocities = TrickShot.GetMinMaxXVelocity(minX, maxX);
            Assert.AreEqual((6, 30), xVelocities);
            
            var xTimes = TrickShot.GetMinMaxXTime(xVelocities);
            Assert.AreEqual((1, 6), xTimes);
            
            var yVelocities = TrickShot.GetMinMaxYVelocity(minY);
            Assert.AreEqual((-10, 9), yVelocities);

            var yTimes = TrickShot.GetMinMaxYTime(minY);
            Assert.AreEqual((1, 20), yTimes);
            
            var yValueTimes = TrickShot.GetYTimeValues(minY, maxY, yVelocities, yTimes);
            Assert.IsTrue(yValueTimes.Any(x => x.Item1 == 9));
            var xValueTimes = TrickShot.GetXTimeValues(minX, maxX, xVelocities, yTimes);
            var validVelocities = TrickShot.CombineXYTimes(yValueTimes, xValueTimes);
            Assert.AreEqual(112, validVelocities.Count);
        }
        
        [Test]
        public void Shot()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent17\Actual.txt");
            
            var (minX, maxX) = GetMinMax(rows[0], 'x');
            var (minY, maxY) = GetMinMax(rows[0], 'y');
            
            var xVelocities = TrickShot.GetMinMaxXVelocity(minX, maxX);
            
            var yVelocities = TrickShot.GetMinMaxYVelocity(minY);

            var yTimes = TrickShot.GetMinMaxYTime(minY);
            
            var yValueTimes = TrickShot.GetYTimeValues(minY, maxY, yVelocities, yTimes);
            var xValueTimes = TrickShot.GetXTimeValues(minX, maxX, xVelocities, yTimes);
            var validVelocities = TrickShot.CombineXYTimes(yValueTimes, xValueTimes);
            Assert.AreEqual(4433, validVelocities.Count);
        }
    }
}