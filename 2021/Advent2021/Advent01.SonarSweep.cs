using System.Collections.Generic;

namespace Advent2021
{
    public static class SonarSweep
    {
        public static int GetSlidingDeeperCount(List<int> depths)
        {
            var slidingDepths = ConvertMeasurementsToSum(depths);
            var deeperCount = GetDeeperCount(slidingDepths);
            return deeperCount;
        }
        
        private static List<int> ConvertMeasurementsToSum(IReadOnlyList<int> depths)
        {
            var result = new List<int>();
            for (var i = 0; i <= depths.Count - 3; i++)
            {
                result.Add(depths[i] + depths[i+1] + depths[i+2]);
            }
            return result;
        }
        
        public static int GetDeeperCount(List<int> depths)
        {
            var numDeeper = 0;
            for (var i = 0; i <= depths.Count - 2; i++)
            {
                numDeeper += IsSecondDeeper(depths[i], depths[i + 1]) ? 1 : 0;
            }
            return numDeeper;
        }

        private static bool IsSecondDeeper(int first, int second)
        {
            return second > first;
        }
    }
}