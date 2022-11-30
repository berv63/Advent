using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2021
{
    public static class TrickShot
    {
        public static (int, int) GetMinMaxXVelocity(int minXTarget, int maxXTarget)
        {
            var options = new List<double>
            {
                (-1 + Math.Sqrt((1 + (4 * ((double)minXTarget * 2))))) / 2,
                (-1 - Math.Sqrt((1 + (4 * ((double)minXTarget * 2))))) / 2
            };
            
            return ((int)Math.Round(options.Max(), MidpointRounding.AwayFromZero), maxXTarget);
        }

        public static (int, int) GetMinMaxXTime((int, int) minMaxXVelocity)
        {
            return (1, minMaxXVelocity.Item1);
        }

        public static (int, int) GetMinMaxYVelocity(int minYTarget)
        {
            return (minYTarget, minYTarget * -1 - 1);
        }

        public static (int, int) GetMinMaxYTime(int minYTarget)
        {
            return (1, minYTarget * -2);
        }

        public static List<(int, int)> GetYTimeValues(int minY, int maxY, (int, int) minMaxYVelocity, (int, int) minMaxYTime)
        {
            var result = new List<(int, int)>();
            for (var velocity = minMaxYVelocity.Item1; velocity <= minMaxYVelocity.Item2; velocity++)
            {
                var resultY = 0;

                for (var time = minMaxYTime.Item1; time <= minMaxYTime.Item2; time++)
                {
                    resultY += velocity - (time - 1);
                    if (resultY >= minY && resultY <= maxY)
                    {
                        result.Add((velocity, time));
                    }

                    if (resultY < minY)
                        break;
                }
            }

            return result;
        }

        public static List<(int, int)> GetXTimeValues(int minX, int maxX, (int, int) xVelocities, (int, int) yTimes)
        {
            var result = new List<(int, int)>();
            for (var velocity = xVelocities.Item1; velocity <= xVelocities.Item2; velocity++)
            {
                var resultX = 0;

                for (var time = yTimes.Item1; time <= yTimes.Item2; time++)
                {
                    if(velocity - (time - 1) > 0)
                        resultX += velocity - (time - 1);
                    
                    if (resultX >= minX && resultX <= maxX)
                    {
                        result.Add((velocity, time));
                    }
                }
            }

            return result;
        }

        public static List<(int, int)> CombineXYTimes(List<(int, int)> yTimeValues, List<(int, int)> xTimeValues)
        {
            var result = new List<(int, int)>();
            foreach (var yTimeValue in yTimeValues)
            {
                foreach (var xTimeValue in xTimeValues)
                {
                    var velocityTuple = (xTimeValue.Item1, yTimeValue.Item1);
                    if(yTimeValue.Item2 == xTimeValue.Item2 && !result.Contains(velocityTuple))
                        result.Add(velocityTuple);
                }
            }

            return result;
        }
    }
}