using System.Collections.Generic;
using System.Linq;

namespace Advent2021
{
    public static class SmokeBasin
    {
        public static int GetBasinSizeScore(List<List<int>> basinMap)
        {
            var sizes = new List<int>();
            for (var i = 0; i < basinMap.Count; i++)
            {
                for (var j = 0; j < basinMap[i].Count; j++)
                {
                    if (basinMap[i][j] != 1)
                    {
                        var basinSize = CountHorizontal(i, j, basinMap);
                        if (basinSize > 0)
                            sizes.Add(basinSize);
                    }
                }
            }

            return GetLargestThreeBasins(sizes);
        }

        private static int GetLargestThreeBasins(IEnumerable<int> basinSizes)
        {
            var sortBasins = basinSizes.OrderByDescending(x => x).ToList();
            return sortBasins[0] * sortBasins[1] * sortBasins[2];
        }

        private static int CountHorizontal(int i, int j, List<List<int>> basinMap)
        {
            if (InvalidBasinValue(i, j, basinMap))
                return 0;
            
            basinMap[i][j] = 1;
            return 1 + CountVertical(i-1, j, basinMap) + CountVertical(i+1, j, basinMap) + CountHorizontal(i, j+1, basinMap) + CountHorizontal(i, j-1, basinMap);
        }

        private static int CountVertical(int i, int j, List<List<int>> basinMap)
        {
            if (InvalidBasinValue(i, j, basinMap))
                return 0;
            
            basinMap[i][j] = 1;
            return 1 + CountVertical(i-1, j, basinMap) + CountVertical(i+1, j, basinMap) + CountHorizontal(i, j+1, basinMap) + CountHorizontal(i, j-1, basinMap);
        }

        private static bool InvalidBasinValue(int i, int j, List<List<int>> basinMap)
        {
            if (j == -1 || i == -1) //off the min edge
                return true;
            if (j == basinMap[0].Count || i == basinMap.Count) //off the max edge
                return true;
            if (basinMap[i][j] == 1) //high point
                return true;
            
            return false;
        }
        
        #region part1
        
        public static int GetLowPointRiskSummation(List<List<int>> heightMap)
        {
            var result = 0;
            for (var i = 0; i < heightMap.Count; i++)
            {
                for (var j = 0; j < heightMap[0].Count; j++)
                {
                    var isLowest = isVerticallyLowest(i, j, heightMap) && isHorizontallyLowest(i, j, heightMap);
                    result += isLowest ? heightMap[i][j] + 1 : 0;
                }
            }
            return result;
        }
        
        private static bool isHorizontallyLowest(int iIndex, int jIndex, IReadOnlyList<List<int>> heightMap)
        {
            if (jIndex == 0)
                return IsRightValueHigher(iIndex, jIndex, heightMap);
            
            if (jIndex == heightMap[iIndex].Count - 1)
                return IsLeftValueHigher(iIndex, jIndex, heightMap);
            
            return IsRightValueHigher(iIndex, jIndex, heightMap) && IsLeftValueHigher(iIndex, jIndex, heightMap);
        }

        private static bool IsLeftValueHigher(int iIndex, int jIndex, IReadOnlyList<List<int>> heightMap)
        {
            return heightMap[iIndex][jIndex - 1] > heightMap[iIndex][jIndex];
        }
        
        private static bool IsRightValueHigher(int iIndex, int jIndex, IReadOnlyList<List<int>> heightMap)
        {
            return heightMap[iIndex][jIndex + 1] > heightMap[iIndex][jIndex];
        }

        private static bool isVerticallyLowest(int iIndex, int jIndex, IReadOnlyList<List<int>> heightMap)
        {
            if (iIndex == 0)
                return IsUnderValueHigher(iIndex, jIndex, heightMap);
            
            if (iIndex == heightMap.Count - 1)
                return IsUpperValueHigher(iIndex, jIndex, heightMap);
            
            return IsUpperValueHigher(iIndex, jIndex, heightMap) && IsUnderValueHigher(iIndex, jIndex, heightMap);
        }

        private static bool IsUpperValueHigher(int iIndex, int jIndex, IReadOnlyList<List<int>> heightMap)
        {
            return heightMap[iIndex - 1][jIndex] > heightMap[iIndex][jIndex];
        }
        
        private static bool IsUnderValueHigher(int iIndex, int jIndex, IReadOnlyList<List<int>> heightMap)
        {
            return heightMap[iIndex + 1][jIndex] > heightMap[iIndex][jIndex];
        }
        
        #endregion
    }
}
